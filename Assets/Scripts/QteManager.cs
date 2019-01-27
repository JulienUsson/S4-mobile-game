using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QteManager : MonoBehaviour
{
    public int qteNumber = 10;
    public Image qteImage;
    public Image failImage;
    public float qteAnimationTime = 0.3f;
    public float qteTime = 5f;
    public float failTime = 0.5f;
    public float timerToWin = 2.5f;

    private List<XboxKeyEnum> keys;
    private Sprite aSprite;
    private Sprite bSprite;
    private Sprite xSprite;
    private Sprite ySprite;
    private float qteAnimation = 0f;
    public float fail = 0f;

    void Start()
    {
        aSprite = Resources.Load<Sprite>("xbox_a");
        bSprite = Resources.Load<Sprite>("xbox_b");
        xSprite = Resources.Load<Sprite>("xbox_x");
        ySprite = Resources.Load<Sprite>("xbox_y");

        keys = new List<XboxKeyEnum>();
        for (int i = 0; i < qteNumber; i++)
        {
            keys.Add(GetRandomKey());
        }

        ShowKeys();
    }

    // Update is called once per frame
    void Update()
    {
        if (keys.Count == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (qteTime > 0)
        {
            qteTime -= Time.deltaTime;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }

        if (qteAnimation > 0)
        {
            qteAnimation -= Time.deltaTime;
            if (qteAnimation <= 0)
            {
                qteImage.enabled = true;
            }
        }
        if (fail > 0)
        {
            fail -= Time.deltaTime;
            if (fail <= 0)
            {
                failImage.enabled = false;
            }
        }

        
        XboxKeyEnum currentKey = keys[0];

        if ((Input.GetButtonDown("XboxA") && currentKey != XboxKeyEnum.XBOX_A
      || Input.GetButtonDown("XboxB") && currentKey != XboxKeyEnum.XBOX_B
      || Input.GetButtonDown("XboxX") && currentKey != XboxKeyEnum.XBOX_X
      || Input.GetButtonDown("XboxY") && currentKey != XboxKeyEnum.XBOX_Y) && fail <= 0f)
        {
            fail = failTime;
            failImage.enabled = true;
            return;
        }


        if ((Input.GetButtonDown("XboxA") && currentKey == XboxKeyEnum.XBOX_A
        || Input.GetButtonDown("XboxB") && currentKey == XboxKeyEnum.XBOX_B
        || Input.GetButtonDown("XboxX") && currentKey == XboxKeyEnum.XBOX_X
        || Input.GetButtonDown("XboxY") && currentKey == XboxKeyEnum.XBOX_Y)
        && fail <= 0f)
        {
            keys.RemoveAt(0);
            qteAnimation = qteAnimationTime;
            qteImage.enabled = false;
            ShowKeys();
        }
    }

    static private XboxKeyEnum GetRandomKey()
    {
        var v = Enum.GetValues(typeof(XboxKeyEnum));
        return (XboxKeyEnum)v.GetValue(UnityEngine.Random.Range(0, v.Length));
    }

    private Sprite GetSpriteForKey(XboxKeyEnum key)
    {
        switch (key)
        {
            case XboxKeyEnum.XBOX_A:
                return aSprite;
            case XboxKeyEnum.XBOX_B:
                return bSprite;
            case XboxKeyEnum.XBOX_X:
                return xSprite;
            case XboxKeyEnum.XBOX_Y:
                return ySprite;
        }
        return null;
    }

    private void ShowKeys()
    {
        try
        {
            qteImage.sprite = GetSpriteForKey(keys[0]);
        }
        catch (ArgumentOutOfRangeException)
        {
            qteImage.enabled = false;
        }
    }


    IEnumerator Timer()
    {
        yield return new WaitForSeconds(timerToWin);
    }
}
