using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : Weapon
{
    //slingshot variables
    [SerializeField] private Vector3 origin;
    private float forceConstant = 200;
    private bool returning = false;
    private float precision = 0.1f;

    //references
    private PlayerMovement playerMovement;
    private PlayerHealth playerHealth;
    private LineRenderer lr;
    private Rigidbody2D rb2d;

    private void Start()
    {
        playerHealth = gameObject.GetComponentInParent<PlayerHealth>();
        playerMovement = gameObject.GetComponentInParent<PlayerMovement>();
        lr = gameObject.GetComponent<LineRenderer>();
        rb2d = GetComponentInParent<Rigidbody2D>();
    }

    public override void SetWeaponActive(bool isWeaponActive)
    {
        if (isWeaponActive == true)
        {
            SlingshotActive();
        }
    }

    void SlingshotActive()
    {
        //graphics
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, Vector3.zero);

        //
        if (transform.position != Vector3.zero && playerMovement.isMoving == false)
        {
            rb2d.AddForce(forceConstant * (origin - transform.position));
            rb2d.velocity *= 0.9f;
            playerHealth.isInvincible = true;
        }
        else
        {
            playerHealth.isInvincible = false;
        }

    }
}
