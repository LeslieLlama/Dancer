using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.U2D;

public class ObliterationGeometry : Weapon
{
    private SpriteShapeController spriteShapeController;
    private SpriteShapeRenderer spriteShapeRenderer;
    [SerializeField] SpriteRenderer standInColour;
    private PolygonCollider2D polygonCollider2D;
    public bool weaponActive = false;

    private void OnEnable()
    {
        CircleArenaCollider.OnCircleTouchedByPlayer += UpdateGeometryPositions;
    }
    private void OnDisable()
    {
        CircleArenaCollider.OnCircleTouchedByPlayer -= UpdateGeometryPositions;
    }

    public override void SetWeaponActive(bool isWeaponActive)
    {
        weaponActive = isWeaponActive;
    }

    void Start()
    {
        spriteShapeController = GetComponent<SpriteShapeController>();
        spriteShapeRenderer = GetComponent<SpriteShapeRenderer>();
        polygonCollider2D = GetComponent<PolygonCollider2D>();
        transform.parent = null; //organisational purposes, i like to have the subweapons as children of the player but this one doesnt work following the players position
        standInColour.color = Color.clear;
        SetWeaponActive(false);
    }

    void UpdateGeometryPositions(List<Vector3> listOfPoints)
    {
        Spline spline = spriteShapeController.spline;
        spline.Clear();
        for (int i = 0; i < listOfPoints.Count; i++)
        {
            spline.InsertPointAt(i, listOfPoints[i]);
        }
        FireWeaponAnimation();
    }

    //bug: turning the hitbox on when the triangle is completed won't register an ontrigger enter because the enemy meteor was already inside the collider
    //could be fixed with OnTriggerStay but ehhhhhh it's super inefficent right?
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (weaponActive == false) { return; }
        IDamageable damageable = collision.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(1); //take damage here has a float value, even though I'm planning to only ever have one health state, becuase I might change my mind in the future
        }
    }

    void FireWeaponAnimation()
    {
        standInColour.color = Color.white;
        standInColour.DOFade(0, 1f);
        StartCoroutine(HitboxActiveTime(1f));
    }

    IEnumerator HitboxActiveTime(float ammountOfTime)
    {
        polygonCollider2D.enabled = true;
        yield return new WaitForSeconds(ammountOfTime);
        polygonCollider2D.enabled = false;
    }

    private void Update()
    {
        //can't DOtween the spriteShapeRenderer correctly because it's not registered as a component in the DOTween library. 
        spriteShapeRenderer.color = standInColour.color;

        //manual fire for testing purposes
        if (Input.GetKeyDown("m"))
        {
            FireWeaponAnimation();
        }
    }


}
