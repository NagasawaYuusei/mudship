using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] PlayerScript _player1;
    [SerializeField] PlayerScript _player2;
    [SerializeField] Text _turnText;
    [SerializeField] Text _player1HPText;
    [SerializeField] Text _player2HPText;
    void Update()
    {
        _turnText.text = $"Turn;Player{(int)GameManager.CurrentPlayer + 1}";
        _player1HPText.text = $"1HP:{_player1.HP}";
        _player2HPText.text = $"2HP:{_player2.HP}";
    }
}
