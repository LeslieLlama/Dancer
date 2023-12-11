using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void TakeDamage(float damageAmount);
}

public interface IPlayerTools
{
    void PickUpScrap(int scrapAmount);
}
