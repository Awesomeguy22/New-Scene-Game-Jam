using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadWiggle : MonoBehaviour
{

    [SerializeField] GameObject head;
    [SerializeField] float amplitude = 5;
    // Start is called before the first frame update
    void Start()
    {
        if (!head){
            head = gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Time.time);
        //Debug.Log(amplitude * ((float)  Math.Sin(Time.time)));
        head.transform.rotation *= Quaternion.Euler(0, 0 , amplitude * Time.deltaTime * ((float)  Mathf.Cos(Time.time)));
    }
}
