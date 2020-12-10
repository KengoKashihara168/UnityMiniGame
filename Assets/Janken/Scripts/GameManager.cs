﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HandType
{
    Rock,       // グー
    Scissors,   // チョキ
    Paper,      // パー
}

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player = null;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World!");

        player.Initialize();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnHandButton(int handNum)
    {
        Debug.Assert(handNum >= 0 && handNum <= 2, "入力値が不正です");
        player.SetHand(handNum);
    }
}
