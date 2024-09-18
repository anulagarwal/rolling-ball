using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.SceneManagement;

public class AdsManager : MonoBehaviour
{
    private BannerView bannerView;
    private InterstitialAd interstitial;

    public static AdsManager Instance;

    private string appId = "ca-app-pub-2470247700967862~9764865990";
    private string bannerId = "ca-app-pub-3940256099942544/6300978111";
    private string intertestialId = "ca-app-pub-3940256099942544/1033173712";

    void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
            Instance = this;

        DontDestroyOnLoad(gameObject);

        MobileAds.Initialize(appId);
        //RequestBanner();
        RequestInterstitial();

        //ShowAdmobBanner();
    }

    public void ShowAdmobBanner()
    {
        bannerView.Show();
    }

    public void ShowAdmobInterstitial()
    {
        StartCoroutine(ShowAd());
    }

    IEnumerator ShowAd()
    {
        if (Instance.interstitial.IsLoaded())
        {
            Instance.interstitial.Show();
        }

        RequestInterstitial();

        yield return null;
    }

    private void RequestBanner()
    {
        StartCoroutine(ShowBanner());
    }

    IEnumerator ShowBanner()
    {
        this.bannerView = new BannerView(bannerId, AdSize.Banner, AdPosition.Bottom);

        AdRequest request = new AdRequest.Builder().Build();

        this.bannerView.LoadAd(request);

        yield return null;
    }

    private void RequestInterstitial()
    {
        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(intertestialId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }
}
