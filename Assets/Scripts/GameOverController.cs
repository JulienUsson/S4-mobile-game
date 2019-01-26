using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public Animator earthAnimator;
    public GameObject canvas;
    public GameObject highway;
    private bool animationDone = false;
    void Update()
    {
        if (!animationDone && earthAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            animationDone = true;
            canvas.SetActive(true);
            highway.SetActive(true);
        }
        if (animationDone && Input.anyKeyDown)
        {
            SceneManager.LoadScene(1);
            return;
        }

    }
}
