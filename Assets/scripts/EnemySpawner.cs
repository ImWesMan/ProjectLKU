using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyOne;
    [SerializeField] private float swarmerIntervalOne = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemies(swarmerIntervalOne, enemyOne));
    }

    // Update is called once per frame
    private IEnumerator spawnEnemies(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f,5), Random.Range(-5f,5), 0), Quaternion.identity);
        StartCoroutine(spawnEnemies(interval, enemy));
    }
}
