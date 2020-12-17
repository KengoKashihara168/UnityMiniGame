using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Text pointText = null;

    private Point point = null;
    private Hand  hand  = null;
    public bool isLose { get; private set; }

    /// <summary>
    /// 初期化
    /// </summary>
    public void Initialize()
    {
        Debug.Log("Player : Initialize");
        point = pointText.GetComponent<Point>();
        point.Initialize();

        hand = GetComponent<Hand>();
        hand.Initialize();
        isLose = false;
    }

    /// <summary>
    /// 更新
    /// </summary>
    public void UpdateHand()
    {
        hand.UpdateHand();
    }

    /// <summary>
    /// 手の設定
    /// </summary>
    /// <param name="jankenHand">ジャンケンの手</param>
    public void SetHand(Hand.JankenHand jankenHand)
    {
        Debug.Log("Player : " + jankenHand);
        hand.SetHand(jankenHand);
    }

    /// <summary>
    /// 負け
    /// </summary>
    public void Lose()
    {
        Debug.Log("Player : lose");
        // 減点
        isLose = point.SubPoint();
    }
}
