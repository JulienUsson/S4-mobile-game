using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public Image speakerImage;
    public TextMeshProUGUI speakerText;
    public TextMeshProUGUI contentText;
    private List<Dialog> dialogs;
    private int currentIndex;
    private Sprite generalSprite;
    private Sprite alienSprite;

    void Start()
    {
        generalSprite = Resources.Load<Sprite>("general");
        alienSprite = Resources.Load<Sprite>("alien");

        currentIndex = -1;
        dialogs = new List<Dialog>();
        dialogs.Add(new Dialog() { speaker = "alien", content = "Dumb aliens ! What are you still doing here ? We, the space highway company, have noticed you 10 years ago." });
        dialogs.Add(new Dialog() { speaker = "alien", content = " You must have evacuated your planet by today as the InterGalac733 will pass through it." });
        dialogs.Add(new Dialog() { speaker = "alien", content = "Sorry but we break for nobody." });
        dialogs.Add(new Dialog() { speaker = "general", content = "Sorry to interrupt, but our radar has detected a very cute and unusual space object that will reach our planet in few minutes." });
        dialogs.Add(new Dialog() { speaker = "general", content = "It seems that we have a problem. We are under attack. Cute objects are emerging on our radar. What should we do ?" });
        dialogs.Add(new Dialog() { speaker = "general", content = "We must protect our HOME. General please deploy the S4, the Super Secret Space Shield !" });
        setNextDialog();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            setNextDialog();
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
