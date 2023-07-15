using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultController : MonoBehaviour
{
    [SerializeField] Text _resultText;
    void Start()
    {
        _resultText.text = $"�������v���C���[��{GameManager.LosePlayer}�ł�";
    }

    public void GameReset()
    {
        GameManager.Instance.ResetGame();
    }
}
