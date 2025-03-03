using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboards : MonoBehaviour
{
    public void onLeaderboardBtnClick() 
    {
        LeanTween.moveLocalY(gameObject, -900f, 0.5f).setEase(LeanTweenType.animationCurve).setEaseInOutBounce().setOnComplete(() =>
        {
            Invoke("MoveBack",2f);
        });
    }

    void MoveBack() 
    {
        LeanTween.moveLocalY(gameObject, -2000f, 0.5f);
    }
}
