using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject spawn;
    public int numberOfSpawns = 2;
    public Vector3 spawnValues;
    public float spawnWait;
    public float startWait;
    public float waveWait = 3;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnWaves()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < numberOfSpawns; i++)
            {
                Instantiate(spawn, spawnValues, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
           
        }
    }
}
