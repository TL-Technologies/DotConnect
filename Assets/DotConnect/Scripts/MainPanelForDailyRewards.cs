using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPanelForDailyRewards : MonoBehaviour
{
    private void Start()
    {
        Invoke("AnimatePanel",1f);
    }

    void AnimatePanel() 
    {
        LeanTween.moveLocalX(gameObject, 0f, 0.35f).setEaseOutElastic();
    }
}
