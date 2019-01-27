using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDoneController : MonoBehaviour
{
    public float delta = 1f;
    public GameObject dialog;
    public GameObject win;
    private bool winShowed = false;

    void Update()
    {
        if (delta > 0)
        {
            delta -= Time.deltaTime;
        }
        if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Escape) && delta <= 0f)
        {
            if (!winShowed)
            {
                winShowed = true;
                win.SetActive(false);
                dialog.SetActive(true);
            }
            else
            {
                SceneManager.LoadScene(1);
            }
            delta = 1f;
        }
    }
}
