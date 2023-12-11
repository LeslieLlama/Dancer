using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDamage : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();
        if (damageable != null && collision.tag != "Player")
        {
            damageable.TakeDamage(1); //take damage here has a float value, even though I'm planning to only ever have one health state, becuase I might change my mind in the future
        }
    }
}
