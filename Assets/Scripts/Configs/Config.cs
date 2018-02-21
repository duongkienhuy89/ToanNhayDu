using UnityEngine;
using System.Collections;


public class Config  {

#if UNITY_IPHONE
 
       public static string adsInIDGameOver = "ca-app-pub-5148482490300491/2810940969";

    public static string adsInIDBanner = "ca-app-pub-5148482490300491/2810940969";
   
   

#endif

#if UNITY_ANDROID


    public static string adsInIDGameOver = "ca-app-pub-2577061470072962/5022372734";

    public static string adsInIDBanner = "ca-app-pub-2577061470072962/3964441933";
                        

#endif

}
