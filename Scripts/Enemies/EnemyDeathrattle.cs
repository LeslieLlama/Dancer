using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathrattle : MonoBehaviour
{
    public List<DeathrattleSpawn> objectsToSpawn = new List<DeathrattleSpawn>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();
        if (damageable != null)
        {
            foreach (DeathrattleSpawn obj in objectsToSpawn)
            {
                var instanciatedObj = Instantiate<GameObject>(obj.objectToSpawn);
                instanciatedObj.transform.position = transform.position += obj.positionToSpawn;
            }
        }
    }
}

[System.Serializable]
public struct DeathrattleSpawn
{
    public GameObject objectToSpawn;
    public Vector3 positionToSpawn;
}
