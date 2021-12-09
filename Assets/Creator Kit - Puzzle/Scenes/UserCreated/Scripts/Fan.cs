using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    public bool spin = false;

    private void Update(){
        if(spin) transform.Rotate(270f*Time.deltaTime,0f,0f);
    }
}
