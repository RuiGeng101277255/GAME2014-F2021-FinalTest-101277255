/*
 Full Name: Rui Chen Geng Li (101277255)
 File Name: BarController.cs
 Last Modified: December 17th, 2021
 Description: Defines a "progress bar" useful for things like the player health
 Version History: v1.01 Added Internal Document To This Template Script
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BarController : MonoBehaviour
{
    public Transform bar;
    public Transform entity;
    public int currentValue;
    public int maxValue;

    // Start is called before the first frame update
    void Start()
    {
        currentValue = 100;
        maxValue = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (entity != null)
        {
            transform.position = entity.position + Vector3.up;
        }
    }

    public void SetValue(int new_value)
    {
        currentValue = new_value;
        bar.localScale = new Vector3((float)((double)currentValue / (double)maxValue), 1.0f, 1.0f);

        // clamp the scale on the x axis to be zero minimum
        if (bar.localScale.x < 0)
        {
            bar.localScale = new Vector3(0.0f, 1.0f, 1.0f);
        }
    }
}
