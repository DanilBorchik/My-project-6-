using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vostanovlenie : MonoBehaviour
{
    public float hp_vost = 1;
    public float CostManaV = 1;
    public PlayerHealthhh _PlayerHealth;
    public GameObject _VizualVostanovlenie;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        regen();
    }

    private void regen()
    {
        _VizualVostanovlenie.SetActive(false);
        if (Input.GetKey(KeyCode.E))
        {
            if (_PlayerHealth._mana >= CostManaV)
            {
                _VizualVostanovlenie.SetActive(true);
                _PlayerHealth.HpRegen(hp_vost * Time.deltaTime);
                _PlayerHealth.DealMinysMana(CostManaV * Time.deltaTime);
            }
        }
    }
}
