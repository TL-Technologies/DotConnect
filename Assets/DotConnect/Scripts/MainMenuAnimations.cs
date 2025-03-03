using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAnimations : MonoBehaviour
{
	public static MainMenuAnimations instance;
    private void Awake()
    {
		instance = this;
		if (PlayerPrefs.GetInt("FirstPlay") == 1) 
		{
			OnAnimatedUIIn();
		}
    }

    public GameObject Top, Play, Buttom, Left, Right, Title;


	public void OnAnimatedUIIn()
	{
		StartCoroutine(AnimateIn());
	}

	IEnumerator AnimateIn() 
	{
		yield return new WaitForSeconds(1f);
		LeanTween.scale(Play, Vector2.one, 0.5f).setEase(LeanTweenType.animationCurve).setEaseOutBounce().setOnComplete(()=> 
		{
			PlayerPrefs.SetInt("FirstPlay", 1);
		});
		LeanTween.moveLocalY(Top, 0, 0.5f).setEase(LeanTweenType.animationCurve).setEaseInOutBounce();
		LeanTween.moveLocalY(Buttom, -687, 0.5f).setEase(LeanTweenType.animationCurve).setEaseInOutBounce();
		LeanTween.moveLocalX(Left, -400, 0.5f).setEase(LeanTweenType.animationCurve).setEaseInOutBounce();
		LeanTween.moveLocalX(Right, 400, 0.5f).setEase(LeanTweenType.animationCurve).setEaseInOutBounce();
		LeanTween.moveLocalY(Title, 650, 0.5f).setEase(LeanTweenType.animationCurve).setEaseInOutBounce();
	}

	public void onAnimateOut()
	{
		StartCoroutine(AnimateOut());
	}

	IEnumerator AnimateOut()
	{
		yield return new WaitForSeconds(0.1f);
		LeanTween.scale(Play, Vector2.zero, 0.5f).setEase(LeanTweenType.animationCurve).setEaseOutBounce().setOnComplete(()=> 
		{
			GameBug.ScreenManager.Instance.Show("bundles");
		});
		//LeanTween.moveLocalY(Top, 0, 0.5f).setEase(LeanTweenType.animationCurve).setEaseInOutBounce();
		LeanTween.moveLocalY(Buttom, -1687, 0.5f).setEase(LeanTweenType.animationCurve).setEaseInOutBounce();
		LeanTween.moveLocalX(Left, -1300, 0.5f).setEase(LeanTweenType.animationCurve).setEaseInOutBounce();
		LeanTween.moveLocalX(Right, 1300, 0.5f).setEase(LeanTweenType.animationCurve).setEaseInOutBounce();
		LeanTween.moveLocalY(Title, 1500, 0.5f).setEase(LeanTweenType.animationCurve).setEaseInOutBounce();
	}
}
