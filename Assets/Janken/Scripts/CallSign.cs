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
            Debug.Log("CallSign : じゃんけん...");
        }
        else
        {
            callSignText.text = CallText[1];
            Debug.Log("CallSign : あいこで...");
        }
    }
}
