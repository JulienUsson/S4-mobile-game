using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EarthController : MonoBehaviour
{
    public int earthPV = 3;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator timerWaiting()
    {
        yield return new WaitForSeconds(1.5f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        earthPV--;

        anim.SetBool("Hitted", true);

        anim.SetInteger("PV", earthPV);

        if (earthPV < 1)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


    }
}
