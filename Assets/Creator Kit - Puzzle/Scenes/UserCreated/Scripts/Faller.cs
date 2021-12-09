using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faller : MonoBehaviour
{
    Rigidbody rb;
    bool resetting = false;

    private void Start(){
        rb = GetComponent<Rigidbody>();
    }

    private void Update(){
        if(transform.localRotation.eulerAngles.z <= 260f && transform.localRotation.eulerAngles.z > 1 && !resetting){
            StartCoroutine(StopAndReset());
        }
    }

    IEnumerator StopAndReset(){
        resetting = true;

        transform.localRotation = Quaternion.Euler(0f,0f,-100f);
        rb.constraints = RigidbodyConstraints.FreezeAll;

        yield return new WaitForSeconds(1f);

        while(transform.localRotation.eulerAngles.z >= 1f){
            transform.localRotation = Quaternion.Slerp(transform.localRotation,Quaternion.Euler(0f,0f,0f),0.01f);
            yield return null;
        }

        transform.localRotation = Quaternion.Euler(0f,0f,0f);
        rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;

        resetting = false;
    }
}