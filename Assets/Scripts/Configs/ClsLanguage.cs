using UnityEngine;
using System.Collections;

public class ClsLanguage  {

    public static string doContentBuyDu()
    {
        string vaothi = "";
        if (GameController.Instance.ngonngu.Equals("vietnamese"))
        {
             vaothi = "1.Nhận được thêm 2 cái (Tổng cộng là 3 cái dù trong mỗi lần chơi). \n\n2.Không bị làm phiền bởi quảng cáo";
        }
        else if (GameController.Instance.ngonngu.Equals("german"))
        {
            vaothi = "1.Get 2 Fallschirme (insgesamt 3 Fallschirme, jedes Spiel). \n\n2.No Anzeigen";
        }
        else
        {
            vaothi = "1.Get 2 parachutes (total of 3 parachutes, each play). \n\n2.No ads";
        }

        return vaothi;
    }
    public static string doTitleBuyDu()
    {
        string vaothi = "";
        if (GameController.Instance.ngonngu.Equals("vietnamese"))
        {
            vaothi = "Mua Thêm Dù";
        }
        else if (GameController.Instance.ngonngu.Equals("german"))
        {
            vaothi = "Kaufen Fallschirm";
        }
        else
        {
            vaothi = "Buy Parachute";
        }

        return vaothi;
    }
    public static string doContinute()
    {
        string vaothi = "";
        if (GameController.Instance.ngonngu.Equals("vietnamese"))
        {
            vaothi = "Tiếp tục";
        }
        else if (GameController.Instance.ngonngu.Equals("german"))
        {
            vaothi = "Fortsetzen";
        }
        else
        {
            vaothi = "Continute";
        }

        return vaothi;
    }
    public static string doCancel()
    {
        string vaothi = "";
        if (GameController.Instance.ngonngu.Equals("vietnamese"))
        {
            vaothi = "Hủy bỏ";
        }
        else if (GameController.Instance.ngonngu.Equals("german"))
        {
            vaothi = "Stornieren";
        }
        else
        {
            vaothi = "Cancel";
        }

        return vaothi;
    }
}
