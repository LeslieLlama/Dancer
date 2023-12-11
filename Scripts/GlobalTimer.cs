using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GlobalTimer : MonoBehaviour
{
    //events
    public delegate void WaveTick();
    public static event WaveTick OnWaveTicked;

    public float currentTime = 0;
    public bool timerIsRunning = false;
    public TMP_Text timeText;
    private float waveTick;
    [SerializeField] private float waveTickSpeed;
    private void Start()
    {
        waveTick = waveTickSpeed;
        timerIsRunning = true;
        
    }
    void Update()
    {
        if (timerIsRunning)
        {
            currentTime += Time.deltaTime;
        }

        if (currentTime > waveTick) //currentTime is a multiple of waveTickSpeed
        {
            OnWaveTicked();
            waveTick += waveTickSpeed;
        }



        DisplayTime();

        //debug, forces next wave early
        if (Input.GetKeyDown("space"))
        {
            OnWaveTicked();
        }
    }

    void DisplayTime()
    {
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    
    void StopTimer()
    {
        timerIsRunning = false;
    }

    private void OnEnable()
    {
        PlayerHealth.OnPlayerDamaged += StopTimer;
    }
    private void OnDisable()
    {
        PlayerHealth.OnPlayerDamaged -= StopTimer;
    }

    

}
