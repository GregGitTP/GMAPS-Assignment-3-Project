using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject shootPoint;
    public Transform cannon;
    public Transform barrel;

    public GameObject marble;
    public Transform mSpawnPoint;

    private bool turningLeft = false;
    private bool turningRight = false;

    private bool shooting = false;

    private void Update(){
        if(Input.GetKeyDown(KeyCode.Z)) turningLeft = true;
        if(Input.GetKeyUp(KeyCode.Z)) turningLeft = false;

        if(Input.GetKeyDown(KeyCode.X)) turningRight = true;
        if(Input.GetKeyUp(KeyCode.X)) turningRight = false;

        if(Input.GetKeyDown(KeyCode.C) && !shooting){
            StartCoroutine(Shoot());
        }

        if(turningLeft && !shooting) TurnLeft();
        if(turningRight && !shooting) TurnRight();
    }

    private void TurnLeft(){
        cannon.rotation = Quaternion.Slerp(cannon.rotation,Quaternion.Euler(0f,-90f,0),.0005f);
    }
    private void TurnRight(){
        cannon.rotation = Quaternion.Slerp(cannon.rotation,Quaternion.Euler(0f,90f,0),.0005f);
    }

    IEnumerator Shoot(){
        shooting = true;

        Instantiate(marble,mSpawnPoint.position,Quaternion.identity);
        yield return new WaitForSeconds(1f);
        
        while(barrel.localRotation.eulerAngles.x < 39){
            barrel.localRotation = Quaternion.Slerp(barrel.localRotation,Quaternion.Euler(40,0,0),.01f);
            yield return null;
        }
        barrel.localRotation = Quaternion.Euler(40f,0f,0f);

        yield return new WaitForSeconds(1f);

        RaycastHit hit;
        if(Physics.Raycast(shootPoint.transform.position,shootPoint.transform.up,out hit,.5f)){
            hit.rigidbody.AddForce(shootPoint.transform.up*30f,ForceMode.Impulse);
        }

        yield return new WaitForSeconds(2f);

        while(barrel.localRotation.eulerAngles.x > 1){
            barrel.localRotation = Quaternion.Slerp(barrel.localRotation,Quaternion.Euler(0,0,0),.01f);
            yield return null;
        }
        barrel.localRotation = Quaternion.Euler(0f,0f,0f);
        shooting = false;
    }
}
