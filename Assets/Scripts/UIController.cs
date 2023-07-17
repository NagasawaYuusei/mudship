using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] PlayerScript _player1;
    [SerializeField] PlayerScript _player2;
    [SerializeField] Image _turnImage;
    [SerializeField] Slider _player1HPSlider;
    [SerializeField] Slider _player2HPSlider;
    [SerializeField] PlayerState _state;
    [SerializeField] Sprite _player1Sp;
    [SerializeField] Sprite _player2Sp;

    void Start()
    {
        _player1HPSlider.maxValue = _state.PlayerHP;
        _player2HPSlider.maxValue = _state.PlayerHP;
    }

    void Update()
    {
        if(GameManager.CurrentPlayer == Player.Player1)
        {
            _turnImage.sprite = _player1Sp;
        }
        else
        {
            _turnImage.sprite = _player2Sp;
        }
        _player1HPSlider.value = _player1.HP;
        _player2HPSlider.value = _player2.HP;
    }
}
