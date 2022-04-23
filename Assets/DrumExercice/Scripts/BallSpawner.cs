using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject prefab;
    public Transform spawnPosition;
    public float delayBeforeStart;
    public float delayBetweenSpawn;
    public bool shouldDestroyBallOnHit;
    public float delayBeforeBallDestruction;

    void Start()
    {
        StartCoroutine(SpawnBall());
    }

    IEnumerator SpawnBall()
    {
        yield return new WaitForSeconds(delayBeforeStart);

        while (true)
        {
            GameObject tmpGO = Instantiate(prefab, spawnPosition.position, Quaternion.identity);
            
            if (shouldDestroyBallOnHit)
            {
                tmpGO.GetComponent<BallBehavior>().shouldBeDestroyedOnHit = true;
            }
            else
            {
                Destroy(tmpGO, delayBeforeBallDestruction);
            }

            yield return new WaitForSeconds(delayBetweenSpawn);
        }
    }
}
