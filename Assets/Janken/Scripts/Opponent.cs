using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Opponent : MonoBehaviour
{
    [SerializeField] private Text pointText = null;

    private Hand hand = null;
    private Point point = null;

    /// <summary>
    /// 初期化
    /// </summary>
    public void Initialize()
    {
        Debug.Log("Opponent : Initialize");
        hand = GetComponent<Hand>();
        hand.Initialize();
        point = pointText.GetComponent<Point>();
        point.Initialize();
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
        Debug.Log("Opponent : " + jankenHand);
        hand.SetHand(jankenHand);
    }

    /// <summary>
    /// 負け
    /// </summary>
    public void Lose()
    {
        Debug.Log("Opponent : lose");
        // 減点
        point.SubPoint();
    }

    /// <summary>
    /// ポイントが０になったか判定
    /// </summary>
    /// <param name="gameEnd">０になった場合に呼び出す関数</param>
    public void DeterminePoints(GameManager.GameEndDelegate gameEnd)
    {
        if (point.GetPoint() <= 0)
        {
            gameEnd();
        }
    }
}
