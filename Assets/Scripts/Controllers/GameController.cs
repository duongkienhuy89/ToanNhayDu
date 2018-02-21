using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {


    #region Singleton
    private static GameController instance;

    public static GameController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameController>();
            }
            return GameController.instance;
        }
        set { GameController.instance = value; }
    }
    #endregion


    public enum State
    {
        START,
        WAIT,
        INGAME,
        INTRUE,
        GAMEOVER
    }
    public State currentState;
    public int mDiem = 0;
    public int mMax = 0;
    public bool checkVol = true;
    public string ngonngu="";
    public int checkvip = 0;
    public GameObject bg1;
    public GameObject bg2;
    public GameObject bg3;
    public GameObject bg4;
    public GameObject bg5;

    public void doUpdateBG()
    {
        int chon = UnityEngine.Random.Range(0, 7);
        if (chon == 0)
        {
            bg1.SetActive(true);
            bg2.SetActive(false);
            bg3.SetActive(false);
            bg4.SetActive(false);
            bg5.SetActive(false);
        }
        else if (chon == 1) 
        {
            bg1.SetActive(false);
            bg2.SetActive(true);
            bg3.SetActive(false);
            bg4.SetActive(false);
            bg5.SetActive(false);
        }
        else if (chon == 2)
        {
            bg1.SetActive(false);
            bg2.SetActive(false);
            bg3.SetActive(true);
            bg4.SetActive(false);
            bg5.SetActive(false);
        }
        else if (chon == 3)
        {
            bg1.SetActive(false);
            bg2.SetActive(false);
            bg3.SetActive(false);
            bg4.SetActive(true);
            bg5.SetActive(false);
        }
        else 
        {
            bg1.SetActive(false);
            bg2.SetActive(false);
            bg3.SetActive(false);
            bg4.SetActive(false);
            bg5.SetActive(true);
        }
    }


    IEnumerator WaitTimeLoadData(float mtime)
    {
        yield return new WaitForSeconds(mtime);
        PopUpController.instance.HideSh();
        PopUpController.instance.ShowMainGame();
        currentState = State.WAIT;
   
    }


    void Awake()
    {
        Application.targetFrameRate = 30;
        QualitySettings.vSyncCount = -1;
        ngonngu = Application.systemLanguage.ToString().ToLower().Trim();
        checkvip = DataManager.GetVip();
    }

	// Use this for initialization
	void Start () {
        StartCoroutine(WaitTimeLoadData(3f));
        mMax = DataManager.GetHightLevel();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
