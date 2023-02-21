using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject[] enemy;
    public GameObject myBody, player;
    public bool red, yellow;
    public GameObject[] wall;

    private void Start() {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        wall = GameObject.FindGameObjectsWithTag("Wall");
        player = GameObject.FindGameObjectWithTag("Player");

        red = false;
        yellow = false;

        myBody.GetComponent<Renderer>().material.color = new Color32(0,255,0,255);
    }

    public void CheckYellow(){
        float closestWall=1000;
        float dist = Vector3.Distance(gameObject.transform.position, player.transform.position);

        for(int i = 0; i < wall.Length; i++) {
            if(closestWall > Vector3.Distance(gameObject.transform.position, wall[i].transform.position)){
                closestWall = Vector3.Distance(gameObject.transform.position, wall[i].transform.position);
            }
        }

        if(!red && (dist<closestWall)){
            myBody.GetComponent<Renderer>().material.color = new Color32(255,255,0,255);
            yellow = true;
            Spread("Yellow");
        }

    }

    public void CheckRed(){
        red = true;
        myBody.GetComponent<Renderer>().material.color = new Color32(255,0,0,255);

        Spread("Red");
    }

    void Spread(string color){
        for(int i = 0; i < enemy.Length; i++) {
            float dist = Vector3.Distance(gameObject.transform.position, enemy[i].transform.position);

            if(dist<10){
                if(color == "Red"){
                    enemy[i].GetComponent<Renderer>().material.color = new Color32(255,0,0,255);
                    enemy[i].GetComponent<EnemyController>().ResetContaminated();
                }
                if(color == "Yellow"){
                    enemy[i].GetComponent<Renderer>().material.color = new Color32(255,255,0,255);
                    enemy[i].GetComponent<EnemyController>().ResetContaminated();
                }
            }
        }
    }

    public void ResetContaminated(){
        Invoke("Wait",5);
    }

    public void Wait(){
        myBody.GetComponent<Renderer>().material.color = new Color32(0,255,0,255);
        red=false;
        yellow=false;
    }

}
