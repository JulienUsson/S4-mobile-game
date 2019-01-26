using UnityEngine;

public class EnnemyMover : MonoBehaviour
{
    public float movespeed = 5;
    public Transform earth;

    // Update is called once per frame
    void Update()
    {
        float step = movespeed * Time.fixedDeltaTime;

        transform.position = Vector3.MoveTowards(transform.position, earth.position, step);
    }
}
