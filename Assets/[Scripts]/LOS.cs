/*
 Full Name: Rui Chen Geng Li (101277255)
 File Name: LOS.cs
 Last Modified: December 17th, 2021
 Description: Line of sight for entity detections
 Version History: v1.01 Added Internal Document To This Template Script
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LOS : MonoBehaviour
{
    public Collider2D collidesWith;
    public ContactFilter2D contactFilter;
    public List<Collider2D> colliders;
    public Transform entity;

    //private BoxCollider2D LOSCollider;
    private PolygonCollider2D LOSCollider;


    // Start is called before the first frame update
    void Start()
    {
        LOSCollider = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = entity.position;
        transform.localScale = entity.localScale;
        Physics2D.GetContacts(LOSCollider, contactFilter, colliders);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        collidesWith = other;
    }
}
