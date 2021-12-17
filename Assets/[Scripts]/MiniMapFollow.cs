/*
 Full Name: Rui Chen Geng Li (101277255)
 File Name: MiniMapFollow.cs
 Last Modified: December 17th, 2021
 Description: Changes the transform of the minimap so it follows the player
 Version History: v1.01 Added Internal Document To This Template Script
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapFollow : MonoBehaviour
{
    public Transform player;


    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + new Vector3(0.0f, 0.0f, -10f);
    }
}
