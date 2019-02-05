using UnityEngine;

public class EnnemyMover : MonoBehaviour
{
    public float movespeed = 5;
    public float acceleration = 1f;
    public Transform earth;
    SpriteRenderer sprite;
    Rigidbody2D rb;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        if (transform.position.x > 0)
        {
            sprite.flipX = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float step = movespeed * Time.fixedDeltaTime;

        transform.position = Vector3.MoveTowards(transform.position, earth.position, step);
        rb.AddForce(Vector3.up * 500);

        movespeed += acceleration * Time.deltaTime;
    }
}
