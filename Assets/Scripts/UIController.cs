using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] PlayerScript _player1;
    [SerializeField] PlayerScript _player2;
    [SerializeField] Text _turnText;
    [SerializeField] Slider _player1HPSlider;
    [SerializeField] Slider _player2HPSlider;
    [SerializeField] PlayerState _state;

    void Start()
    {
        _player1HPSlider.maxValue = _state.PlayerHP;
        _player2HPSlider.maxValue = _state.PlayerHP;
    }

    void Update()
    {
        _turnText.text = $"Turn;Player{(int)GameManager.CurrentPlayer + 1}";
        _player1HPSlider.value = _player1.HP;
        _player2HPSlider.value = _player2.HP;
    }
}
