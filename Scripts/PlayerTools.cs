using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerTools : MonoBehaviour, IPlayerTools
{
    //events
    public static event Action<int> OnScrapCollected;
    public static event Action<int> OnPlayerLevelup;


    //scrap management variables
    public int scrapCount;
    public int playerLevel; //starts at 0
    public List<int> scrapLevelThreshholds = new List<int>();
    public List<Weapon> weapons = new List<Weapon>();


    //references
    //private PlayerMovement playerMovement;
    //public GameObject scrapCollectionParticles;

/*    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }*/

    public void PickUpScrap(int scrapAmount) //works off of the player tools interface
    {
        scrapCount += scrapAmount;
        OnScrapCollected(scrapCount);
        WeaponActivationCheck();
    }

    void WeaponActivationCheck()
    {
        if(scrapCount >= scrapLevelThreshholds[playerLevel] && playerLevel < weapons.Count)
        {
            weapons[playerLevel].SetWeaponActive(true);
            playerLevel += 1;
            OnPlayerLevelup(playerLevel);
        }
    }

    /*private void Update()
    {
        if(playerMovement.isMoving == false)
        {
            scrapCollectionParticles.SetActive(true);
        }
        else
        {
            scrapCollectionParticles.SetActive(true);
        }
    }*/
}
