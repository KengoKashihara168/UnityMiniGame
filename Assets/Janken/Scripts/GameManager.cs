using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static readonly int MaxHandNum = 3;
    [SerializeField] private float StopTime = 0.0f;

    [SerializeField] private ButtonManager buttonManager = null;
    [SerializeField] private Player player = null;
    [SerializeField] private Opponent opponent = null;
    [SerializeField] private CallSign callSign = null;

    private bool isStop = false;
    private float stoppedTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("GameManager : Start");
        Initialize();
    }

    /// <summary>
    /// 初期化
    /// </summary>
    private void Initialize()
    {
        Debug.Log("GameManager : Initialize");
        buttonManager.Initialize();
        player.Initialize();
        opponent.Initialize();
        callSign.Initialize();
        isStop = false;
        stoppedTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStop)
        {
            opponent.UpdateHand();
        }
        else
        {
            if (stoppedTime >= StopTime)
            {
                buttonManager.EnableAllButton();
                stoppedTime = 0.0f;
                isStop = false;
            }
            else
            {
                stoppedTime += Time.deltaTime;
                //Debug.Log("GameManager : stoppedTime = " + stoppedTime);
            }
        }
    }

    /// <summary>
    /// 手を決めるボタンが押された時のイベントハンドラ
    /// </summary>
    /// <param name="handNum">手の数字</param>
    public void OnHandButton(int handNum)
    {
        Debug.Assert(handNum >= 0 && handNum <= MaxHandNum - 1, "入力値が不正です");
        // 手を設定
        player.SetHand(handNum);
        opponent.DecideHand();

        // 結果を設定
        int result = JudgeResult(player.GetHand(), opponent.GetHand());
        ReflectResult(result);

        isStop = true;
    }

    /// <summary>
    /// 結果判定
    /// </summary>
    /// <param name="playerNum">プレイヤーの手の数字</param>
    /// <param name="opponentNum">対戦相手の手の数字</param>
    /// <returns></returns>
    private int JudgeResult(int playerNum, int opponentNum)
    {
        int result = -1;
        result = (playerNum - opponentNum + 3) % 3;
        Debug.Log("GameManager : result = " + result);

        return result;
    }

    // 結果の反映
    private void ReflectResult(int result)
    {
        Debug.Assert(result >= 0 && result <= 2, "結果の数値が間違っています");
        buttonManager.DisableAllButton();
        switch (result)
        {
            case 0:
                // あいこ
                callSign.SetResult(false);
                break;
            case 1:
                // プレイヤーの負け
                player.Lose();
                callSign.SetResult(true);
                break;
            case 2:
                // プレイヤーの勝ち
                opponent.Lose();
                callSign.SetResult(true);
                break;
        }
    }
}
