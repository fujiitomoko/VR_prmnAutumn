using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PatientSpeechManager : MonoBehaviour
{
    [SerializeField] PatientReply _patientReply = new PatientReply();
    [SerializeField] GameObject _canvas;
    [SerializeField] GameObject _speechText;
    private Text _text;

    [SerializeField] float _speechSec = .5f;
    [SerializeField] string _defaultReply = "";
    [SerializeField] Vector3 _offset = default;
    [SerializeField] AudioSource _audioSource = default;

    private float _timer = 0f;
    private float _hideTime = 5f;

    void Start()
    {
        _text = _speechText.transform.Find("ResultText").GetComponent<Text>();
        HideText();
    }

    void Update()
    {
        // テキストは5秒後に非表示にする
        if (_speechText.activeSelf)
        {
            _timer += Time.deltaTime;
            if(_timer > _hideTime)
            {
                HideText();
            }
        } else _timer = 0f;

        // オブジェクトを頭部座標まで移動する
        var headPos = _patientReply.GetHeadPosition();
        _canvas.transform.position = headPos + _offset;
    }

    public void Reply(string playerSpeech)
    {
        HideText();
        // var patientReply = new PatientReply();
        var reply = _patientReply.GetReply(playerSpeech);
        if(reply == "") reply = _defaultReply;
        ShowText(reply);
    }

    public void ShowText(string txt)
    {
        var beforeTxt = _text.text;
        _text.DOText(txt, _speechSec)
            .SetEase(Ease.Linear)
            .OnUpdate(() =>
            {
                var currentTxt = _text.text;
                if(currentTxt == beforeTxt) return;

                _audioSource.Play();
                beforeTxt = currentTxt;
            });
        _speechText.SetActive(true);
    }

    public void HideText()
    {
        _speechText.SetActive(false);
        _text.text = "";
    }
}