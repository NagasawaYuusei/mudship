using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [SerializeField, Header("�v���C���[�̗̑�")] int _playerHP;
    [SerializeField, Header("�h��P�\����")] float _respiteTime;
    [SerializeField, Header("�ʏ�U���̃_���[�W")] int _normalDamage = 1;
    [SerializeField, Header("�t�B�[�o�[���̃_���[�W")] int _feverDamage = 1; 
    [SerializeField, Header("�}�E�X�̕K�v�ړ���")] float _mouseMoveValue = 3.0f;
    [SerializeField, Header("���킷��CT")] float _coolTime = 0.76f;
    [SerializeField, Header("�t�B�[�o�[�̎���")] float _feverTime = 3.0f;
    [SerializeField] Sprite _attackSprite;
    [SerializeField] Sprite _deffenceSprite;

    public int PlayerHP => _playerHP;
    public float RespiteTime => _respiteTime;
    public int NormalDamage => _normalDamage;
    public Sprite AttackSprite => _attackSprite;
    public Sprite DeffenceSprite => _deffenceSprite;
    public float MouseValue => _mouseMoveValue;
    public float CoolTime => _coolTime;
    public float FeverTime => _feverTime;
    public int FeverDamage => _feverDamage;
}
