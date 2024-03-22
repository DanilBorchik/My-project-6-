using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 position1 = new Vector3(1, 3, 2);
        Vector3 position2 = new Vector3(0, 5, 4);
        float result = Vector3.Distance(position1, position2);
        Debug.Log(result);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
