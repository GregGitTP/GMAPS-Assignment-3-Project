using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public GameObject top;
    public GameObject bot;

    public bool launcher1;

    Rigidbody topRb;

    private void OnEnable(){
        topRb = top.GetComponent<Rigidbody>();

        Reset();
    }

    public void Launch(){
        topRb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
    }

    public void Reset(){
        if(launcher1) top.transform.position = new Vector3(top.transform.position.x, top.transform.position.y - 1, top.transform.position.z);
        else top.transform.position = new Vector3(bot.transform.position.x, bot.transform.position.y + .05f, bot.transform.position.z);
        topRb.constraints = RigidbodyConstraints.FreezeAll;
    }
}
