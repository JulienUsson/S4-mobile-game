using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EarthController : MonoBehaviour
{
    public int earthPV = 3;
    private Animator anim;
    private StateAnim stateAnim;

    public enum StateAnim
    {
        Happy,
        Idle,
        Sad,
        Panic,
        Hitted
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetBool("Hitted"))
        {
            stateAnim = StateAnim.Hitted;
        }
        else if (!anim.GetBool("Hitted") && anim.GetInteger("PV") == 3)
        {
            stateAnim = StateAnim.Happy;
        }
        else if (!anim.GetBool("Hitted") && anim.GetInteger("PV") == 2)
        {
            stateAnim = StateAnim.Idle;
        }
        else if (!anim.GetBool("Hitted") && anim.GetInteger("PV") == 1)
        {
            stateAnim = StateAnim.Sad;
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        earthPV --;

        switch (stateAnim)
        {
            case StateAnim.Hitted:
                anim.SetBool("Hitted", true);
                break;
            case StateAnim.Happy:
                anim.SetBool("Hitted", false);
                anim.SetInteger("PV", 2);
                break;
            case StateAnim.Idle:
                anim.SetBool("Hitted", false);
                anim.SetInteger("PV", 1);
                break;
            case StateAnim.Sad:
                anim.SetBool("Hitted", false);
                anim.SetInteger("PV", 0);
                break;
        }

        if (earthPV < 1)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
