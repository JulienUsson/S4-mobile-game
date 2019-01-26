using UnityEngine;

public class EnnemyMover : MonoBehaviour
{
    public float movespeed = 5;
    public Transform earth;
    SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float step = movespeed * Time.fixedDeltaTime;

        transform.position = Vector3.MoveTowards(transform.position, earth.position, step);

        if(transform.position.x > 0)
        {
            sprite.flipX = true;
        }
    }
}
