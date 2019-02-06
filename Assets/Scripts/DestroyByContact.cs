using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject Explosion;

    void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(Explosion, other.transform.position, other.transform.rotation);
        Destroy(other.gameObject);
    }
}
