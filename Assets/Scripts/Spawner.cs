using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    private float timeBtwSpawns;
    public float minTime;
    public float maxTime;
    public GameObject[] itemList;

    private void Start ()
    {
        timeBtwSpawns = Random.Range(minTime, maxTime);
    }

    private void Update ()
    {
        if (timeBtwSpawns <= 0)
        {
            int rand = Random.Range (0, itemList.Length);
            Instantiate (itemList[rand], transform.position, Quaternion.identity);
            timeBtwSpawns = Random.Range(minTime, maxTime);
        } else {
            timeBtwSpawns -= Time.deltaTime;
        }
    }
}