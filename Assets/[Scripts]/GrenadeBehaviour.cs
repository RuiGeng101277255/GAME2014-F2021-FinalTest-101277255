/*
 Full Name: Rui Chen Geng Li (101277255)
 File Name: GrenadeBehaviour.cs
 Last Modified: December 17th, 2021
 Description: Defines the granade's behaviour and effects
 Version History: v1.01 Added Internal Document To This Template Script
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBehaviour : MonoBehaviour
{
    public float damage = 10;
    public float speed = 4.0f;
    public Vector3 direction = Vector3.right + Vector3.up;
    public ContactFilter2D contactFilter;
    public List<Collider2D> colliders;

    private CircleCollider2D circleCollider;

    // Start is called before the first frame update
    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _CheckCollision();
        _CheckBounds();
    }

    public void Initialize()
    {
        GetComponent<Rigidbody2D>().AddForce(direction * speed, ForceMode2D.Impulse);
    }

    private void _CheckCollision()
    {
        Physics2D.GetContacts(circleCollider, contactFilter, colliders);

        if (colliders.Count > 0)
        {
            if (colliders[0] != null)
            {
                BulletManager.Instance().ReturnBullet(PoolType.PLAYER, gameObject);
                colliders.Clear();
            }
        }
    }

    private void _CheckBounds()
    {
        if (transform.position.y <= -10)
        {
            BulletManager.Instance().ReturnBullet(PoolType.PLAYER, gameObject);
        }
    }
}
