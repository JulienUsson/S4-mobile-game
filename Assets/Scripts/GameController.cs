using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject ennemy;
    public int numberOfSpawns = 2;
    public Vector3 spawnValues;
    public float spawnWait;
    public float startWait;
    public float waveWait = 3;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWaves()); 
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < numberOfSpawns; i++)
            {
                Debug.Log("IValue: " + i);
                bool isLeft = (Random.value > 0.5f);
                Vector3 spawnPosition = new Vector3((isLeft) ?  -spawnValues.x : spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
                Instantiate(ennemy, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
           
        }
    }
}
