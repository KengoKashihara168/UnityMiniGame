using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static readonly int MaxHandNum = 3;

    [SerializeField] private Player player = null;
    [SerializeField] private Opponent opponent = null;

    private bool isStop = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("GameManager : Start");

        player.Initialize();
        opponent.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStop)
        {
            opponent.UpdateHand();
        }
    }

    /// <summary>
    /// 手を決めるボタンが押された時のイベントハンドラ
    /// </summary>
    /// <param name="handNum">手の数字</param>
    public void OnHandButton(int handNum)
    {
        Debug.Assert(handNum >= 0 && handNum <= 2, "入力値が不正です");
        // 手を設定
        player.SetHand(handNum);
        opponent.DecideHand();

        isStop = true;
    }
}
