using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public LineRenderer lr;
    public Transform p1;
    public Transform p2;

    private void Update(){
        lr.SetPosition(0,p1.position);
        lr.SetPosition(1,p2.position);
    }
}
