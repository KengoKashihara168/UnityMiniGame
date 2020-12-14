using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Text pointText = null;

    private int handNum = 0; // 手を示す数字
    private Point point = null;

    /// <summary>
    /// 初期化
    /// </summary>
    public void Initialize()
    {
        Debug.Log("Player : Initialize");
        point = pointText.GetComponent<Point>();
        point.Initialize();
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

    /// <summary>
    /// 手の取得
    /// </summary>
    /// <returns>手の数字</returns>
    public int GetHand()
    {
        return handNum;
    }

    /// <summary>
    /// 負け
    /// </summary>
    public void Lose()
    {
        Debug.Log("Player : lose");
        // 減点
        point.SubPoint();
    }
}
