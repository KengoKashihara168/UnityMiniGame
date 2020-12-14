using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallSign : MonoBehaviour
{
    private readonly string[] CallText = { "じゃんけん...", "あいこで..." };

    [SerializeField] private Text callSignText = null;

    private bool isRestart = false;

    /// <summary>
    /// 初期化
    /// </summary>
    public void Initialize()
    {
        Debug.Log("CallSign : Initialize");
        callSignText.text = CallText[0];
        isRestart = false;
    }

    /// <summary>
    /// 開始合図の設定
    /// </summary>
    public void SetStartCall()
    {
        callSignText.text = CallText[0];
    }

    /// <summary>
    /// あいこの設定
    /// </summary>
    public void SetDrawCall()
    {
        callSignText.text = CallText[1];
    }

    /// <summary>
    /// 結果の設定
    /// </summary>
    /// <param name="result">true:再開　false:あいこ</param>
    public void SetResult(bool result)
    {
        isRestart = result;
    }

    public void SetCall()
    {
        if (isRestart)
        {
            callSignText.text = CallText[0];
        }
        else
        {
            callSignText.text = CallText[1];
        }
    }
}
