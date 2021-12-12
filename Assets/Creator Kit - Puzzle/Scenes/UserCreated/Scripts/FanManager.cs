using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanManager : MonoBehaviour
{
    public Fan fan1,fan2,fan3;

    private void Update(){
        if(Input.GetKeyDown(KeyCode.O)) fan1.spin = true;
        if(Input.GetKeyUp(KeyCode.O)) fan1.spin = false;

        if(Input.GetKeyDown(KeyCode.P)) fan2.spin = true;
        if(Input.GetKeyUp(KeyCode.P)) fan2.spin = false;

        if(Input.GetKeyDown(KeyCode.I)) fan3.spin = true;
        if(Input.GetKeyUp(KeyCode.I)) fan3.spin = false;
    }
}
