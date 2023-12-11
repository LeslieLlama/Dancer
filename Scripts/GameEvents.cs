using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents Instance { get; private set; }


    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than one instance!");
            return;
        }

        Instance = this;
    }

    //game events
    


    
    public event Action OnMeteorDestroy;
    public void MeteorDestroy()
    {
        OnMeteorDestroy?.Invoke();
    }
    public event Action OnOrbitalSpawn;
    public void OrbitalSpawn()
    {
        OnOrbitalSpawn?.Invoke();
    }
    public event Action OnOrbitalDestroy;
    public void OrbitalDestroy()
    {
        OnOrbitalDestroy?.Invoke();
    }

    //UI events
    public event Action OnGamePause;
    public void GamePause()
    {
        OnGamePause?.Invoke();
    }
    public event Action OnGameUnpause;
    public void GameUnpause()
    {
        OnGameUnpause?.Invoke();
    }
}