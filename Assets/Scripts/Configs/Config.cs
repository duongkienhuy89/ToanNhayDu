using UnityEngine;
using System.Collections;


public class Config  {

#if UNITY_IPHONE
 
       public static string adsInIDGameOver = "ca-app-pub-5148482490300491/2810940969";

    public static string adsInIDBanner = "ca-app-pub-5148482490300491/2810940969";
   
   

#endif

#if UNITY_ANDROID


	public static string adsInIDGameOver = "ca-app-pub-3940256099942544/1033173712";

	public static string adsInIDBanner = "ca-app-pub-3940256099942544/6300978111";
                        

#endif

}
