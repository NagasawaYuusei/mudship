using UnityEngine;
using System;

/// <summary>
/// ゲームの管理クラス
/// </summary>
public class GameManager
{
    #region プロパティ
    /// <summary>
    /// GameManagerのインスタンス
    /// </summary>
    public static GameManager Instance = new GameManager();
    public static Player CurrentPlayer;
    public static InGameState InGameState;
    public static Player LosePlayer;
    public static bool InAttack;
    public static bool Feint;
    public static float AttackTimer;
    #endregion

    #region 変数
    bool _isPause;
    GameObject _readyPanel;
    #endregion

    //コンストラクタ
    public GameManager()
    {
        Debug.Log("New GameManager");
    }

    #region イベント

    /// <summary>
    /// ポーズ時の処理を登録
    /// </summary>
    public event Action OnPause;
    /// <summary>
    /// ポーズ解除時の処理を登録
    /// </summary>
    public event Action OnResume;
    /// <summary>
    /// ゲームオーバー時のイベント
    /// </summary>
    public event Action OnGameOverEvent;
    /// <summary>
    /// ゲーム終了時のイベント
    /// </summary>
    public event Action OnGameEndEvent;
    /// <summary>
    /// ターン交代のイベント
    /// </summary>
    public event Action OnChangeTurn;

    #endregion

    /// <summary>
    /// 変数の初期設定
    /// </summary>
    /// <param name="attachment"></param>
    public void OnSetup(GameManagerAttachment attachment)
    {
        int num = UnityEngine.Random.Range(0, 2);
        CurrentPlayer = (Player)num;
        _readyPanel = attachment.ReadyPanel;
        Ready();
    }

    public void Ready()
    {
        InGameState = InGameState.Ready;
        CurrentPlayer = (Player)(((int)CurrentPlayer + 1) % 2);
        Debug.Log($"現在のターンは{CurrentPlayer}です");
        _readyPanel?.SetActive(true);
    }

    public void Game()
    {
        InGameState = InGameState.Game;
        _readyPanel?.SetActive(false);
        Debug.Log("GameStart");
        test.Instance.LogChange("こうげきしてね");
    }

    /// <summary>
    /// ゲームオーバー時に呼ぶ
    /// </summary>
    public void OnGameOver(Player player)
    {
        LosePlayer = player;
        OnGameOverEvent?.Invoke();
        Debug.Log("OnGameOver");
        SceneChangeController.LoadScene("ResultScene");
    }

    public void ResetGame()
    {
        LosePlayer = 0;
    }

    /// <summary>
    /// アップデートで呼ぶ
    /// </summary>
    void OnUpdate()
    {
        if (InGameState == InGameState.Ready)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Game();
            }
        }
    }

    #region コールバック

    public void SetupUpdateCallback(GameManagerAttachment attachment)
    {
        attachment.SetupCallBack(OnUpdate);
    }

    #endregion
}

public enum InGameState
{
    None,
    Ready,
    Game
}

public enum Player
{
    Player1,
    Player2,
}