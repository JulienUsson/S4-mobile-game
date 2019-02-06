using UnityEngine;

public class EnnemyMover : MonoBehaviour
{
    public float movespeed = 5;
    public float acceleration = 1f;

    void Start()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();

        if (transform.position.x > 0)
        {
            sprite.flipY = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float step = movespeed * Time.fixedDeltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, step);
        movespeed += acceleration * Time.deltaTime;
    }
}
