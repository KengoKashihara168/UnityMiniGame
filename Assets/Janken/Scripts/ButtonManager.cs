using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private Button[] handButtons = null;

    /// <summary>
    /// 初期化
    /// </summary>
    public void Initialize()
    {
        // ボタンの有効化
        EnableAllButton();
    }

    /// <summary>
    /// 全てのボタンを無効化
    /// </summary>
    public void DisableAllButton()
    {
        Debug.Log("ButtonManager : ボタンの無効化");
        foreach (var button in handButtons)
        {
            button.interactable = false;
        }
    }

    /// <summary>
    /// 全てのボタンを有効化
    /// </summary>
    public void EnableAllButton()
    {
        Debug.Log("ButtonManager : ボタンの有効化");
        foreach (var button in handButtons)
        {
            button.interactable = true;
        }
    }


}
