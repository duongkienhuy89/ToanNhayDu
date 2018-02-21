using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ThaoTac : MonoBehaviour {

    public tk2dUIItem btnNumber0;
    public tk2dUIItem btnNumber1;
    public tk2dUIItem btnNumber2;
    public tk2dUIItem btnNumber3;
    public tk2dUIItem btnNumber4;
    public tk2dUIItem btnNumber5;
    public tk2dUIItem btnNumber6;
    public tk2dUIItem btnNumber7;
    public tk2dUIItem btnNumber8;
    public tk2dUIItem btnNumber9;
    public tk2dUIItem btnBack;
    public tk2dUIItem btnClose;
    public tk2dUIItem btnOdu1;
    public tk2dUIItem btnOdu2;
    public tk2dUIItem btnOdu3;
    public GameObject PhepToan;
    public string mPhepToan = "";
    public int mKetQua = 0;
   // public int mLoai = 0;
    float numColorA = 1f;
    float numColorCoinA = 1f;

    public string mDapAnChon="";

    public float speedLep;
    public float speedDu;
    float currentSpleep;
    bool checkDu = true;

    public float povisiStop;
    private float povisiStart;
    public tk2dTextMesh txtCoin;
    

    void doXuLy(string pDa)
    {
        if (GameController.Instance.currentState == GameController.State.INGAME)
        {
            SoundManager.Instance.PlayAudioCick();
            if (pDa.Equals("b"))
            {
                if (!mDapAnChon.Equals(""))
                {
                    mDapAnChon = mDapAnChon.Substring(0, mDapAnChon.Count() - 1);
                }
            }
            else if (pDa.Equals("x"))
            {
                mDapAnChon = "";
            }
            else
            {
                if (mDapAnChon.Count() < 4)
                {
                    mDapAnChon += pDa;
                }
                else
                {
                    SoundManager.Instance.Stop();
                    SoundManager.Instance.PlayAudioEmty();
                }
            }

            if (!mDapAnChon.Equals(""))
            {
                if (mDapAnChon.Count() <= 4)
                {
                    string tam = mPhepToan.Replace("?", "" + int.Parse(mDapAnChon));
                    PhepToan.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = tam;
                    if (int.Parse(mDapAnChon) == mKetQua)
                    {
                        GameController.Instance.currentState = GameController.State.INTRUE;
                        GameController.Instance.mDiem++;
                        txtCoin.gameObject.SetActive(true);
                        txtCoin.text = "" + GameController.Instance.mDiem;
                        StartCoroutine(WaitTimePlayAudioTrue(0.5f));
                        StartCoroutine(WaitTimeRePlay(1f));
                    }
                }

            }
            else
            {
                PhepToan.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = mPhepToan;
            }
        }
       



    }

    IEnumerator WaitTimeRePlay(float mtime)
    {
        yield return new WaitForSeconds(mtime);

        setData();
    }

    IEnumerator WaitTimePlayAudioTrue(float mtime)
    {
        yield return new WaitForSeconds(mtime);
        SoundManager.Instance.PlayAudioTrue();
    }



    void NhapNhay()
    {
        if (GameController.Instance.currentState == GameController.State.INTRUE)
        {
            if (numColorA > 0)
            {
                numColorA = numColorA - 0.02f;
                PhepToan.transform.GetChild(0).GetComponent<tk2dTextMesh>().color = new Color(PhepToan.transform.GetChild(0).GetComponent<tk2dTextMesh>().color.r, PhepToan.transform.GetChild(0).GetComponent<tk2dTextMesh>().color.g, PhepToan.transform.GetChild(0).GetComponent<tk2dTextMesh>().color.b, numColorA);
            }

            if (numColorCoinA > 0)
            {
                numColorCoinA = numColorCoinA - 0.03f;
                txtCoin.color = new Color(txtCoin.color.r, txtCoin.color.g, txtCoin.color.b, numColorCoinA);
            }
           
        }
    }

    #region Singleton
    void onClick_Numb0()
    {
        doXuLy("0");
    }
    void onClick_Numb1()
    {
        doXuLy("1");
    }
    void onClick_Numb2()
    {
        doXuLy("2");
    }
    void onClick_Numb3()
    {
        doXuLy("3");
    }
    void onClick_Numb4()
    {
        doXuLy("4");
    }
    void onClick_Numb5()
    {
        doXuLy("5");
    }
    void onClick_Numb6()
    {
        doXuLy("6");
    }
    void onClick_Numb7()
    {
        doXuLy("7");
    }
    void onClick_Numb8()
    {
        doXuLy("8");
    }
    void onClick_Numb9()
    {
        doXuLy("9");
    }
    void onClick_Back()
    {
        doXuLy("b");
    }
    void onClick_Colse()
    {
        doXuLy("x");
    }
    void onClick_Odu1()
    {
        setOdu(btnOdu1.gameObject);
    }
    void onClick_Odu2()
    {
        setOdu(btnOdu2.gameObject);
    }
    void onClick_Odu3()
    {
        setOdu(btnOdu3.gameObject);
    }
    #endregion

    void setOdu(GameObject odu)
    {
        if (checkDu && GameController.Instance.currentState==GameController.State.INGAME)
        {
            SoundManager.Instance.PlayAudioOdu();
            odu.SetActive(false);
            currentSpleep = speedDu;
            PhepToan.transform.GetChild(1).gameObject.SetActive(true);
            checkDu = false;
          
        }
    }

    void Move()
    {
        if ((GameController.Instance.currentState == GameController.State.INGAME || GameController.Instance.currentState == GameController.State.INTRUE) && PhepToan.transform.position.y > povisiStop)
        {
            PhepToan.transform.position += new Vector3(0f, -currentSpleep, 0f);

            if (GameController.Instance.currentState == GameController.State.INGAME)
            {
                if (PhepToan.transform.position.y <= povisiStop)
                {
                    GameController.Instance.currentState = GameController.State.GAMEOVER;
                    CameraDrop.Instance.shakeDuration = 2f;
                    SoundManager.Instance.PlayAudioGameOver();
                    StartCoroutine(WaitTimeGameOver(1f));
                }
            }
        }
    }

    IEnumerator WaitTimeGameOver(float mtime)
    {
        yield return new WaitForSeconds(mtime);
        PopUpController.instance.ShowGameOver(mPhepToan.Replace("?", "" + mKetQua));
        PopUpController.instance.HideThaoTac();
    }

    public void doPlayGame()
    {
        StartCoroutine(WaitTimePlay(0.1f));
    }

    IEnumerator WaitTimePlay(float mtime)
    {
        yield return new WaitForSeconds(mtime);
        GameController.Instance.mDiem = 0;
        btnOdu3.gameObject.SetActive(true);
        btnOdu2.gameObject.SetActive(true);
        btnOdu1.gameObject.SetActive(true);
        setData();
        
    }

    public void setData()
    {
        if (GameController.Instance.mDiem < 3)
        {
            doLoadData(5, 4, "+", 1);
        }
        else if (GameController.Instance.mDiem >= 3 && GameController.Instance.mDiem <=9)
        {
            doLoadData(9, 9, "+", 1);
        }
        else if (GameController.Instance.mDiem >= 10 && GameController.Instance.mDiem <= 12)
        {
            doLoadData(15, 9, "+", 1);
        }
        else if (GameController.Instance.mDiem >= 13 && GameController.Instance.mDiem <= 16)
        {
            doLoadData(9, 15, "+", 1);
        }
        else if (GameController.Instance.mDiem >= 17 && GameController.Instance.mDiem <= 22)
        {
            doLoadData(20, 20, "+", 1);
        }
        else if (GameController.Instance.mDiem >= 23 && GameController.Instance.mDiem <= 26)
        {
            doLoadData(40, 10, "+", 1);
        }
        else if (GameController.Instance.mDiem >= 27 && GameController.Instance.mDiem <= 30)
        {
            doLoadData(40, 40, "+", 1);
        }
        else if (GameController.Instance.mDiem >= 31 && GameController.Instance.mDiem <= 35)
        {
            doLoadData(50, 50, "+", 1);
        }
        else if (GameController.Instance.mDiem >= 36 && GameController.Instance.mDiem <= 40)
        {
            doLoadData(10, 10, "-", 1);
        }
        else if (GameController.Instance.mDiem >= 41 && GameController.Instance.mDiem <= 45)
        {
            doLoadData(50, 50, "-", 1);
        }
        else if (GameController.Instance.mDiem >= 46 && GameController.Instance.mDiem <= 54)
        {
            if (GameController.Instance.mDiem % 2 == 0)
            {
                doLoadData(50, 50, "+", 2);
            }
            else
            {
                doLoadData(50, 50, "-", 2);
            }
        }
        else if (GameController.Instance.mDiem >= 55 && GameController.Instance.mDiem <= 60)
        {
            if (GameController.Instance.mDiem % 3 == 0)
            {
                doLoadData(100, 100, "+", 2);
            }
            else if(GameController.Instance.mDiem % 4 == 0)
            {
                doLoadData(100, 100, "-", 2);
            }
            else if (GameController.Instance.mDiem % 2 == 0)
            {
                doLoadData(100, 100, "-", 1);
            }
            else
            {
                doLoadData(100, 100, "+", 1);
            }
        }
        else if (GameController.Instance.mDiem >= 61 && GameController.Instance.mDiem <= 70)
        {
            if (GameController.Instance.mDiem % 3 == 0)
            {
                doLoadData(300, 300, "+", 2);
            }
            else if (GameController.Instance.mDiem % 4 == 0)
            {
                doLoadData(300, 300, "-", 2);
            }
            else if (GameController.Instance.mDiem % 2 == 0)
            {
                doLoadData(300, 300, "-", 1);
            }
            else
            {
                doLoadData(300, 300, "+", 1);
            }
        }
        else if (GameController.Instance.mDiem >= 71 && GameController.Instance.mDiem <= 85)
        {
            if (GameController.Instance.mDiem % 4 == 0)
            {
                doLoadData(500, 500, "+", 2);
            }
            else if (GameController.Instance.mDiem % 3 == 0)
            {
                doLoadData(500, 500, "-", 2);
            }
            else if (GameController.Instance.mDiem % 2 == 0)
            {
                doLoadData(500, 500, "-", 1);
            }
            else
            {
                doLoadData(500, 500, "+", 1);
            }
        }
        else if (GameController.Instance.mDiem >= 86 && GameController.Instance.mDiem <= 100)
        {
            if (GameController.Instance.mDiem % 4 == 0)
            {
                doLoadData(1000, 1000, "+", 2);
            }
            else if (GameController.Instance.mDiem % 3 == 0)
            {
                doLoadData(1000, 1000, "-", 2);
            }
            else if (GameController.Instance.mDiem % 2 == 0)
            {
                doLoadData(1000, 1000, "-", 1);
            }
            else
            {
                doLoadData(1000, 1000, "+", 1);
            }
        }
        else if (GameController.Instance.mDiem >= 101 && GameController.Instance.mDiem <= 110)
        {
            doLoadData(9, 9, "x", 1);
        }
        else if (GameController.Instance.mDiem >= 111 && GameController.Instance.mDiem <= 125)
        {
            doLoadData(9, 9, "x", 2);
        }
        else if (GameController.Instance.mDiem >= 126 && GameController.Instance.mDiem <= 137)
        {
            if (GameController.Instance.mDiem % 2 == 0)
            {
                doLoadData(30, 9, "x", 1);
            }
            else
            {
                doLoadData(9, 30, "x", 1);
            }
        }
        else if (GameController.Instance.mDiem >= 138 && GameController.Instance.mDiem <= 150)
        {
            if (GameController.Instance.mDiem % 2 == 0)
            {
                doLoadData(40, 10, "x", 1);
            }
            else
            {
                doLoadData(40, 10, "x", 2);
            }
        }
        else if (GameController.Instance.mDiem >= 151 && GameController.Instance.mDiem <= 170)
        {
            doLoadData(9, 9, ":", 1);
        }
        else if (GameController.Instance.mDiem >= 171 && GameController.Instance.mDiem <= 180)
        {
            doLoadData(9, 9, ":", 2);
        }
        else
        {
            int chonso = UnityEngine.Random.Range(0, 10);
            if (chonso == 1)
            {
                doLoadData(4999, 4999, "+", 2);
            }
            else if (chonso == 2)
            {
                doLoadData(8000, 6000, "-", 1);
            }
            else if (chonso == 3)
            {
                doLoadData(8000, 6000, "-", 2);
            }
            else if (chonso == 4)
            {
                doLoadData(90, 90, "x", 1);
            }
            else if (chonso == 5)
            {
                doLoadData(90, 90, "x", 2);
            }
            else if (chonso == 6)
            {
                doLoadData(90, 90, ":", 1);
            }
            else if (chonso == 5)
            {
                doLoadData(90, 90, ":", 2);
            }
            else
            {
                doLoadData(4999, 4999, "+", 1);
            }
        }

        float minX = 10;
        float maxX;
        if (mPhepToan.Count() <= 9)
        {
            maxX = 163;
        }
        else if (mPhepToan.Count() <= 10)
        {
            maxX = 130;
        }
        else if (mPhepToan.Count() <= 11)
        {
            maxX = 93;
        }
        else if (mPhepToan.Count() <= 12)
        {
            maxX = 60;
        }
        else
        {
            maxX = 12;
        }
        

       

        PhepToan.transform.localPosition = new Vector3(UnityEngine.Random.Range(minX,maxX), povisiStart, PhepToan.transform.localPosition.z);
        PhepToan.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = "" + mPhepToan;
        #region Singleton
        if (GameController.Instance.mDiem % 7 == 0)
        {
            PhepToan.transform.GetChild(0).GetComponent<tk2dTextMesh>().color = new Color(float.Parse("" + 155) / 255, float.Parse("" + 255) / 255, float.Parse("" + 168) / 255, 1);
        }
        else if (GameController.Instance.mDiem % 5 == 0)
        {
            PhepToan.transform.GetChild(0).GetComponent<tk2dTextMesh>().color = new Color(float.Parse("" + 118) / 255, float.Parse("" + 232) / 255, float.Parse("" + 255) / 255, 1);
        }
        else if (GameController.Instance.mDiem % 3 == 0)
        {
            PhepToan.transform.GetChild(0).GetComponent<tk2dTextMesh>().color = new Color(float.Parse("" + 255) / 255, float.Parse("" + 181) / 255, float.Parse("" + 169) / 255, 1);
        }
        else if (GameController.Instance.mDiem % 2 == 0)
        {
            PhepToan.transform.GetChild(0).GetComponent<tk2dTextMesh>().color = new Color(float.Parse("" + 255) / 255, float.Parse("" + 183) / 255, float.Parse("" + 246) / 255, 1);
        }
        else if (GameController.Instance.mDiem % 9 == 0)
        {
            PhepToan.transform.GetChild(0).GetComponent<tk2dTextMesh>().color = new Color(1, 1, 1, 1);
        }
        else
        {
            PhepToan.transform.GetChild(0).GetComponent<tk2dTextMesh>().color = new Color(float.Parse("" + 241) / 255, float.Parse("" + 255) / 255, 0, 1);
        }
         #endregion
       
        mDapAnChon = "";    
        
        GameController.Instance.currentState = GameController.State.INGAME;
        numColorA = 1f;
        numColorCoinA = 1f;
        currentSpleep = speedLep;
        checkDu = true;
        txtCoin.gameObject.SetActive(false);
        PhepToan.transform.GetChild(1).gameObject.SetActive(false);
        
    }

    void doLoadData(int pSo1, int pSo2,string dau,int loai)
    {
        if (dau.Equals("+") || dau.Equals("-") || dau.Equals("x"))
        {
            int chon1 = UnityEngine.Random.Range(0, pSo1) + 1;
            int chon2 = UnityEngine.Random.Range(0, pSo2+1);

            switch (dau)
            {
                case "+":
                    mKetQua = chon1 + chon2;
                    break;
                case "-":
                    if (chon1 > chon2)
                    {
                        mKetQua = chon1 - chon2;
                    }
                    else
                    {
                        mKetQua = chon2 - chon1;
                    }
                    break;
                default:
                    mKetQua = chon1 * chon2;
                    break;
            }

            if (loai == 1)
            {
                if (dau.Equals("-"))
                {
                    if (chon1 > chon2)
                    {
                        mPhepToan = chon1 + " " + dau + " " + chon2 + " = ?";
                    }
                    else
                    {
                        mPhepToan = chon2 + " " + dau + " " + chon1 + " = ?";
                    }
                }
                else
                {
                    mPhepToan = chon1 + " " + dau + " " + chon2 + " = ?";
                }
            }
            else
            {
                if (mKetQua % 2 == 0)
                {
                    if (dau.Equals("-"))
                    {
                        if (chon1 > chon2)
                        {
                            mPhepToan = "? " + dau + " " + chon2 + " = "+mKetQua;
                            mKetQua = chon1;
                        }
                        else
                        {
                            mPhepToan = "? " + dau + " " + chon1 + " = " + mKetQua;
                            mKetQua = chon2;
                        }
                    }
                    else
                    {
                        mPhepToan = "? " + dau + " " + chon2 + " = " + mKetQua;
                        mKetQua = chon1;
                    }
                    //loai = 2;
                }
                else
                {

                    if (dau.Equals("-"))
                    {
                        if (chon1 > chon2)
                        {
                            mPhepToan = chon1 + " " + dau + " ? = "+mKetQua;
                            mKetQua = chon2;
                        }
                        else
                        {
                            mPhepToan = chon2 + " " + dau + " ? = " + mKetQua;
                            mKetQua = chon1;
                        }
                    }
                    else
                    {
                        mPhepToan = chon1 + " " + dau + " ? = " + mKetQua;
                        mKetQua = chon2;
                    }
                }
                //loai = 3;
            }


        }
        else
        {
            int chon1 = UnityEngine.Random.Range(1, pSo1) + 1;
            int chon2 = UnityEngine.Random.Range(1, pSo2) + 1;
            mKetQua = chon1 * chon2;
            if (loai == 1)
            {
                if (chon1 % 2 == 0)
                {
                    mPhepToan = mKetQua + " : " + chon2 + " = ?";
                    mKetQua = chon1;
                }
                else
                {
                    mPhepToan = mKetQua + " : " + chon1 + " = ?";
                    mKetQua = chon2;
                }
            }
            else
            {
                  if (chon1 % 2 == 0)
                    {
                        if (mKetQua % 2 == 0)
                        {

                            mPhepToan = "? : " + chon2 + " = " + chon1;
                        }
                        else
                        {
                            mPhepToan = "? : " + chon1 + " = " + chon2;
                        }
                        //loai = 2;
                    }
                    else
                    {
                        if (mKetQua % 2 == 0)
                        {
                            mPhepToan = mKetQua + " : ? = " + chon2;
                            mKetQua = chon1;
                        }
                        else
                        {
                            mPhepToan = mKetQua + " : ? = " + chon1;
                            mKetQua = chon2;
                        }
                        //loai = 3;
                    }
               
            }

        }
       // mLoai = loai;

    }


    // Use this for initialization
    void Start()
    {

        btnNumber0.OnClick += onClick_Numb0;
        btnNumber1.OnClick += onClick_Numb1;
        btnNumber2.OnClick += onClick_Numb2;
        btnNumber3.OnClick += onClick_Numb3;
        btnNumber4.OnClick += onClick_Numb4;
        btnNumber5.OnClick += onClick_Numb5;
        btnNumber6.OnClick += onClick_Numb6;
        btnNumber7.OnClick += onClick_Numb7;
        btnNumber8.OnClick += onClick_Numb8;
        btnNumber9.OnClick += onClick_Numb9;
        btnBack.OnClick += onClick_Back;
        btnClose.OnClick += onClick_Colse;
        btnOdu1.OnClick += onClick_Odu1;
        btnOdu2.OnClick += onClick_Odu2;
        btnOdu3.OnClick += onClick_Odu3;
        povisiStart = PhepToan.transform.localPosition.y;

        
	
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        NhapNhay();
	}
}
