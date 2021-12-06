using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherPiece : MonoBehaviour
{
    public GameObject l1;
    public GameObject l2;
    public GameObject l3;
    public GameObject l4;

    enum Phase{one,two,three,four};
    Phase phase = Phase.one;

    float timeElap = 0;
    bool start = false;
    bool resetting = false;

    private void Start(){
        StartCoroutine(DelayReset());
    }

    private void Update(){
        if(!resetting){
            switch(phase){
            case Phase.one:
                if(Input.GetKeyDown(KeyCode.Alpha1)){
                    l1.GetComponent<Launcher>().Launch();
                    phase = Phase.two;
                    timeElap = 0;
                    start = true;
                }
                break;
            case Phase.two:
                if(Input.GetKeyDown(KeyCode.Alpha2)){
                    l2.GetComponent<Launcher>().Launch();
                    phase = Phase.three;
                    timeElap = 0;
                }
                break;
            case Phase.three:
                if(Input.GetKeyDown(KeyCode.Alpha3)){
                    l3.GetComponent<Launcher>().Launch();
                    phase = Phase.four;
                    timeElap = 0;
                }
                break;
            case Phase.four:
                if(Input.GetKeyDown(KeyCode.Alpha4)){
                    l4.GetComponent<Launcher>().Launch();
                    phase = Phase.one;
                    StartCoroutine(End());
                }
                break;
        }
        }
    }

    IEnumerator DelayReset(){
        for(;;){
            if(start){
                if(timeElap >= 4f) StartCoroutine(Reset());
                timeElap += Time.deltaTime;
            }
            yield return null;
        }
    }

    IEnumerator End(){
        yield return new WaitForSeconds(.5f);
        StartCoroutine(Reset());
    }

    IEnumerator Reset(){
        start = false;
        resetting = true;
        timeElap = 0;
        l1.GetComponent<Launcher>().Reset();
        yield return new WaitForSeconds(1f);
        l2.GetComponent<Launcher>().Reset();
        yield return new WaitForSeconds(1f);
        l3.GetComponent<Launcher>().Reset();
        yield return new WaitForSeconds(1f);
        l4.GetComponent<Launcher>().Reset();
        phase = Phase.one;
        resetting = false;
    }
}
