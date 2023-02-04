using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdManager : MonoBehaviour
{
    public InterstitialAd interstitialAd;
    void Start()
    {
        MobileAds.Initialize(initStatus => { });
        RequestInterstitial();
    }

    public void ShowAd()
    {
        if (interstitialAd.IsLoaded())
        {
            interstitialAd.Show();
        }
    }
    public void RequestInterstitial()
    {
#if UNITY_ANDROID
        string reklam_ID = "ca-app-pub-3931682467866698/8267437442";
#elif UNITY_IPHONE
        string reklam_ID = "ca-app-pub-3931682467866698~4054243156";
#else
        string reklam_ID = "unexpected_platform";
#endif

        interstitialAd = new InterstitialAd(reklam_ID);
        AdRequest ADrequest = new AdRequest.Builder().Build();

        interstitialAd.LoadAd(ADrequest);
    }
}
