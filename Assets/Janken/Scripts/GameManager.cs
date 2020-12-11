using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static readonly int MaxHandNum = 3;

    [SerializeField] private Player player = null;
    [SerializeField] private Opponent opponent = null;
    [SerializeField] private CallSign callSign = null;

    private bool isStop = false;

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
        player.Initialize();
        opponent.Initialize();
        callSign.Initialize();
        isStop = false;
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
            int result = JudgeResult(player.GetHand(), opponent.GetHand());
            ReflectResult(result);
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
        switch (result)
        {
            case 0:
                // あいこ
                Initialize();
                callSign.SetDrawCall();
                break;
            case 1:
                // 勝ち
                break;
            case 2:
                // 負け
                break;
        }
    }
}
