using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turner : MonoBehaviour
{
    public GameObject turner;

    private void Update(){
        if(Physics.Raycast(transform.position,transform.up,.01f)){
            StartCoroutine(StartTurning());
        }
    }

    IEnumerator StartTurning(){
        yield return new WaitForSeconds(.5f);
        for(;;){
            turner.transform.rotation = Quaternion.Slerp(turner.transform.rotation, Quaternion.Euler(0, 0, -100), .02f*Time.deltaTime);
            yield return null;
        }
    }
}
