using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ResultScene : isPlayerWinFlag = " + GameManager.GetPlayerWinFlag());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
