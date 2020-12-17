using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    // ジャンケンの手
    public enum JankenHand
    {
        Rock, // グー
        Scissors, // チョキ
        paper, // パー
    }

    private readonly string[] HandTexts  = { "グー", "チョキ", "パー" };
    private readonly float    ChangeTime = 0.1f;

    [SerializeField] private Text handText = null;

    private int   handNum     = 0;
    private float changeCount = 0.0f;

    /// <summary>
    /// 初期化
    /// </summary>
    public void Initialize()
    {
        Debug.Log("Hand : Initialize");
        handNum     = 0;
        changeCount = 0.0f;
    }

    /// <summary>
    /// 手の更新
    /// </summary>
    public void UpdateHand()
    {
        changeCount += Time.deltaTime;
        if (changeCount < ChangeTime) return;

        handNum = (handNum + 1) % 3;

        handText.text = HandTexts[handNum];
        changeCount   = 0.0f;
    }

    /// <summary>
    /// 手の設定
    /// </summary>
    /// <param name="hand">手</param>
    public void SetHand(JankenHand hand)
    {
        int num       = ConvertHandState(hand);
        handText.text = HandTexts[num];
    }

    /// <summary>
    /// ランダムなジャンケンの手を取得する
    /// </summary>
    /// <returns></returns>
    public static JankenHand GetRandomHand()
    {
        int rand          = Random.Range(0, GameManager.MaxHandNum);
        JankenHand[] hand = { JankenHand.Rock, JankenHand.Scissors, JankenHand.paper };

        return hand[rand];
    }

    /// <summary>
    /// ジャンケンの手を数値に変換
    /// </summary>
    /// <param name="hand">ジャンケンの手</param>
    /// <returns>手の数値</returns>
    public static int ConvertHandState(JankenHand hand)
    {
        int num = -1;

        switch (hand)
        {
            case JankenHand.Rock:
                num = 0;
                break;
            case JankenHand.Scissors:
                num = 1;
                break;
            case JankenHand.paper:
                num = 2;
                break;
        }

        return num;
    }
}
