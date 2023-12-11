using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnEnemy
{
    public int spawnDirection;
    public GameObject enemyToSpawn;
}

[System.Serializable]
public class SpawnEvent
{
    public SpawnEnemy[] spawnEnemies;
}

public class SpawnManager : MonoBehaviour
{
    public SpawnEvent[] enemyWaves;
    [SerializeField] int currentWave = 0;

    [SerializeField] Vector3 spawnCenter;
    [SerializeField] float spawnRadius;

    void SpawnWave()
    {
        foreach (SpawnEnemy enemy in enemyWaves[currentWave].spawnEnemies)
        {
            GameObject instanciatedEnemy = Instantiate(enemy.enemyToSpawn);
            instanciatedEnemy.transform.position = RandomPointOnXZCircle(enemy.spawnDirection);
        }
        
        if (currentWave < enemyWaves.Length -1) { currentWave += 1; }
    }

    Vector3 RandomPointOnXZCircle(float spawnDirection)
    {
        spawnDirection -= 90;
        spawnDirection *= -1; //these two lines are just to change the angle to be the numbers I prefer in the editor, ie 0 == north, 90 == east
        float angle = spawnDirection * Mathf.PI / 180;
        return spawnCenter + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle),0) * spawnRadius;
    }

    private void OnEnable()
    {
        GlobalTimer.OnWaveTicked += SpawnWave;
    }
    private void OnDisable()
    {
        GlobalTimer.OnWaveTicked -= SpawnWave;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(spawnCenter, spawnRadius);
    }

}
