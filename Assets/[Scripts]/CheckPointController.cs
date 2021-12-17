/*
 Full Name: Rui Chen Geng Li (101277255)
 File Name: CheckPointController.cs
 Last Modified: December 17th, 2021
 Description: Checkpoint that resets the player's respawn position
 Version History: v1.01 Added Internal Document To This Template Script
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    public Transform spawnPoint;
    public PlayerBehaviour player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.spawnPoint = spawnPoint;
        }
    }
}
