using UnityEngine;
using System;

/// <summary>
/// �Q�[���̊Ǘ��N���X
/// </summary>
public class GameManager
{
    #region �v���p�e�B
    /// <summary>
    /// GameManager�̃C���X�^���X
    /// </summary>
    public static GameManager Instance = new GameManager();
    public static Player CurrentPlayer;
    public static InGameState InGameState;
    public static Player LosePlayer;
    public static bool InAttack;
    public static bool Feint;
    public static float AttackTimer;
    #endregion

    #region �ϐ�
    bool _isPause;
    GameObject _readyPanel;
    #endregion

    //�R���X�g���N�^
    public GameManager()
    {
        Debug.Log("New GameManager");
    }

    #region �C�x���g

    /// <summary>
    /// �|�[�Y���̏�����o�^
    /// </summary>
    public event Action OnPause;
    /// <summary>
    /// �|�[�Y�������̏�����o�^
    /// </summary>
    public event Action OnResume;
    /// <summary>
    /// �Q�[���I�[�o�[���̃C�x���g
    /// </summary>
    public event Action OnGameOverEvent;
    /// <summary>
    /// �Q�[���I�����̃C�x���g
    /// </summary>
    public event Action OnGameEndEvent;
    /// <summary>
    /// �^�[�����̃C�x���g
    /// </summary>
    public event Action OnChangeTurn;

    #endregion

    /// <summary>
    /// �ϐ��̏����ݒ�
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
        Debug.Log($"���݂̃^�[����{CurrentPlayer}�ł�");
        _readyPanel?.SetActive(true);
    }

    public void Game()
    {
        InGameState = InGameState.Game;
        _readyPanel?.SetActive(false);
        Debug.Log("GameStart");
        test.Instance.LogChange("�����������Ă�");
    }

    /// <summary>
    /// �Q�[���I�[�o�[���ɌĂ�
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
    /// �A�b�v�f�[�g�ŌĂ�
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

    #region �R�[���o�b�N

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