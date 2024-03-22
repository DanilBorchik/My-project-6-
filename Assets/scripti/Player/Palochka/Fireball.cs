using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float Speed;
    public float lifetime;
    public float damage = 20;
    public float graviti = 9.8f;

    private float _gravi = 0;
    void Start()
    {
        Invoke("DestroyFaerbol", lifetime);
    }
    void FixedUpdate()
    {
        PeremeshenieEtoiFricadelki();
    }
    private void PeremeshenieEtoiFricadelki()
    {
        transform.position += transform.forward * Speed * Time.fixedDeltaTime;
        _gravi += graviti * Time.fixedDeltaTime;
        transform.position += Vector3.down * _gravi * Time.fixedDeltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        _Popal(collision);
        DestroyFaerbol();
    }
    private void _Popal(Collision collision)
    {
        {
            var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>(); 
            if (enemyHealth != null)
            {
                enemyHealth.DealDamage(damage);
            }
        }
    }
    private void DestroyFaerbol()
    {
        Destroy(gameObject);
    }
 }
