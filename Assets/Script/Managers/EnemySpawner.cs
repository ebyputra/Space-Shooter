using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemysmallprefab;
    public GameObject enemyMediumprefab;
    public GameObject enemyBigprefab;


    void Start()
    {
        spawn();
    }

    public void spawn()
    {
      //  Vector3 newPosition = transform.position;
     //   newPosition.x = Random.Range(-7.5f, 7.5f);

        Instantiate(enemysmallprefab, transform.position, transform.rotation);
    }

    void Update()
    {
        
    }
}
