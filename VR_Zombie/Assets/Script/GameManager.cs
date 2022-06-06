using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject zombie;

    private void Start()
    {
        InvokeRepeating("CreateZombie",1.0f,2.0f); //1초 기다리고 2초마다 함수 호출
    }

    void CreateZombie()
    {
        Vector3 positionValue = new Vector3(Random.Range(-8f, 8f), 0.5f, Random.Range(28.0f, 18.0f));
        GameObject temp = Instantiate(zombie, positionValue, transform.rotation);
    }
}
