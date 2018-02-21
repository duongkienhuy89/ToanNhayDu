using UnityEngine;
using System.Collections;

public class PopUpController : MonoBehaviour {


    #region Singleton
    private static PopUpController _instance;

    public static PopUpController instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<PopUpController>();
            return _instance;
        }
    }
    #endregion

    public float showY;
    public float hideY;

    public float moveSpeed;
    public float moveDuration;
   // public AnimationCurve animationCuver;

    public Sha sh;
    public MainGame maingame;
    public ThaoTac thaotac;
    public GameOver gameOver;

 


    public void ShowGameOver(string pheptoan)
    {
        gameOver.setData(pheptoan);
        StartCoroutine(ieMoveDown(gameOver.gameObject,showY));
    }

    public void HideGameOver()
    {
        StartCoroutine(ieMoveUp(gameOver.gameObject, hideY));
    }

    public void ShowThaoTac()
    {
        thaotac.doPlayGame();
        StartCoroutine(ieMoveDown(thaotac.gameObject,showY));
    }

    public void HideThaoTac()
    {
        StartCoroutine(ieMoveUp(thaotac.gameObject, hideY));
    }

    public void ShowMainGame()
    {
        //StartCoroutine(ieMoveDown(maingame.gameObject, showY));
        maingame.gameObject.transform.position = new Vector3(maingame.gameObject.gameObject.transform.position.x, showY, maingame.gameObject.gameObject.transform.position.z);
    }

    public void HideMainGame()
    {
        StartCoroutine(ieMoveUp(maingame.gameObject, hideY));
    }

    public void ShowSh()
    {
        StartCoroutine(ieMoveDown(sh.gameObject, showY));
    }

    public void HideSh()
    {
        StartCoroutine(ieMoveUp(sh.gameObject, hideY));
    }


    //IEnumerator ieMoveDownHU(GameObject popup)
    //{

    //    float elapsed = 0;
    //    while (elapsed < moveDuration)
    //    {
    //        float scale = animationCuver.Evaluate(elapsed / moveDuration);
    //        popup.transform.position += Vector3.down
    //            * moveSpeed
    //            * Time.deltaTime
    //            * scale;
    //        elapsed += Time.deltaTime;

    //        yield return 0;
    //    }
    //   // popup.transform.position = new Vector3(popup.gameObject.transform.position.x, showY, popup.gameObject.transform.position.z);
    //}

    IEnumerator ieMoveDown(GameObject popup, float SY)
    {
        while (popup.transform.position.y >= SY)
        {
            popup.transform.position += Vector3.down
                * (moveSpeed)
                * Time.deltaTime;
            yield return 0;
        }
        popup.transform.position = new Vector3(popup.gameObject.transform.position.x, SY, popup.gameObject.transform.position.z);

    }

    IEnumerator ieMoveUp(GameObject popup, float HY)
    {
        while (popup.transform.position.y <= HY)
        {
            popup.transform.position += Vector3.up
                * (moveSpeed)
                * Time.deltaTime;
            yield return 0;
        }
        popup.transform.position = new Vector3(popup.gameObject.transform.position.x, HY, popup.gameObject.transform.position.z);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
