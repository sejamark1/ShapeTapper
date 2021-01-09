using UnityEngine;
using UnityEngine.Advertisements;

public class adsManager : MonoBehaviour, IUnityAdsListener
{
    /*    private string appStoreID = "3770990";*/
    private string playStoreID = "3770991";
    private string interstitialAd = "video";
    private string rewardedVideoAd = "rewardedVideo";
    private bool isTestMode = false; 
    public scoreBoard scoreboard;
    private void Start()
    {
        scoreboard = FindObjectOfType<scoreBoard>();

        IntitialiseAdsAndriod();
    }

    private void IntitialiseAdsAndriod()
    {
        Advertisement.Initialize(playStoreID, isTestMode);
    }

    public void PlayInterstitialAd()
    {
        if (!Advertisement.IsReady(interstitialAd)) { return; } // if the ad is not ready to deploy then end it here
        Advertisement.Show(interstitialAd);


    }
    public void PlayRewardedAd()
    {
        if (!Advertisement.IsReady(rewardedVideoAd)) { return; } // if the ad is not ready to deploy then end it here
        Advertisement.Show(rewardedVideoAd);
        scoreboard.addDamage(3);
    }

    public void OnUnityAdsReady(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Ads"); 
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        print("CalledAds");
        switch (showResult)
        {
            case ShowResult.Failed:
                break;
            case ShowResult.Skipped:
/*                if (placementId == rewardedVideoAd)
                {
                    scoreboard.addDamage(3);
                }*/
                break;
            case ShowResult.Finished:
                break;


        }






    }
}
