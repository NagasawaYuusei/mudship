using System;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] Player _myTurn;
    [SerializeField] PlayerState _state;
    [SerializeField] PlayerScript _enemyScript;
    int _maxHP;
    int _hp;

    public int HP => _hp;

    void Start()
    {
        _maxHP = _state.PlayerHP;
        _hp = _maxHP;
    }

    void Update()
    {
        if(GameManager.CurrentPlayer == _myTurn)
        {
            Attack();
            if (GameManager.InAttack)
            {
                GameManager.AttackTimer += Time.deltaTime;
                if(GameManager.AttackTimer >= _state.RespiteTime)
                {

                    GameManager.InAttack = false;
                    GameManager.AttackTimer = 0;
                    if(GameManager.Feint)
                    {
                        GameManager.Feint = false;
                        test.Instance.LogChange("ひっかからなかった");
                        GameManager.Instance.Ready();
                        return;
                    }
                    _enemyScript.TakeDamage(_state.NormalDamage);
                    Debug.Log("ダメージうけた");
                    test.Instance.LogChange("ダメージうけた");
                }
            }
        }
        else
        {
            Deffence();
        }

        
    }

    void Attack()
    {
        if(GameManager.InGameState == InGameState.Game && !GameManager.InAttack)
        {
            if(AttackInput())
            {
                InAttack();
            }

            if (FakeAttackInput())
            {
                InFakeAttack();
            }
        }
    }

    void Deffence()
    {
        if(GameManager.InGameState == InGameState.Game)
        {
            if(DeffenceInput())
            {
                InDeffence();
            }
        }
    }

    void InAttack()
    {
        Debug.Log("Attack");
        test.Instance.LogChange("こうげき！！");
        GameManager.InAttack = true;
    }

    void InFakeAttack()
    {
        Debug.Log("Attack");
        test.Instance.LogChange("フェイントこうげき！！");
        GameManager.InAttack = true;
        GameManager.Feint = true;
    }

    void InDeffence()
    {
        Debug.Log("Deffence");

        if(GameManager.InAttack)
        {
            if (GameManager.Feint)
            {
                TakeDamage(_state.FeintDamage);
                test.Instance.LogChange("ひっかかったな");
                GameManager.InAttack = false;
                GameManager.Feint = false;
                GameManager.AttackTimer = 0;
                GameManager.Instance.Ready();
                return;
            }
            GameManager.InAttack = false;
            GameManager.AttackTimer = 0;
            test.Instance.LogChange("かわした");
            GameManager.Instance.Ready();
        }
        else
        {
            test.Instance.LogChange("こうげきしてないよ");
        }
    }

    bool AttackInput()
    {
        if (Input.GetMouseButton(0))
        {
            if (Math.Abs(Input.GetAxis("Mouse X")) > 3)
            {
                return true;
            }
        }

        return false;
    }

    bool FakeAttackInput()
    {
        if (Input.GetMouseButton(1))
        {
            if (Math.Abs(Input.GetAxis("Mouse X")) > 3)
            {
                return true;
            }
        }

        return false;
    }

    bool DeffenceInput()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    public void TakeDamage(int damage)
    {
        _hp -= damage;
        if(_hp <= 0)
        {
            GameManager.Instance.OnGameOver(_myTurn);
        }
    }
}
