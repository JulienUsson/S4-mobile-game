using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QteImage : MonoBehaviour
{
    public float speed = 1.0f; //how fast it shakes
    public float amount = 1.0f; //how much it shakes

    void Update()
    {
        float scale = Mathf.Sin(Time.time * speed) * amount / 100;
        this.transform.localScale += new Vector3(scale, scale, 0); ;
    }
}
