using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingBall : MonoBehaviour
{
    public LineRenderer lr;
    public Transform p1;
    public Transform p2;

    public GameObject pivot;
    public Transform triggerPt;
    public Rigidbody rb;

    private bool swinging = false;

    private void Update(){
        lr.SetPosition(0,p1.position);
        lr.SetPosition(1,p2.position);

        if(!swinging){
            Debug.DrawRay(triggerPt.position,triggerPt.right);
            if(Physics.Raycast(triggerPt.position,triggerPt.right,1f)){
                StartCoroutine(Swing());
            }
        }
    }

    IEnumerator Swing(){
        swinging = true;
        rb.isKinematic = false;

        float timeElap = 0f;
        while(timeElap < 7.3){
            pivot.transform.Rotate(0f,90f*Time.deltaTime,0f);
            timeElap+=Time.deltaTime;
            yield return null;
        }

        rb.isKinematic = true;
        pivot.transform.rotation = Quaternion.Euler(0f,0f,0f);

        swinging = false;
    }
}
