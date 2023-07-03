using UnityEngine;
using GoogleMobileAds.Api;
public class AdsInitializer : MonoBehaviour
{
    private BannerView _bannerView;
        // These ad units are configured to always serve test ads.
    #if UNITY_ANDROID
        private string _adUnitId = "ca-app-pub-3940256099942544/6300978111"; //CHANGE THIS WHEN ON THE PLAY STORE
    #elif UNITY_IPHONE
        private string _adUnitId = "ca-app-pub-3940256099942544/2934735716";
    #else
        private string _adUnitId = "unused";
    #endif

    [System.Obsolete]
    private void Start() {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            CreateBannerView();
        });


        
    }

    [System.Obsolete]
    public void CreateBannerView()
    {
        Debug.Log("Creating banner view");

        // If we already have a banner, destroy the old one.
        if (_bannerView != null)
        {
            _bannerView.Destroy();
        }

        // Create a 320x50 banner at top of the screen
        _bannerView = new BannerView(_adUnitId, AdSize.Banner, AdPosition.Top);
        AdRequest request = new AdRequest.Builder().Build();

        _bannerView.LoadAd(request);
    }

    
}
