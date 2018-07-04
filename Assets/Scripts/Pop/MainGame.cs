using UnityEngine;
using System.Collections;

public class MainGame : MonoBehaviour {

    public tk2dUIItem btbPlay;
    public tk2dUIItem btbVol;
	public tk2dUIItem btbDayBe;

	public void onClick_btbDayBe()
	{
		if (GameController.Instance.currentState == GameController.State.WAIT)
		{
			ShareRate.RateDayBe ();
		}
	}
  

    public void onClick_btbPlay()
    {
        if (GameController.Instance.currentState == GameController.State.WAIT)
        {
            PopUpController.instance.HideMainGame();
            PopUpController.instance.ShowThaoTac();
            GameController.Instance.doUpdateBG();
            SoundManager.Instance.PlayAudioContinute();
        }
    }
    public void onClick_btbVol()
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

  

	// Use this for initialization
	void Start () {
        btbPlay.OnClick += onClick_btbPlay;
        btbVol.OnClick += onClick_btbVol;
		btbDayBe.OnClick += onClick_btbDayBe;
     

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
