using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyMover : MonoBehaviour
{
    public float movespeed = 5;
    private Rigidbody2D rb;
    public Transform earth;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        // rb.transform.Translate(0, -1, movespeed);
        Vector3 targetDir = earth.position - transform.position;
        rb.position = targetDir;
    }
}
