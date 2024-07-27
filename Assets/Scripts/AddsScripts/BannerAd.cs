using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAd : MonoBehaviour
{
    [SerializeField] BannerPosition _bannerPosition = BannerPosition.BOTTOM_CENTER;
    [SerializeField] string _androidAdUnitId;
    private string _adUnitId = null;

    private void Start()
    {
        _adUnitId = _androidAdUnitId;
        Advertisement.Banner.SetPosition(_bannerPosition);

    }

    public void ActivateBanner()
    {
        ShowBannerAd();
    }

    public void LoadBanner()
    {

        BannerLoadOptions options = new BannerLoadOptions
        {
            loadCallback = OnBannerLoaded,
            errorCallback = OnBannerError
        };

        Advertisement.Banner.Load(_adUnitId, options);
    }
    void OnBannerLoaded()
    {
        Debug.Log("Banner loaded");
        ShowBannerAd();
    }

    void OnBannerError(string message)
    {
        Debug.Log($"Banner Error: {message}");
    }

    void ShowBannerAd()
    {
        Debug.Log(_adUnitId + "BannerShow");
        Advertisement.Banner.Show(_adUnitId);
    }
    public void HideBannerAd()
    {
        Advertisement.Banner.Hide();
    }

}

