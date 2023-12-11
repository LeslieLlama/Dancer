using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemySeeking : MonoBehaviour
{
    public Transform target;

    public float speed = 5f;
    public float rotateSpeed = 200f;

    private Rigidbody2D rb;

    public static event Action<GameObject> OnMeteorSpawn;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        OnMeteorSpawn?.Invoke(this.gameObject);

        
    }

    void FixedUpdate()
    {
        Vector2 direction = (Vector2)target.position - rb.position;

        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * rotateSpeed;

        rb.velocity = transform.up * speed;
    }

    


}
