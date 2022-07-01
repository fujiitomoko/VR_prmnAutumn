using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoukinButton : MonoBehaviour
{
    [SerializeField] GameObject zoukin;
    bool flag;
    void Start()
    {
        flag = false;
        zoukin.SetActive(flag);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onClick(){
            Debug.Log(1);
            flag = !flag;
            zoukin.SetActive(flag);
    }
}
