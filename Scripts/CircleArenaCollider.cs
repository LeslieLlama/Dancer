using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CircleArenaCollider : MonoBehaviour
{
    private List<Vector3> playerCircleCollisionPoints = new List<Vector3>();
    [SerializeField] private int ammountOfColPoints;
    private int currentColPoint = 0;

    public static event Action<List<Vector3>> OnCircleTouchedByPlayer;

    private void Start()
    {
        playerCircleCollisionPoints.Clear();
        for (int i = 0; i < ammountOfColPoints; i++)
        {
            playerCircleCollisionPoints.Add(new Vector3(0, 0, 0));
        }
    }

    void SetPoint(Transform playerPos)
    {
        playerCircleCollisionPoints[currentColPoint] = playerPos.position;
        currentColPoint += 1;
        if (currentColPoint >= playerCircleCollisionPoints.Count) 
        {
            OnCircleTouchedByPlayer(playerCircleCollisionPoints);
            currentColPoint = 0;
            print("3 points touched");
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            SetPoint(collision.transform);
        }
    }
}
