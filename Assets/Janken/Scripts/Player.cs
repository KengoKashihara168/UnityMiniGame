using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int handNum = 0; // 手を示す数字

    /// <summary>
    /// 初期化
    /// </summary>
    public void Initialize()
    {
        Debug.Log("Player : Initialize");
    }

    /// <summary>
    /// プレイヤーの手を設定
    /// </summary>
    /// <param name="hand">入力された手</param>
    public void SetHand(int hand)
    {
        Debug.Log("Player : Hand = " + hand);
        handNum = hand;
    }
}
