using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;


public class AdManager : MonoBehaviour, IUnityAdsListener
{
    private string playStoreID = "3628958";
    private string appStoreID = "3628959";

    private string interstitialAd = "video";
    private string rewardedVideoAd = "rewardedVideo";

    public bool isTargetPlayStore;
    public bool isTestAd;
    // Start is called before the first frame update
    private void Start()
    {
        Advertisement.AddListener(this);
        InitializeAdvertisement();
    }

    private void InitializeAdvertisement()
    {
        if (isTargetPlayStore) {Advertisement.Initialize(playStoreID, isTestAd); return; }
        Advertisement.Initialize(appStoreID, isTestAd);
    }

    public void PlayInterstitialAd()
    {
        if (!Advertisement.IsReady(interstitialAd)){return;}
        Advertisement.Show(interstitialAd);
    }

    public void PlayrewardedVideoAd()
    {
        if (!Advertisement.IsReady(rewardedVideoAd)){return;}
        Advertisement.Show(rewardedVideoAd);
    }

    public void OnUnityAdsReady(string placementId)
    {
        //throw new System.NotImplementedException();
    }
    public void OnUnityAdsDidError(string message)
    {
        //throw new System.NotImplementedException();
    }
    public void OnUnityAdsDidStart(string placementId)
    {
        // throw new System.NotImplementedException();
    }
    public void OnUnityAdsDidFinish(string placementId, ShowResult showresult)
    {
        switch(showresult) {
            case ShowResult.Failed:
                break;
            case ShowResult.Skipped:
                break;
            case ShowResult.Finished:
                if(placementId == rewardedVideoAd){Debug.Log ("Reward The Player");}
                if (placementId == interstitialAd){Debug.Log("Finished interstitial");}
                break;
        } 
        // throw new System.NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
