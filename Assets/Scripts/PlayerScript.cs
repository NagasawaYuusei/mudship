using System;
using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] Player _myTurn;
    [SerializeField] PlayerState _state;
    [SerializeField] PlayerScript _enemyScript;
    [SerializeField] GameObject[] _go;
    [SerializeField] Transform _deffenceTransform;
    [SerializeField] SpriteRenderer _attackSp;
    [SerializeField] GameObject[] _hummmers;
    [SerializeField] GameObject _count;
    [SerializeField] GameObject[] _counts;
    int _maxHP;
    int _hp;
    bool _isAttack;
    bool _fever;
    float _feverTimer;
    Animator _animator;
    Vector3 _firstPos;
    int _feverCount;

    public int HP => _hp;

    void Start()
    {
        _maxHP = _state.PlayerHP;
        _hp = _maxHP;
        _animator = GetComponent<Animator>();
        _firstPos = _deffenceTransform.position;
    }

    void Update()
    {
        if(_fever)
        {
            Fever();
            return;
        }

        _animator.SetBool("IsAttack", _isAttack);
        if (GameManager.CurrentPlayer == _myTurn)
        {
            Attack();
            if (GameManager.InAttack)
            {
                GameManager.AttackTimer += Time.deltaTime;
                if(GameManager.AttackTimer >= _state.RespiteTime)
                {
                    GameManager.InAttack = false;
                    GameManager.AttackTimer = 0;
                    if (GameManager.Feint)
                    {
                        GameManager.Feint = false;
                        GameAnim.Instance.PlayAnim("FakeMiss");
                        GameManager.InGameState = InGameState.None;
                        StartCoroutine(SuccesDeffence(1.5f));
                        return;
                    }
                    GameManager.InGameState = InGameState.None;
                    AttackEffect();
                    _enemyScript.TakeDamage(_state.NormalDamage);
                    Debug.Log("ƒ_ƒ[ƒW‚¤‚¯‚½");
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
        _go[0].SetActive(true);
        _go[1].SetActive(false);
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
        _go[1].SetActive(true);
        _go[0].SetActive(false);
        if(GameManager.InGameState == InGameState.Game)
        {
            if(DeffenceInput() && !_isAttack)
            {
                InDeffence();
            }
        }
    }

    void Fever()
    {
        Debug.Log("Fever’†");
        if(Input.GetMouseButtonDown(0))
        {
            _feverCount++;
            if(_feverCount % 2 == 0)
            {
                _animator.Play("FeverAttack1");
            }
            else
            {
                _animator.Play("FeverAttack2");
            }
            _enemyScript.TakeDamage(_state.FeverDamage);
        }
        _feverTimer += Time.deltaTime;

        if(_feverTimer > 0)
        {
            _counts[0].SetActive(true);
        }
        if(_feverTimer > 1)
        {
            _counts[0].SetActive(false);
            _counts[1].SetActive(true);
        }
        if(_feverTimer > 2)
        {
            _counts[1].SetActive(false);
            _counts[2].SetActive(true);
        }
        if(_feverTimer >= 3)
        {
            _counts[2].SetActive(false);
            _count.SetActive(false);
            _hummmers[0].SetActive(false);
            _hummmers[1].SetActive(false);
            GameAnim.Instance.ChangeFeverState(false);
            _fever = false;
            _enemyScript.ChangeTransform();
            _attackSp.enabled = true;
            StartCoroutine(EndFiever());
        }
    }

    IEnumerator EndFiever()
    {
        GameAnim.Instance.PlayAnim("EndFever");
        yield return new WaitForSeconds(1);
        GameManager.Instance.Ready();
    }

    void InAttack()
    {
        Debug.Log("Attack");
        _animator.Play("Attack");
        GameManager.InAttack = true;
    }

    void InFakeAttack()
    {
        Debug.Log("Attack");
        _animator.Play("FakeAttack");
        GameManager.InAttack = true;
        GameManager.Feint = true;
    }

    void InDeffence()
    {
        Debug.Log("Deffence");

        if(GameManager.InAttack)
        {
            GameManager.InAttack = false;
            if (GameManager.Feint)
            {
                GameManager.InAttack = false;
                GameManager.Feint = false;
                GameManager.AttackTimer = 0;
                GameAnim.Instance.PlayAnim("FakeAttack");
                StartCoroutine(WaitFever());
                //GameManager.Instance.Ready();
                return;
            }
            GameManager.InAttack = false;
            GameManager.AttackTimer = 0;
            _animator.Play("Deffence");
            GameAnim.Instance.PlayAnim("SuccesDefence");
            StartCoroutine(SuccesDeffence(1.5f));
        }
        else
        {

            _isAttack = true;
            _animator.Play("Deffence");
            StartCoroutine(CoolTime(_state.CoolTime));
        }
    }

    IEnumerator WaitFever()
    {
        yield return new WaitForSeconds(1.5f);

        StartCoroutine(_enemyScript.ReadyFever(_deffenceTransform));
    }

    public IEnumerator ReadyFever(Transform tsm)
    {
        tsm.position = new Vector3(0, -0.6f);
        
        _attackSp.enabled = false;

        yield return new WaitForSeconds(0.5f);

        GameAnim.Instance.ChangeFeverState(true);
        GameAnim.Instance.PlayAnim("Fever");
        _hummmers[0].SetActive(true);
        _hummmers[1].SetActive(true);
        _feverTimer = 0;
        _fever = true;
        _count.SetActive(true);
    }


    void AttackEffect()
    {
        //AudioManager.Instance.PlaySE(AudioManager.SESoundData.SE.Attack);
        _animator.Play("CorrectAttack");
    }

    bool AttackInput()
    {
        if (Input.GetMouseButton(0))
        {
            if (Math.Abs(Input.GetAxis("Mouse X")) > _state.MouseValue)
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
            if (Math.Abs(Input.GetAxis("Mouse X")) > _state.MouseValue)
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
        _animator.Play("TakeDamage");
        _hp -= damage;
        if(_hp <= 0)
        {
            GameManager.Instance.OnGameOver(_myTurn);
        }
        else
        {
            StartCoroutine(Damage());
        }
    }

    public void ChangeTransform()
    {
        _deffenceTransform.position = _firstPos;
    }

    IEnumerator CoolTime(float time)
    {
        yield return new WaitForSeconds(time);
        _isAttack = false;
    }

    IEnumerator Damage()
    {
        GameManager.InGameState = InGameState.None;
        yield return new WaitForSeconds(0.3f);
        GameManager.InGameState = InGameState.Game;
    }
    IEnumerator SuccesDeffence(float time)
    {
        yield return new WaitForSeconds(time);
        GameManager.Instance.Ready();
    }
}
