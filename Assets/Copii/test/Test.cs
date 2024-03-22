using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Transform Tochka1;
    public Transform Tochka2;

    private float chislo = 1f;
    private bool da = false;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame  
    void FixedUpdate()
    {
        Fack();
        transform.position = Vector3.Lerp(Tochka1.position, Tochka2.position, chislo);
        timer += Time.fixedDeltaTime;
    }

    private void Fack()
    {
        if (timer >= 0.5f)
        {
            if (chislo <= 1f && da == false)
            {
                chislo -= Time.fixedDeltaTime;
                if (chislo <= 0.2)
                {
                    da = true;
                }
            }
            if (chislo >= 0f && da == true)
            {
                chislo += Time.fixedDeltaTime;
                if (chislo >= 0.8)
                {
                    da = false;
                }
            }
        }
    }

}
