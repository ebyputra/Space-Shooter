using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;

    public GameObject playerPrefab;
    public GameObject activePlayer;
    internal bool isPlaying;

    private void Awake()
    { 
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }
   
    void Start()
    {
        spawnPlayer();
    }

    public static GameManager GetInstance()
    {
        return instance;
    }

    private void spawnPlayer()
    {
        activePlayer = Instantiate(playerPrefab);
    }

    public Vector3 getPlayerPosition()
    {
        if (activePlayer != null)
        {
            return activePlayer.transform.position;
        }
        return Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
