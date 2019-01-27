using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public float delta = 1f;
    public GameObject home;
    public GameObject enemy;
    public GameObject highway;
    public Image speakerImage;
    public TextMeshProUGUI speakerText;
    public TextMeshProUGUI contentText;
    public float speed = 30.0f; //how fast it shakes
    public float amount = 10.0f; //how much it shakes
    private List<Dialog> dialogs;
    private int currentIndex;
    private Sprite generalSprite;
    private Sprite alienSprite;
    private Vector3 homeInitPos;

    void Start()
    {
        generalSprite = Resources.Load<Sprite>("general");
        alienSprite = Resources.Load<Sprite>("alien");
        currentIndex = -1;
        dialogs = new List<Dialog>();
        dialogs.Add(new Dialog() { speaker = "alien", content = "Dumb aliens ! What are you still doing here ? We have noticed you 10 years ago that you must have evacuated your planet by today," });
        dialogs.Add(new Dialog() { speaker = "alien", content = "the InterGalac733 will pass through it.\n Sorry but we break for nobody." });
        dialogs.Add(new Dialog() { speaker = "general", content = "Sorry to interrupt, but our radar has detected a very cute and unusual space object that will reach our planet in few minutes." });
        dialogs.Add(new Dialog() { speaker = "general", content = "It seems that we have a problem. We are under attack. Cute objects are emerging on our radar." });
        dialogs.Add(new Dialog() { speaker = "general", content = "We must protect our HOME. Officer please deploy the S4, the Super Secret Space Shield !" });
        setNextDialog();
    }

    // Update is called once per frame
    void Update()
    {
        if (delta > 0)
        {
            delta -= Time.deltaTime;
        }
        if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Escape) && delta <= 0f)
        {
            Animator homeAnimator = home.GetComponent<Animator>();
            setNextDialog();
            if (currentIndex == 1)
            {
                highway.SetActive(true);
                home.SetActive(false);
            }
            else if (currentIndex == 2)
            {
                highway.SetActive(false);
                enemy.SetActive(true);
            }
            else if (currentIndex == 3)
            {
                home.SetActive(true);
                enemy.SetActive(false);
                homeAnimator.Play("AnimationEarthHitted", 0);
            }
            else if (currentIndex == 4)
            {
                homeAnimator.Play("AnimationEarthOk-3pv", 0);
            }
        }
        if (currentIndex == 3)
        {
            float newX = Mathf.Sin(Time.time * speed) * amount;
            home.transform.position += new Vector3(newX, 0, 0);
        }
    }

    private void setNextDialog()
    {
        currentIndex++;
        if (currentIndex < dialogs.Count)
        {
            Dialog currentDialog = dialogs[currentIndex];
            speakerImage.sprite = currentDialog.speaker == "alien" ? alienSprite : generalSprite;
            speakerText.text = currentDialog.speaker.ToUpper() + " :";
            contentText.text = currentDialog.content.ToUpper();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
