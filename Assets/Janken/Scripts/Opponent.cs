using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Opponent : MonoBehaviour
{
    private readonly string[] HandTexts = { "グー", "チョキ", "パー" };

    [SerializeField] private Text handText = null;
    [SerializeField] private float changeTime = 0.0f;
    private int handNum = 0;
    private float changeCount = 0.0f;

    /// <summary>
    /// 初期化
    /// </summary>
    public void Initialize()
    {
        Debug.Log("Opponent : Initialize");
        handText.text = HandTexts[0];
    }

    /// <summary>
    /// 更新
    /// </summary>
    public void UpdateHand()
    {
        changeCount += Time.deltaTime;
        if (changeCount < changeTime) return;

        handNum = (handNum + 1) % 3;
        Debug.Log("Opponent : handNum = " + handNum);

        handText.text = HandTexts[handNum];
        changeCount = 0.0f;
    }

    /// <summary>
    /// 手を決定
    /// </summary>
    public void DecideHand()
    {
        int rand = Random.Range(0, GameManager.MaxHandNum);
        Debug.Log("Opponent : rand = " + rand);

        handNum = rand;
        handText.text = HandTexts[rand];
    }

    /// <summary>
    /// 手の取得
    /// </summary>
    /// <returns>手の数字</returns>
    public int GetHand()
    {
        return handNum;
    }
}
