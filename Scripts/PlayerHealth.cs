using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] public bool isInvincible;
    [SerializeField] private Color invincibleColor;
    private bool isDead;

    //events
    public delegate void PlayerDamaged();
    public static event PlayerDamaged OnPlayerDamaged;
    

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        
        ResolveDamage();
    }

    void ResolveDamage()
    {
        if (isInvincible == true)
        {
            return;
        }
        //explosion effect here
        isDead = true;
        
        OnPlayerDamaged();
    }

    private void Update()
    {
        if (isDead)
        {
            spriteRenderer.color = Color.gray; //tempory graphical effect;
        }
        else if(isInvincible == true)
        {
            spriteRenderer.color = invincibleColor;
        }
        else
        {
            spriteRenderer.color = Color.white;
        }
    }
}
