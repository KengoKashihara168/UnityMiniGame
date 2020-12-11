using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallSign : MonoBehaviour
{
    private readonly string[] CallText = { "じゃんけん...", "あいこで..." };

    [SerializeField] private Text callSignText = null;

    /// <summary>
    /// 初期化
    /// </summary>
    public void Initialize()
    {
        Debug.Log("CallSign : Initialize");
        callSignText.text = CallText[0];
    }

    /// <summary>
    /// あいこの設定
    /// </summary>
    public void SetDrawCall()
    {
        callSignText.text = CallText[1];
    }
}
