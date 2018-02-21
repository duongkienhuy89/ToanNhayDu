using UnityEngine;
using System.Collections;

public class DataManager  {

    private static string TAG_HIGHTLEVEL = "coin";
    private static string TAG_HIGHTNAME = "name";


    private static string TAG_VIP = "vippro";


    public static int GetVip()
    {
        if (PlayerPrefs.HasKey(TAG_VIP))
        {
            return PlayerPrefs.GetInt(TAG_VIP);
        }
        else
        {
            return 0;
        }
    }

    public static void SaveVip(int newHightScore)
    {
        PlayerPrefs.SetInt(TAG_VIP, newHightScore);
    }

    //Lay ra ten cua nguoi choi

    public static string GetName()
    {
        if (PlayerPrefs.HasKey(TAG_HIGHTNAME))
        {
            return PlayerPrefs.GetString(TAG_HIGHTNAME);
        }
        else
        {
            return "";
        }
    }

    //luu lai ten cua nguoi choi
    public static void SaveName(string newHightScore)
    {
        PlayerPrefs.SetString(TAG_HIGHTNAME, newHightScore);
    }


    //lay lai gia tri level da vuot qua.
    public static int GetHightLevel()
    {
        if (PlayerPrefs.HasKey(TAG_HIGHTLEVEL))
        {
            return PlayerPrefs.GetInt(TAG_HIGHTLEVEL);
        }
        else
        {
            return 0;
        }
    }

    //luu lai gia tri level da vuot qua.
    public static void SaveHightLevel(int newHightScore)
    {
        PlayerPrefs.SetInt(TAG_HIGHTLEVEL, newHightScore);
    }

}
