using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ResultController : MonoBehaviour
{
    [SerializeField] Text _resultText;
    void Start()
    {
        _resultText.text = $"負けたプレイヤーは{GameManager.LosePlayer}です";
    }

    public void GameReset()
    {
        GameManager.Instance.ResetGame();
    }
}
