using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SponeController : MonoBehaviour
{
    [SerializeField] GameObject sponeObject;
    BoxCollider col;
    Vector3 v = new Vector3(0,0,0);

    void Start()
    {
        Transform mytransform = this.transform;
        Vector3 pos = mytransform.position;
        col = GetComponent<BoxCollider>();
        v = col.size;
        float x = Random.Range(pos.x-v.x/2,pos.x+v.x/2);
        float z = Random.Range(pos.z-v.z/2,pos.z+v.z/2);
        Instantiate(sponeObject, new Vector3(x,0,z), sponeObject.transform.rotation);
        Debug.Log(x);
        Debug.Log(z);
        Debug.Log(v);
    }

    void Update()
    {

    }
}
