using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    public bool spin = false;

    private void FixedUpdate(){
        if (spin)
        {
            transform.Rotate(360f * Time.deltaTime, 0f, 0f);

            RaycastHit hit;
            if(Physics.Raycast(transform.position, transform.right, out hit, 8f))
            {
                hit.rigidbody.AddForce(transform.right*.8f);
            }
        }
    }
}
