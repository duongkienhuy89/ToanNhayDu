using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class GameOver : MonoBehaviour {

    public tk2dUIItem btnContinute;
    public tk2dUIItem btnRank;
    public tk2dUIItem btnShare;

    public tk2dTextMesh txtPhepToan;
    public tk2dTextMesh txtScore;
    public tk2dTextMesh txtBest;
    public tk2dSprite BangGameOver;
	public tk2dSprite KhiCon;
    InterstitialAd interstitial;


    bool checkAd = true;

    BannerView bannerView;

    void LoadBanner()
    {
        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(Config.adsInIDBanner, AdSize.Banner, AdPosition.Top);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the banner with the request.
        bannerView.LoadAd(request);
    }
    public void HideBanner()
    {
        bannerView.Hide();
    }

    private void LoadAdsInterstitial()
    {
        // Initialize an InterstitialAd.
        interstitial = new InterstitialAd(Config.adsInIDGameOver);
        // Create an empty ad request.
        AdRequest requestIN = new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator).AddTestDevice("365BCE5DDF729BFD1E6E40D79CE8F42B").Build();
        // Load the interstitial with the request.
        interstitial.LoadAd(requestIN);
    }

    private void ShowAdsInterstitial()
    {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
    }

    public void HideAdsInterstitial()
    {
        interstitial.Destroy();
    }

    public void setData(string pheptoan)
    {
        try
        {
        if (GameController.Instance.checkvip != 10)
        {
            if (GameController.Instance.mDiem % 3 == 0)
            {
                checkAd = true;
                LoadAdsInterstitial();
            }
            else
            {
                checkAd = false;
                LoadBanner();
                bannerView.Show();
            }
        }
     

        txtPhepToan.text = pheptoan;
        txtScore.text = ""+GameController.Instance.mDiem;
        if (GameController.Instance.mDiem > GameController.Instance.mMax)
        {
            GameController.Instance.mMax = GameController.Instance.mDiem;
            DataManager.SaveHightLevel(GameController.Instance.mMax);
            SoundManager.Instance.PlayAudioTrue();
			KhiCon.SetSprite ("khihoi");
        }
		else if (GameController.Instance.mDiem == GameController.Instance.mMax)
        {
			KhiCon.SetSprite ("khixet");
            SoundManager.Instance.PlayAudioEmty();
		}else
		{
			KhiCon.SetSprite ("khikhoc");
			SoundManager.Instance.PlayAudioEmty();
		}
        txtBest.text = "" + GameController.Instance.mMax;

        if (GameController.Instance.mDiem % 7 == 0)
        {
            BangGameOver.color = new Color(float.Parse("" + 214) / 255, float.Parse("" + 154) / 255, float.Parse("" + 163) / 255, float.Parse("" + 230) / 255);
        }
        else if (GameController.Instance.mDiem % 5 == 0)
        {
            BangGameOver.color = new Color(float.Parse("" + 187) / 255, float.Parse("" + 118) / 255, float.Parse("" + 255) / 255, float.Parse("" + 230) / 255);
        }
        else if (GameController.Instance.mDiem % 3 == 0)
        {
            BangGameOver.color = new Color(float.Parse("" + 139) / 255, float.Parse("" + 149) / 255, float.Parse("" + 255) / 255, float.Parse("" + 230) / 255);
        }
        else if (GameController.Instance.mDiem % 2 == 0)
        {
            BangGameOver.color = new Color(float.Parse("" + 174) / 255, float.Parse("" + 174) / 255, float.Parse("" + 176) / 255, float.Parse("" + 230) / 255);
        }
        else if (GameController.Instance.mDiem % 9 == 0)
        {
            BangGameOver.color = new Color(1, 1, 1, float.Parse("" + 230) / 255);
        }
        else
        {
            BangGameOver.color = new Color(float.Parse("" + 24) / 255, float.Parse("" + 162) / 255, float.Parse("" + 208) / 255, float.Parse("" + 230) / 255);
        }
        }
        catch (System.Exception)
        {


            throw;
        }
    }

    void onClick_Continute()
    {
        try
        {
        if (GameController.Instance.checkvip != 10 && checkAd)
        {
            ShowAdsInterstitial();
        }
        else if (GameController.Instance.checkvip != 10 && checkAd==false)
        {
            HideBanner();
        }
        PopUpController.instance.HideGameOver();
        PopUpController.instance.ShowMainGame();
        GameController.Instance.currentState = GameController.State.WAIT;
        }
        catch (System.Exception)
        {


            throw;
        }

    }
    void onClick_Rank()
    {
        try
        {
        ShareRate.Rate();
        }
        catch (System.Exception)
        {


            throw;
        }
    }
    void onClick_Share()
    {
        try
        {
        ShareRate.Share();
        }
        catch (System.Exception)
        {


            throw;
        }
    }

	// Use this for initialization
	void Start () {

        try
        {
        btnContinute.OnClick += onClick_Continute;
        btnRank.OnClick += onClick_Rank;
        btnShare.OnClick += onClick_Share;
        LoadAdsInterstitial();
        }
        catch (System.Exception)
        {


            throw;
        }
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
