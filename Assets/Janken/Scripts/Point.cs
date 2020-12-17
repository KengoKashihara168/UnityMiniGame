using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Point : MonoBehaviour
{
    private readonly int MaxPoint = 3;

    private int  point     = 0;
    private Text pointText = null;

    /// <summary>
    /// 初期化
    /// </summary>
    public void Initialize()
    {
        pointText      = GetComponent<Text>();
        point          = MaxPoint;
        pointText.text = point.ToString();
    }

    /// <summary>
    /// ポイント加算
    /// </summary>
    public void AddPoint()
    {
        if (point >= MaxPoint) return;
        point++;
        pointText.text = point.ToString();
        Debug.Log("Point : Add Point");
    }

    /// <summary>
    /// ポイントの減算
    /// </summary>
    /// <returns>true:ポイントが０になった / false:ポイントが０ではない</returns>
    public bool SubPoint()
    {
        point--;
        pointText.text = point.ToString();
        if (point <= 0) return true;
        return false;
    }
}
