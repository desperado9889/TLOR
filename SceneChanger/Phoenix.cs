using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phoenix : MonoBehaviour
{
    private Phoenix instance = null;
    private int check = 0;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance == null)
        {
            Destroy(gameObject);
        }

        check++;
        Debug.Log("Phoenix Check = " + check);
    }

    void Update()
    {
        
    }
}
