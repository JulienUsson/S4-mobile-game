using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimation : MonoBehaviour
{
    public float speed = 1f;
    public float distance = 1f;
    private Vector3 initialPosition;
    public bool isDeafeated = false;

    public bool IsDefeated
    {
        get{ return isDeafeated;}
        set { isDeafeated = value; }
    }

    void Start()
    {
        initialPosition = this.transform.position;
        this.transform.position += new Vector3(distance, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (initialPosition.x < this.transform.position.x && !isDeafeated)
        {
            this.transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        }
        
        if (isDeafeated)
            this.transform.position += new Vector3(speed * Time.deltaTime * 10, 0, 0);
    }
}
