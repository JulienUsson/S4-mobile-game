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

    void Update()
    {

        float axis = Input.GetAxisRaw("Horizontal");

        if (Input.touchCount > 0)
        {
            foreach (var touch in Input.touches)
            {
                if (touch.position.x < Screen.width / 2)
                {
                    axis -= 1f;
                }
                else if (touch.position.x > Screen.width / 2)
                {
                    axis += 1f;
                }
            }
        }

        if (axis != 0)
        {
            direction = Mathf.Sign(axis) * -1;
            if (Mathf.Abs(speed) < maxSpeed)
            {
                speed += direction * acceleration * Time.deltaTime;
            }
        }
        else if (Mathf.Abs(speed) > 0)
        {
            speed -= direction * deceleration * Time.deltaTime;
            if (speed * direction < 0)
            {
                speed = 0;
            }
        }

    }

    void FixedUpdate()
    {
        transform.RotateAround(Vector3.zero, Vector3.forward, speed * Time.fixedDeltaTime);
    }
}
