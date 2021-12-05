using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public Rigidbody top;

    private void Start(){
        StartCoroutine(Reset());
    }

    public IEnumerator Reset(){
        top.AddForce(0f,-1500f,0);
        yield return null;
        top.constraints = RigidbodyConstraints.FreezeAll;
    }
}
