using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasterFireball : MonoBehaviour
{
    public Fireball fireballPrefab;
    public PlayerHealthhh _PlayerHealth;
    float timer = 0f;
    public float CostManaF = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            if(timer >= 0.8f)
            {
                if (_PlayerHealth._mana >= CostManaF)
                {
                    Instantiate(fireballPrefab, transform.position, transform.rotation);
                    timer = 0;
                    _PlayerHealth.DealMinysMana(CostManaF);
                }
            }
        }
    }
}
