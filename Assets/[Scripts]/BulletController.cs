/*
 Full Name: Rui Chen Geng Li (101277255)
 File Name: BulletController.cs
 Last Modified: December 17th, 2021
 Description: Controls the behaviour and motion of the spawned bullets
 Version History: v1.01 Added Internal Document To This Template Script
 */

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BulletController : MonoBehaviour, IApplyDamage
{
    public float verticalSpeed;
    public float verticalBoundary;
    public int damage;
    public ContactFilter2D contactFilter;
    public List<Collider2D> colliders;
    public Vector3 direction;

    private  BoxCollider2D boxCollider;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
        _CheckCollision();
    }

    private void _CheckCollision()
    {
        Physics2D.GetContacts(boxCollider, contactFilter, colliders);

        if (colliders.Count > 0)
        {
            if (colliders[0] != null)
            {
                BulletManager.Instance().ReturnBullet(PoolType.ENEMY, gameObject);
                colliders.Clear();
            }
        }
    }


    private void _Move()
    {
        transform.position += direction * verticalSpeed * Time.deltaTime;
    }

    private void _CheckBounds()
    {
        if (transform.position.y > verticalBoundary)
        {
            BulletManager.Instance().ReturnBullet(PoolType.ENEMY, gameObject);
        }
    }

    public int ApplyDamage()
    {
        return damage;
    }
}
