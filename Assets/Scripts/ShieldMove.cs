using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldMove : MonoBehaviour
{
    public float maxSpeed = 300f;
    public float acceleration = 10f;
    public float deceleration = 10f;
    private float speed = 0f;
    private float direction = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float axis = Input.GetAxisRaw("Horizontal");
        if (axis != 0)
        {
            direction = Mathf.Sign(axis) * -1;
            if (Mathf.Abs(speed) < maxSpeed)
            {
                speed += Mathf.Abs(axis) + acceleration;
            }
        }
        else
        {
            if (Mathf.Abs(speed) > 0)
            {
                speed -= deceleration;
                if (speed < 0)
                {
                    speed = 0;
                }
            }
        }
    }

    void FixedUpdate()
    {
        transform.RotateAround(Vector3.zero, Vector3.forward, speed * direction * Time.fixedDeltaTime);
    }
}
