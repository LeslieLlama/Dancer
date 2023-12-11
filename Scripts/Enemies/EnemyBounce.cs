using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBounce : MonoBehaviour
{
    [SerializeField] private float speed;
    Vector2 direction;

    private Rigidbody2D rb2d;
    [SerializeField] private GameObject wallCollider;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        direction = Vector2.right;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2d.velocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        direction = Vector2.Reflect(transform.position, Vector2.left);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("scibidi 2");
        //StartCoroutine(BecomeSolid());
    }

    IEnumerator BecomeSolid()
    {
        yield return new WaitForSeconds(0.3f);
        wallCollider.SetActive(true);
    }
}
