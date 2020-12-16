using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static readonly int MaxHandNum = 3;
    private readonly float StopTime = 2.0f;

    [SerializeField] private ButtonManager buttonManager = null;
    [SerializeField] private Player player = null;
    [SerializeField] private Opponent opponent = null;
    [SerializeField] private CallSign callSign = null;

    private bool isStop = false;
    private float stoppedTime = 0.0f;

    public delegate void GameEndDelegate(bool isWin);
    private GameEndDelegate gameEnd;

    private static bool isPlayerWin = false;

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
        isPlayerWin = false;

        var gm = gameObject.GetComponent<GameManager>();
        gameEnd = gm.ChangeScene;
    }

    // Update is called once per frame
    void Update()
    {
        // 対戦相手の手を更新
        UpdateOpponentHand();
        if (isStop)
        {
            // 停止時間の更新
            UpdateStopTime();
        }
    }

    /// <summary>
    /// プレイヤーの勝利フラグを取得
    /// </summary>
    /// <returns>プレイヤーの勝利フラグ</returns>
    public static bool GetPlayerWinFlag()
    {
        return isPlayerWin;
    }

    /// <summary>
    /// 手を決めるボタンが押された時のイベントハンドラ
    /// </summary>
    /// <param name="handNum">手の数字</param>
    public void OnHandButton(int handNum)
    {
        Debug.Assert(handNum >= 0 && handNum <= MaxHandNum - 1, "入力値が不正です");
        // 手を設定
        SetHand(handNum);

        // 結果を設定
        SetResult();
    }

    /// <summary>
    /// 対戦相手の手を更新
    /// </summary>
    private void UpdateOpponentHand()
    {
        if (isStop) return;
        opponent.UpdateHand();
    }

    /// <summary>
    /// 停止時間の更新
    /// </summary>
    private void UpdateStopTime()
    {
        if (stoppedTime >= StopTime)
        {
            SwitchGame();
        }
        else
        {
            stoppedTime += Time.deltaTime;
        }
    }

    /// <summary>
    /// 手の設定
    /// </summary>
    /// <param name="handNum">手の数字</param>
    private void SetHand(int handNum)
    {
        // プレイヤー
        player.SetHand(handNum);
        // 対戦相手
        opponent.DecideHand();
    }

    /// <summary>
    /// 結果の設定
    /// </summary>
    private void SetResult()
    {
        // 結果の判定
        int result = JudgeResult(player.GetHand(), opponent.GetHand());
        // 結果の反映
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
        bool isRestart = true;

        // 結果の分岐
        switch (result)
        {
            case 0:
                // あいこ
                isRestart = false;
                Debug.Log("GameManager : あいこ");
                break;
            case 1:
                // プレイヤーの負け
                player.Lose();
                Debug.Log("GameManager : 負け");
                break;
            case 2:
                // プレイヤーの勝ち
                opponent.Lose();
                Debug.Log("GameManager : 勝ち");
                break;
        }

        callSign.SetResult(isRestart);
    }

    /// <summary>
    /// ゲーム進行の切り替え
    /// </summary>
    private void SwitchGame()
    {
        player.DeterminePoints(gameEnd);
        opponent.DeterminePoints(gameEnd);

        // 再開
        Restart();
    }

    /// <summary>
    /// 再開
    /// </summary>
    private void Restart()
    {
        buttonManager.EnableAllButton();
        callSign.SetCall();
        stoppedTime = 0.0f;
        isStop = false;
    }

    /// <summary>
    /// リザルトシーンへ遷移
    /// </summary>
    /// <param name="isWin">true:プレイヤー勝利　false:プレイヤー敗北</param>
    private void ChangeScene(bool isWin)
    {
        isPlayerWin = isWin;
        SceneManager.LoadScene("JankenResult");
    }
}
