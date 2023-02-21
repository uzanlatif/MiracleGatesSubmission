using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderPhysics : MonoBehaviour
{
    public PolygonCollider2D hole,ground;
    public MeshCollider GeneratedMeshCollider;
    public float speed = 5;

    Mesh GeneratedMesh;

    private void Update() {
        if (Input.GetKey(KeyCode.A))
     {
         transform.position += Vector3.left * speed * Time.deltaTime;
     }
        if (Input.GetKey(KeyCode.D))
     {
         transform.position += Vector3.right * speed * Time.deltaTime;
     }
        if (Input.GetKey(KeyCode.W))
     {
         transform.position += Vector3.forward * speed * Time.deltaTime;
     }
        if (Input.GetKey(KeyCode.S))
     {
         transform.position += Vector3.forward * -1 * speed * Time.deltaTime;
     }
    }
    

    private void FixedUpdate() {
        if(transform.hasChanged==true){
            transform.hasChanged = false;
            hole.transform.position = new Vector2(transform.position.x,transform.position.z);
            MakeMesh();
            MakeHole();
        }
    }

    void MakeMesh(){
        if(GeneratedMesh!=null){
            Destroy(GeneratedMesh);
        }

        GeneratedMesh = ground.CreateMesh(true,true);
        GeneratedMeshCollider.sharedMesh = GeneratedMesh;
    }

    void MakeHole(){
        Vector2[] PointPositions = hole.GetPath(0);
        for(int i = 0; i < PointPositions.Length; i++) {

            PointPositions[i] += (Vector2)hole.transform.position;

            ground.pathCount = 2;
            ground.SetPath(1,PointPositions);
            
        }
    }
}
