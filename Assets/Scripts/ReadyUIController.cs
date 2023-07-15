using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadyUIController : MonoBehaviour
{
    [SerializeField] Text _currentPlayerText;
    void OnEnable()
    {
        _currentPlayerText.text = $"���݂̃v���C���[�̃^�[����{GameManager.CurrentPlayer}�ł�";
    }
}
