using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinWheelAnimation : MonoBehaviour
{
    public void AnimateSpinWheel() 
    {
        LeanTween.moveLocalX(gameObject, 0, 0.35f).setEaseOutElastic();
    }
}
