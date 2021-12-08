using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stopper : MonoBehaviour
{
    private void OnCollisionEnter(Collision other){
        other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
