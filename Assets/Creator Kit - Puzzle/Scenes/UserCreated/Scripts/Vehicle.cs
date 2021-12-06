using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    public float speed = 3f;
    public GameObject rotatePoint;
    public GameObject door;
    public GameObject cont;
    public GameObject part;

    Rigidbody rb;
    bool tilting = false;

    private void Start(){
        rb = GetComponent<Rigidbody>();
    }

    private void Update(){
        float hori = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        Vector3 move=transform.right*hori+transform.forward*vert;
        move*=Time.deltaTime*speed;
        move*=1000;
        rb.AddForce(move,ForceMode.Force);
        if(hori==0&&vert==0)rb.velocity=new Vector3(0,rb.velocity.y,0);
        if(rb.velocity.magnitude>3f)rb.velocity=rb.velocity.normalized*3f;

        // transform.Translate(transform.right*hori*speed*Time.deltaTime + transform.forward*vert*speed*Time.deltaTime);

        if(!tilting && Input.GetKeyDown(KeyCode.F)){
            StartCoroutine(Tilt());
        }
    }

    private void OnCollisionEnter(Collision other){
        if(other.gameObject.tag == "RollingBall"){
            Instantiate(part, other.GetContact(0).point, Quaternion.identity);
            StartCoroutine(FlyAway());
        }
    }

    IEnumerator FlyAway(){
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.None;
        rb.AddExplosionForce(3000f,new Vector3(cont.transform.position.x,cont.transform.position.y - .2f,cont.transform.position.z + 2f),3f);
        yield return new WaitForSeconds(1f);
        rb.useGravity = true;
    }

    IEnumerator Tilt(){
        tilting = true;
        door.SetActive(false);
        float timeElap = 0;
        while(timeElap < 5f){
            rotatePoint.transform.rotation = Quaternion.Slerp(rotatePoint.transform.rotation, Quaternion.Euler(25, 0, 0), .6f*Time.deltaTime);
            timeElap += Time.deltaTime;
            yield return null;
        }
        timeElap = 0;
        yield return new WaitForSeconds(1f);
        while(timeElap < 5f){
            rotatePoint.transform.rotation = Quaternion.Slerp(rotatePoint.transform.rotation, Quaternion.Euler(0, 0, 0), .8f*Time.deltaTime);
            timeElap += Time.deltaTime;
            yield return null;
        }
        door.SetActive(true);
        tilting = false;
    }
}
