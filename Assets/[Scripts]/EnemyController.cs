/*
 Full Name: Rui Chen Geng Li (101277255)
 File Name: EnemyController.cs
 Last Modified: December 17th, 2021
 Description: Controls the enemy movements
 Version History: v1.01 Added Internal Document To This Template Script
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float horizontalSpeed;
    public float horizontalBoundary;
    public float direction;

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    private void _Move()
    {
        transform.position += new Vector3(horizontalSpeed * direction * Time.deltaTime, 0.0f, 0.0f);
    }

    private void _CheckBounds()
    {
        // check right boundary
        if (transform.position.x >= horizontalBoundary)
        {
            direction = -1.0f;
        }

        // check left boundary
        if (transform.position.x <= -horizontalBoundary)
        {
            direction = 1.0f;
        }
    }
}
