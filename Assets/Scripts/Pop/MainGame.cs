using UnityEngine;
using System.Collections;

public class MainGame : MonoBehaviour {

    public tk2dUIItem btbPlay;
    public tk2dUIItem btbVol;
	public tk2dUIItem btbDayBe;

	public void onClick_btbDayBe()
	{
        try
        {
		if (GameController.Instance.currentState == GameController.State.WAIT)
		{
			ShareRate.RateDayBe ();
		}
        }
        catch (System.Exception)
        {


            throw;
        }
	}
  

    public void onClick_btbPlay()
    {
        try
        {
        if (GameController.Instance.currentState == GameController.State.WAIT)
        {
            PopUpController.instance.HideMainGame();
            PopUpController.instance.ShowThaoTac();
            GameController.Instance.doUpdateBG();
            SoundManager.Instance.PlayAudioContinute();
        }
        }
        catch (System.Exception)
        {


            throw;
        }
    }
    public void onClick_btbVol()
    {
        try
        {
        if (GameController.Instance.checkVol)
        {
            SoundManager.Instance.PauseBGMusic();
            GameController.Instance.checkVol = false;
            btbVol.gameObject.GetComponent<tk2dSprite>().SetSprite("vollock");
        }
        else
        {
            SoundManager.Instance.rePlayBGMusic();
            GameController.Instance.checkVol = true;
            btbVol.gameObject.GetComponent<tk2dSprite>().SetSprite("volopen");
        }
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
        btbPlay.OnClick += onClick_btbPlay;
        btbVol.OnClick += onClick_btbVol;
		btbDayBe.OnClick += onClick_btbDayBe;
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
