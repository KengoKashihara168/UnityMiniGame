﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player = null;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World!");

        if(player != null)
        {
            player.Initialize();
        }else
        {
            Debug.LogError("Playerがnullです");
        }
    }
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
