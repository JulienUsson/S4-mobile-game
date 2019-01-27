using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMove : MonoBehaviour
{
    public float moveSpeed = 200f;
    public GameObject ennemy;
    private float nextSpawn;
    public float spawnRate;

    void FixedUpdate()
    {
        transform.RotateAround(Vector3.zero, Vector3.forward, Time.fixedDeltaTime * moveSpeed);

        if(Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            GameObject go = Instantiate(ennemy, transform.position, transform.rotation);
            go.GetComponent<Rigidbody2D>().AddForce(Vector3.up * moveSpeed);
            moveSpeed += 10;
        }
    }
}
