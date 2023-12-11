using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticSaw : Weapon
{
    [SerializeField] private TrailRendererWith2DCollider trCol;
    [SerializeField] private GameObject trailObject;

    private void Start()
    {
        trCol = GetComponent<TrailRendererWith2DCollider>();
        trailObject = trCol.collider.gameObject;
        SetWeaponActive(false);
    }

    public override void SetWeaponActive(bool isWeaponActive)
    {
        if (isWeaponActive == true)
        {
            trCol.enabled = true;
            trailObject.SetActive(true);
        }
        else
        {
            trCol.enabled = false;
            trailObject.SetActive(false);
        }
    }
}
