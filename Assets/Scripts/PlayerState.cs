using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [SerializeField, Header("�v���C���[�̗̑�")] int _playerHP;
    [SerializeField, Header("�h��P�\����")] float _respiteTime;
    [SerializeField, Header("�ʏ�U���̃_���[�W")] int _normalDamage = 1;
    [SerializeField, Header("�t�F�C���g�U���̃_���[�W")] int _feintDamage = 2;

    public int PlayerHP => _playerHP;
    public float RespiteTime => _respiteTime;
    public int NormalDamage => _normalDamage;
    public int FeintDamage => _feintDamage;
}
