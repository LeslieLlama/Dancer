using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRadarTracker : MonoBehaviour
{
    [SerializeField] private Transform trackerX;
    [SerializeField] private Transform trackerY;
    [SerializeField] private Transform player;

    void Update()
    {
        trackerX.position = new Vector3(player.position.x, trackerX.position.y, 0);
        trackerY.position = new Vector3(trackerY.position.x, player.position.y, 0);
    }
}
