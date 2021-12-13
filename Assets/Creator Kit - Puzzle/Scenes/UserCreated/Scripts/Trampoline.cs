using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float force = 1500f;

    private void OnCollisionEnter(Collision other){
        other.gameObject.GetComponent<Rigidbody>().AddForce(transform.up*force);
    }
}
