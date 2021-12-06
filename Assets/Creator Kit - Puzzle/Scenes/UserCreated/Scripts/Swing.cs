using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    public Rigidbody rb;

    private void Update(){
        if(Physics.Raycast(transform.position,transform.up,.01f)){
            StartCoroutine(StartSwing());
        }
    }

    IEnumerator StartSwing(){
        yield return new WaitForSeconds(.5f);
        rb.isKinematic = false;
    }
}
