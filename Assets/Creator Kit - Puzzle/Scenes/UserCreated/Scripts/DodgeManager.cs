using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeManager : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject destroyPoint;
    public GameObject ball;
    public GameObject part;

    private void Start(){
        StartCoroutine(SpawnBalls());
    }

    private void Update(){
        GameObject[] balls = GameObject.FindGameObjectsWithTag("RollingBall");
        foreach(GameObject ball in balls){
            if(ball.transform.position.z <= destroyPoint.transform.position.z + 2){
                Destroy(ball);
            }
        }
    }
    
    IEnumerator SpawnBalls(){
        for(;;){
            int rdm = Random.Range(0,spawnPoints.Length);
            GameObject spawn = spawnPoints[rdm];
            Instantiate(part,spawn.transform.position,Quaternion.identity);
            yield return new WaitForSeconds(1f);
            Instantiate(ball,spawn.transform.position,Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }
}
