/*
 Full Name: Rui Chen Geng Li (101277255)
 File Name: SceneController.cs
 Last Modified: December 17th, 2021
 Description: Changes Scene
 Version History: v1.01 Added Internal Document To This Template Script
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{


    public void OnButtonPressed()
    {
        SceneManager.LoadScene("Platformer");
    }
}
