using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private Button[] handButtons = null;

    public bool            isClick   { get; private set; }
    public Hand.JankenHand inputHand { get; private set; }

    /// <summary>
    /// 初期化
    /// </summary>
    public void Initialize()
    {
        // ボタンの有効化
        EnableAllButton();
        handButtons[0].onClick.AddListener(delegate { OnClick(Hand.JankenHand.Rock); });
        handButtons[1].onClick.AddListener(delegate { OnClick(Hand.JankenHand.Scissors); });
        handButtons[2].onClick.AddListener(delegate { OnClick(Hand.JankenHand.paper); });

        isClick = false;
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

        isClick = false;
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

    /// <summary>
    /// ボタンがクリックされた時の処理
    /// </summary>
    /// <param name="hand">入力された手</param>
    private void OnClick(Hand.JankenHand hand)
    {
        Debug.Log("ButtonManager : onClick hand = " + hand);
        isClick = true;
        this.inputHand = hand;
    }


}
