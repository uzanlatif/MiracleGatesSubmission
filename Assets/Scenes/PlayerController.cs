using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SaveData saving;
    public Transform cam;
    public GameObject myGlass, myBoots;
    public float speed = 5;
    public float rotateSpeed = 100;
    public float turnSmoothTime = 0.3f;
    public float turnSmoothVelocity = 0.4f;

    private void Start() {
        saving.LoadBoots();
        saving.LoadGlass();
    }

    public void ChangeGlass(byte x, byte y, byte z, byte a){
        myGlass.GetComponent<Renderer>().material.color = new Color32(x,y,z,a);
    }

    public void ChangeBoots(byte x, byte y, byte z, byte a){
        myBoots.GetComponent<Renderer>().material.color = new Color32(x,y,z,a);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void ChangeGlassColor(){
        byte x =( byte )Random.Range( 0, 255 );
        byte y =( byte )Random.Range( 0, 255 );
        byte z =( byte )Random.Range( 0, 255 );
        byte a =( byte )Random.Range( 0, 255 );
    
        myGlass.GetComponent<Renderer>().material.color = new Color32(x,y,z,a);
        saving.GetDataColorGlass(x,y,z,a);
        saving.SaveToJsonGlass();
    }

    public void ChangeBootsColor(){
        byte x =( byte )Random.Range( 0, 255 );
        byte y =( byte )Random.Range( 0, 255 );
        byte z =( byte )Random.Range( 0, 255 );
        byte a =( byte )Random.Range( 0, 255 );
    
        myBoots.GetComponent<Renderer>().material.color = new Color32(x,y,z,a);
        saving.GetDataColorBoots(x,y,z,a);
        saving.SaveToJsonBoots();
    }

    void Move(){

        //input movement
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f ,vertical).normalized;

        if(direction.magnitude >= 0.1f){
            //rotation
            float targetAngle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime); 
            
            transform.rotation=Quaternion.Euler(0f,angle,0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            //movement
            transform.Translate (moveDir*speed*Time.deltaTime, Space.World);
           
        }

    }
}

