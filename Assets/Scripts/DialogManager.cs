using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public GameObject Home;
    public GameObject Enemy;
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
        homeInitPos = Home.transform.position;
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
        if (Input.anyKeyDown)
        {
            setNextDialog();
            if (currentIndex == 2)
            {
                Home.SetActive(false);
                Enemy.SetActive(true);
            }
            else if (currentIndex == 3)
            {
                Home.SetActive(true);
                Enemy.SetActive(false);
            }
            else if (currentIndex == 4)
            {
                Home.transform.SetPositionAndRotation(homeInitPos, Quaternion.identity);
            }
        }
        if (currentIndex == 3)
        {
            float newX = Home.transform.position.x + Mathf.Sin(Time.time * speed) * amount;
            Home.transform.SetPositionAndRotation(new Vector3(newX, Home.transform.position.y, Home.transform.position.z), Quaternion.identity);
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
