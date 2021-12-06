using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    private void OnCollisionEnter(Collision other){
        other.gameObject.GetComponent<Rigidbody>().AddForce(transform.up*2000f);
    }
}
