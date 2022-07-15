using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NsUnityVr.Systems;

public class Wipe : MaintainedWithoutGrabbing
{
    int count;
    new void Start()
    {
        count = 0;
    }

    void Update()
    {
        if(count >= 4){
            MaintenanceAction();
        }
    }

    public void OnTriggerEnter(Collider other) {
        if(other.tag == "Zoukin"){
        SEManager.Instance.PlaySE(SE.zoukin);
        count++;
        }
    }

    protected override void MaintenanceAction(){
		base.MaintenanceAction();
		var rd = GetComponent<Renderer>();
		rd.enabled = false;
}

}
