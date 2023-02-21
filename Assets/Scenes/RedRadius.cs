using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedRadius : MonoBehaviour
{   
    public EnemyController control;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            control.CheckRed();
            Debug.Log("Red");
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Player"){
            control.ResetContaminated();
        }
    }
}
