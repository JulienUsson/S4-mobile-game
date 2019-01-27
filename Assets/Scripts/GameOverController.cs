using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public float delta = 1f;
    public Animator earthAnimator;
    public GameObject earth;
    public GameObject canvas;
    public GameObject highway;
    private bool animationDone = false;
    void Update()
    {
        if (delta > 0)
        {
            delta -= Time.deltaTime;
        }
        if (!animationDone && earthAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            animationDone = true;
            canvas.SetActive(true);
            earth.SetActive(false);
            highway.SetActive(true);
        }
        if (animationDone && Input.anyKeyDown && Input.GetKeyDown(KeyCode.Escape) && delta <= 0f)
        {
            SceneManager.LoadScene(1);
            return;
        }

    }
}
