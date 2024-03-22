using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthhh : MonoBehaviour
{
    public float _hp = 100;
    public float _mana = 100;
    public float _regenmana = 1;
    public RectTransform _hpRectTransform;
    public RectTransform _ManaRectTransform;

    public GameObject gameplayUI;
    public GameObject gameOverScren;
    public GameObject stvol;

    private float _maxhp;
    private float _maxmana;

    private void Start()
    {
        _maxhp = _hp;
        _maxmana = _mana;
        DrawHealthBar();
    }
    void Update()
    {
        regenmani();
    }

    private void regenmani()
    {
        if (_mana < _maxmana)
        {
            _mana += _regenmana * Time.deltaTime;
            DrawManaBar();
        }
    }

    public void DealDamage(float damage)
    {
        _hp -= damage;
        if (_hp <= 0)
        {
            ded();
        }

        DrawHealthBar();
    }
    public void DealMinysMana(float minys)
    {
        _mana -= minys;
        DrawManaBar();
    }
    private void ded()
    {
        gameplayUI.SetActive(false);
        gameOverScren.SetActive(true);
        stvol.GetComponent<CasterFireball>().enabled = false;
        stvol.GetComponent<CastYmenshenie>().enabled = false;
        GetComponent<brodilna>().enabled = false;
        GetComponent<Nogi>().enabled = false;
    }
    private void DrawHealthBar()
    {
        _hpRectTransform.anchorMax = new Vector2(_hp / _maxhp, 1);
    }
    private void DrawManaBar()
    {
        _ManaRectTransform.anchorMax = new Vector2(_mana / _maxmana, 1);
    }
    public void HpRegen(float _hpregen)
    {
        if (_hp <= _maxhp)
        {
            _hp += _hpregen;
        }
        DrawHealthBar();
    }
}
