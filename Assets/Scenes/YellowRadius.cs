using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowRadius : MonoBehaviour
{
    public EnemyController control;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            control.CheckYellow();
            Debug.Log("Yellow");
        }
    }

    private void OnTriggerExit(Collider other) {
       if(other.gameObject.tag == "Player"){
            control.ResetContaminated();
        } 
    }
}
