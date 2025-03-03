using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateUsScreen : MonoBehaviour
{
    public void onRateUsBtnClick() 
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.gamebug.connectify.puzzle.game");
        LeanTween.moveLocalX(gameObject, 2000f, 0.5f);
        PlayerPrefs.SetInt("Rated", 1);
    }

    public void onXBtnClick() 
    {
        LeanTween.moveLocalX(gameObject, 2000f, 0.5f);
    }
}
