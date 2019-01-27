using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDoneController : MonoBehaviour
{
    public float delta = 1f;

    void Update()
    {
        if (delta > 0)
        {
            delta -= Time.deltaTime;
        }
        if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Escape) && delta <= 0f)
        {
            SceneManager.LoadScene(1);
        }
    }
}
