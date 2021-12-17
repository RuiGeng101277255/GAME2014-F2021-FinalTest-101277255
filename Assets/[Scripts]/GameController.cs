/*
 Full Name: Rui Chen Geng Li (101277255)
 File Name: GameController.cs
 Last Modified: December 17th, 2021
 Description: Controls the game
 Version History: v1.01 Added Internal Document To This Template Script
 */

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Bullet Related")]
    public int MaxBullets;
    public BulletType enemyBulletType;
    public BulletType playerBulletType;

    [Header("Moving Platforms")] 
    public List<MovingPlatformController> movingPlatforms;

    // Start is called before the first frame update
    void Start()
    {
        movingPlatforms = FindObjectsOfType<MovingPlatformController>().ToList();


        // Kickoff the BulletManager
        BulletManager.Instance().Init(MaxBullets, enemyBulletType, playerBulletType);
    }

    public void ResetAllPlatforms()
    {
        foreach (var platform in movingPlatforms)
        {
            platform.Reset();
        }
    }

}
