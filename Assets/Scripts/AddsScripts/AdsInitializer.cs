using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] BannerAd _bannerAd;
    [SerializeField] IntersticialAd _intersticialAd;
    [SerializeField] string _androidGameId;
    [SerializeField] bool _testMode = true;
    private string _gameId;

    void Awake()
    {
#if UNITY_ANDROID
        _bannerAd = GetComponent<BannerAd>();
        _intersticialAd = GetComponent<IntersticialAd>();
        InitializeAds();
#endif
    }

    public void InitializeAds()
    {
        _gameId = _androidGameId;
        if (!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(_gameId, _testMode, this);
        }
    }


    public void OnInitializationComplete()
    {
        _intersticialAd.LoadAd();
        _bannerAd.LoadBanner();
        Debug.Log("Unity Ads initialization complete.");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }
}