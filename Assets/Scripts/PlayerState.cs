using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [SerializeField, Header("プレイヤーの体力")] int _playerHP;
    [SerializeField, Header("防御猶予時間")] float _respiteTime;
    [SerializeField, Header("通常攻撃のダメージ")] int _normalDamage = 1;
    [SerializeField, Header("フェイント攻撃のダメージ")] int _feintDamage = 2;

    public int PlayerHP => _playerHP;
    public float RespiteTime => _respiteTime;
    public int NormalDamage => _normalDamage;
    public int FeintDamage => _feintDamage;
}
