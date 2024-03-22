using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zaklinanieY : MonoBehaviour
{
    public float _speed = 10;

    void Start()
    {

        GetComponent<Rigidbody>().velocity = transform.forward * _speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        _popalKydaNado(collision);
        DestroyZacklinanieY(collision);
    }
    private void _popalKydaNado(Collision collision)
    {
        AIVraga vragioc = collision.gameObject.GetComponent<AIVraga>();

        //Если у объекта есть компонент Animal, то вызываем у него метод EatFood и уничтожаем еду
        if (vragioc != null)
        {
            vragioc.Ymenshil();
            Destroy(gameObject);
            Debug.Log(2);
        }
    }
    private void DestroyZacklinanieY(Collision collision)
    {
        PlayerHealthhh TiVsebaPopal = collision.gameObject.GetComponent<PlayerHealthhh>();

        if (TiVsebaPopal == null)
        {
            Destroy(gameObject);
            Debug.Log(1);
        }
    }
}
