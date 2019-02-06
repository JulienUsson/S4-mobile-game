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
    public GameObject dialog;
    public GameObject looseText;
    private bool animationDone = false;
    private bool textDiplayed = false;
    private float currentDelta;

    void Start()
    {
        currentDelta = delta;
    }

    void Update()
    {
        if (currentDelta > 0)
        {
            currentDelta -= Time.deltaTime;
        }
        if (!animationDone && earthAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            animationDone = true;
            canvas.SetActive(true);
            earth.SetActive(false);
            highway.SetActive(true);
        }
        if (animationDone && Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Escape) && currentDelta <= 0f)
        {
            if (!textDiplayed)
            {
                textDiplayed = true;
                looseText.SetActive(false);
                dialog.SetActive(true);
            }
            else
            {
                SceneManager.LoadScene(1);
            }
            currentDelta = delta;
        }

    }
}
