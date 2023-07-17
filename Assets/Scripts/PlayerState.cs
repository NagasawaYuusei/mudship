using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [SerializeField, Header("プレイヤーの体力")] int _playerHP;
    [SerializeField, Header("防御猶予時間")] float _respiteTime;
    [SerializeField, Header("通常攻撃のダメージ")] int _normalDamage = 1;
    [SerializeField, Header("フィーバー時のダメージ")] int _feverDamage = 1; 
    [SerializeField, Header("マウスの必要移動量")] float _mouseMoveValue = 3.0f;
    [SerializeField, Header("かわすのCT")] float _coolTime = 0.76f;
    [SerializeField, Header("フィーバーの時間")] float _feverTime = 3.0f;
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
