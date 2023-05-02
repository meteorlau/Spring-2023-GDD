using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LycheeSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject lycheePrefab;

    [SerializeField]
    //spawn time interval
    private float lycheeInterval = 4f;
    
    // Start is called before the first frame update
    private IEnumerator spawnEnemy(float interval, GameObject enemy) {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }

    void Start() {
        StartCoroutine(spawnEnemy(lycheeInterval, lycheePrefab));
    }
}
