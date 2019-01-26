﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMove : MonoBehaviour
{
    public float moveSpeed = 600f;
    float movement = 0f;
    public GameObject ennemy;
    private float nextSpawn;
    public float spawnRate;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        transform.RotateAround(Vector3.zero, Vector3.forward, Time.fixedDeltaTime * -moveSpeed);

        if(Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            Instantiate(ennemy, transform.position, transform.rotation);
        }
    }
}
