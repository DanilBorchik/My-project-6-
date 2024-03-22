using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastYmenshenie : MonoBehaviour
{
    public zaklinanieY ZakPrefab;
    public PlayerHealthhh _PlayerHealth;
    public float cooldown = 10;
    public float CostManaY = 15;

    private bool Postril = false;
    private float chisloCooldown;
    //private bool ManaNull = false;

    private void Start()
    {
        chisloCooldown = cooldown;
    }
    void Update()
    {
        CooldownUpdate();
        PostrilUpdate();
    }

    private void CooldownUpdate()
    {
        if (Postril == true)
        {
            cooldown -= Time.deltaTime;
            if (cooldown <= 0)
            {
                cooldown = chisloCooldown;
                Postril = false;
            }
        }
    }

    private void PostrilUpdate()
    {
        if (cooldown == chisloCooldown)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (_PlayerHealth._mana >= CostManaY)
                {
                    ThrowZak();
                    Postril = true;
                    _PlayerHealth.DealMinysMana(CostManaY);
                }
            }
        }
    }

    void ThrowZak()
    {
        zaklinanieY zaklinanieYClone = Instantiate(ZakPrefab, transform.position, transform.rotation);
        zaklinanieYClone.transform.LookAt(GetTargetPoint());
    }

    Vector3 GetTargetPoint()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            return hit.point;
        }
        return ray.GetPoint(100);
    }
    
}