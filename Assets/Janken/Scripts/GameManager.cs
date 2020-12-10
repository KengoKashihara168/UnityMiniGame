using System.Collections;
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
    [SerializeField] private HandManager handManager = null;
    [SerializeField] private Player player = null;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World!");

        handManager.Initialize();
        player.Initialize();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
