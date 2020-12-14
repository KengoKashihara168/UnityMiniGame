using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Opponent : MonoBehaviour
{
    private readonly string[] HandTexts = { "グー", "チョキ", "パー" };

    [SerializeField] private Text handText = null;
    [SerializeField] private float changeTime = 0.0f;
    [SerializeField] private Text pointText = null;

    private int handNum = 0;
    private float changeCount = 0.0f;
    private Point point = null;

    /// <summary>
    /// 初期化
    /// </summary>
    public void Initialize()
    {
        Debug.Log("Opponent : Initialize");
        handText.text = HandTexts[0];
        point = pointText.GetComponent<Point>();
        point.Initialize();
    }

    /// <summary>
    /// 更新
    /// </summary>
    public void UpdateHand()
    {
        changeCount += Time.deltaTime;
        if (changeCount < changeTime) return;

        handNum = (handNum + 1) % 3;
        //Debug.Log("Opponent : handNum = " + handNum);

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

    /// <summary>
    /// 結果の設定
    /// </summary>
    /// <param name="result">true:勝ち/false:負け</param>
    public void SetResult(bool result)
    {
        if (result)
        {
            // 加点
            point.AddPoint();
            Debug.Log("Player : Win");
        }
        else
        {
            // 減点
            point.SubPoint();
            Debug.Log("Player : lose");
        }
    }
}
