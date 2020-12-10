using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Opponent : MonoBehaviour
{
    [SerializeField] private Text handText = null;
    private int handNum = 0;
    private readonly string[] HandTexts = { "グー", "チョキ", "パー" };

    /// <summary>
    /// 初期化
    /// </summary>
    public void Initialize()
    {
        Debug.Log("Opponent : Initialize");
        handText.text = HandTexts[0];
    }

    public void UpdateHand()
    {
        handNum = (handNum + 1) % 3;
        Debug.Log("Opponent : handNum = " + handNum);

        handText.text = HandTexts[handNum];
    }
}
