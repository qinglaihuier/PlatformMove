using System;
using UnityEngine;
public class Demo1 : MonoBehaviour
{
    private int _k1 = 1;
    int _k2 = 2;

    private int _count ;
    private void Awake()
    {
        Debug.Log("Awake");
    }

    private void OnEnable()
    {
        Debug.Log(("OnEnable"));
    }

    void Start()
    {
       Debug.Log("Start");
    }

    private void Update()
    {
        LongTask();
        
        Debug.Log(("-----------------", Time.deltaTime + " " + _count));

        _count += 1;
    }

    private void FixedUpdate()
    {
        //LongTask();
        Debug.Log(("F  " + _count + "  " + Time.realtimeSinceStartup));
    }

    private void Reset()
    {
        Debug.Log("Reset");
    }

    void LongTask()
    {
       
        for (int i = 0; i < 80; ++i)
        {
            for (int m = 0; m < 0xfffff; ++m)
            {
                _k1 = _k1 + _k1 * _k2;

                _k1 = _k1 % 99999;

                _k2 += _k1;

                _k2 %= 999;
            }
        }
    }
}
