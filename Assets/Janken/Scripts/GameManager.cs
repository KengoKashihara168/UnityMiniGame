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
    [SerializeField] private Player opponent = null;
    [SerializeField] private CallSign callSign = null;

    private bool isStop = false;
    private float stoppedTime = 0.0f;

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
    }

    // Update is called once per frame
    void Update()
    {
        // 対戦相手の手を更新
        UpdateHand();

        if (buttonManager.isClick)
        {
            Debug.Log("GameManager : OnClick Button");
            StartJanken();
        }

        if (isStop)
        {
            // 停止時間の更新
            UpdateStopTime();
            if (stoppedTime >= StopTime)
            {
                // 再開
                Restart();
            }
        }
    }

    /// <summary>
    /// 対戦相手の手を更新
    /// </summary>
    private void UpdateHand()
    {
        if (isStop) return;
        player.UpdateHand();
        opponent.UpdateHand();
    }

    /// <summary>
    /// ジャンケンの開始
    /// </summary>
    private void StartJanken()
    {
        var input = buttonManager.inputHand;
        var random = Hand.GetRandomHand();
        SetHand(input, random);
        SetResult(input, random);
        StopGame();
    }

    /// <summary>
    /// 手の設定
    /// </summary>
    /// <param name="input">入力された手</param>
    /// <param name="random">ランダムな手</param>
    private void SetHand(Hand.JankenHand input, Hand.JankenHand random)
    {
        player.SetHand(input);
        opponent.SetHand(random);
    }

    /// <summary>
    /// 結果の設定
    /// </summary>
    /// <param name="input">入力された手</param>
    /// <param name="randam">ランダムな手</param>
    private void SetResult(Hand.JankenHand input, Hand.JankenHand randam)
    {
        // 結果の判定
        int result = JudgeResult(input, randam);
        // 結果の反映
        ReflectResult(result);
    }

    /// <summary>
    /// 結果の判定
    /// </summary>
    /// <param name="input">入力された手</param>
    /// <param name="randam">ランダムな手</param>
    /// <returns></returns>
    private int JudgeResult(Hand.JankenHand input, Hand.JankenHand randam)
    {
        int result = -1;
        int inputNum = Hand.ConvertHandState(input);
        int randomNum = Hand.ConvertHandState(randam);

        result = (inputNum - randomNum + 3) % 3;
        Debug.Log("GameManager : result = " + result);

        return result;
    }

    /// <summary>
    /// 結果の反映
    /// </summary>
    /// <param name="result">ジャンケンの結果</param>
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
    /// ゲームの一時停止
    /// </summary>
    private void StopGame()
    {
        isStop = true;
        buttonManager.DisableAllButton();
    }

    /// <summary>
    /// 停止時間の更新
    /// </summary>
    private void UpdateStopTime()
    {
        if (stoppedTime < StopTime)
        {
            stoppedTime += Time.deltaTime;
        }
    }

    /// <summary>
    /// 再開
    /// </summary>
    private void Restart()
    {
        if (player.isLose) PlayerLose();
        if (opponent.isLose) OpponentLose();
        buttonManager.EnableAllButton();
        callSign.SetCall();
        stoppedTime = 0.0f;
        isStop = false;
    }

    /// <summary>
    /// プレイヤーが敗北時に呼ばれる
    /// </summary>
    private void PlayerLose()
    {
        isPlayerWin = false;
        SceneManager.LoadScene("JankenResult");
    }

    /// <summary>
    /// 対戦相手が敗北時に呼ばれる
    /// </summary>
    private void OpponentLose()
    {
        isPlayerWin = true;
        SceneManager.LoadScene("JankenResult");
    }

    /// <summary>
    /// プレイヤーの勝利フラグを取得
    /// </summary>
    /// <returns>プレイヤーの勝利フラグ</returns>
    public static bool GetPlayerWinFlag()
    {
        return isPlayerWin;
    }
}
