using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class GetHintsRewardAd : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public static GetHintsRewardAd Instance;
    [SerializeField] string _androidAdUnitId = "Rewarded_Android";
    string _adUnitId = null; // This will remain null for unsupported platforms
    public int index;                       // public GameObject CoinsPanel;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        _adUnitId = _androidAdUnitId;
    }

    public void GetIndex(int a)
    {
        index = a;
    }

    // Load content to the Ad Unit:
    public void LoadAd()
    {
        // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
        Debug.Log("Loading Ad: " + _adUnitId);
        Advertisement.Load(_adUnitId, this);
    }

    // If the ad successfully loads, add a listener to the button and enable it:
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("Ad Loaded: " + adUnitId);
    }

    public void ShowAd()
    {
        Advertisement.Show(_adUnitId, this);
    }
    // Implement the Show Listener's OnUnityAdsShowComplete callback method to determine if the user gets a reward:
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Unity Ads Rewarded Ad Completed");
            // Grant a reward.

            if (index == 0)
            {
               // CurrencyManager.Instance.AddCoinBalance(50);
                //MainMenu.Instance.TotalDiamonds.text = CurrencyManager.Instance.ReturnCurrentDiamondBalance().ToString();
               // MainMenu.Instance.reward.SetActive(true);
               // LeanTween.moveLocalX(MainMenu.Instance.reward, 0f, 0.15f);

            }
            if (index == 1)
            {
                //ScreenManager.instance.GoBackScreenFromCameraView(ScreenType.RescueGamePlayScreen);
                //InputManager.Instance.canInput(0, true);
                //GamePlay.Instance.OnRescueDone(true);
                GameObject.Find("Canvas").transform.Find("GamePlay").Find("Block-Shape-Panel").gameObject.SetActive(true);
            }
            if (index == 2)
            {
               // CurrencyManager.Instance.AddCoinBalance(50);
            }
        
           
            LoadAd();
        }
    }

    // Implement Load and Show Listener error callbacks:
    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Use the error details to determine whether to try to load another ad.
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Use the error details to determine whether to try to load another ad.
    }

    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
        LoadAd();

    }
}
