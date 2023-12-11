using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrap : MonoBehaviour
{
    private Rigidbody2D rb2D;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity += new Vector2(Random.Range(-1,1), Random.Range(-1, 1))*3;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IPlayerTools playerTools = collision.GetComponent<IPlayerTools>();
        if (playerTools != null)
        {
            playerTools.PickUpScrap(1);
            Destroy(gameObject);
        }
    }
}
