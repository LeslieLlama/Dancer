using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    public float currentHealth;
    private float maxHealth = 1;
    [SerializeField] private GameObject scrapDrop;

    void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(1); //take damage here has a float value, even though I'm planning to only ever have one health state, becuase I might change my mind in the future
        }
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        DeathCheck();
    }

    void DeathCheck()
    {
        if (currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        GameObject scrap = Instantiate<GameObject>(scrapDrop);
        scrap.transform.position = transform.position;
        // Put a particle effect here
        Destroy(gameObject);
    }
}
