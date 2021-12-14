using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateButton : MonoBehaviour
{
    public GameObject gate;
    public GameObject hatch;

    private void OnCollisionEnter(){
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        GetComponent<MeshRenderer>().enabled = false;
        StartCoroutine(OpenGate());
        StartCoroutine(DelayOpenHatch());
    }

    IEnumerator OpenGate(){
        for(;;){
            gate.transform.rotation = Quaternion.Slerp(gate.transform.rotation, Quaternion.Euler(90, 0, 0), .3f*Time.deltaTime);
            yield return null;
        }
    }

    IEnumerator DelayOpenHatch(){
        yield return new WaitForSeconds(15f);
        hatch.SetActive(false);
    }
}
