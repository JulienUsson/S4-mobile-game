using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public float delta = 1f;
    public Animator earthAnimator;
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
            highway.SetActive(true);
        }
        if (animationDone && Input.anyKeyDown && delta <= 0f)
        {
            SceneManager.LoadScene(1);
            return;
        }

    }
}
