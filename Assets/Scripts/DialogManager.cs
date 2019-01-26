using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI speakerText;
    public TextMeshProUGUI contentText;
    private List<Dialog> dialogs;
    private int currentIndex;

    void Start()
    {
        currentIndex = -1;
        dialogs = new List<Dialog>();
        dialogs.Add(new Dialog("toto", "test"));
        dialogs.Add(new Dialog("titi", "test2"));
        dialogs.Add(new Dialog("tutu", "test3"));
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
            speakerText.text = currentDialog.speaker + " :";
            contentText.text = currentDialog.content;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
