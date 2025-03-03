using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InAppMegaDealScreen : MonoBehaviour
{
    public void onDealBtnClick()
    {
        LeanTween.moveLocalX(gameObject, 4000f, 0.5f);
        PlayerPrefs.SetInt("MegaDeal", 1);
        GameBug.DotConnect.GameManager.Instance.GetMegaDeal();
    }

    public void onXBtnClick()
    {
        LeanTween.moveLocalX(gameObject, 4000f, 0.5f);
    }
}
