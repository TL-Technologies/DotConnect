using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorials : MonoBehaviour
{
    public static Tutorials instance;
    public Image tutHand;
    public Sprite[] handSprites;
    private void Awake()
    {
        instance = this;
        tutHand.SetNativeSize();
    }

    public void OnLevelStart()
    {
        var currentLevel = GameBug.DotConnect.GameManager.Instance.ActiveLevelData.LevelIndex + 1;
        if (PlayerPrefs.GetInt("PreviousSelectedBundle") == 5)
        {
            if (currentLevel == 1 || currentLevel == 2)
            {
                tutHand.gameObject.SetActive(true);
                StartCoroutine(animteHand());
            }
            else
            {
                tutHand.gameObject.SetActive(false);
            }
        }
        else 
        {
            tutHand.gameObject.SetActive(false);
        }
    }

    IEnumerator animteHand() 
    {
        yield return new WaitForSeconds(0.25f);
        for (int i = 0; i<= handSprites.Length -1; i++)
        {
            yield return new WaitForSeconds(0.25f);
            tutHand.sprite = handSprites[i];
        }
        yield return new WaitForSeconds(0.25f);
        StartCoroutine(animteHand());
    }
}
