using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class LoadAsset : MonoBehaviour {
    // Use this for initialization
	void Start () { 
//      string url = "https://wptest.bgbridalgallery.com.ph/wp-content/uploads/2017/09/spheresample";
//		string url = "https://wptest.bgbridalgallery.com.ph/wp-content/uploads/2017/11/consoleoutput";
//		string url = "https://wptest.bgbridalgallery.com.ph/wp-content/uploads/2017/11/vrassetstream";

		#if UNITY_IOS
			string url = "https://wptest.bgbridalgallery.com.ph/wp-content/uploads/2017/11/vrassetstream";
		#endif

		#if UNITY_ANDROID
//			string url = "https://wptest.bgbridalgallery.com.ph/files/jp/Streaming/Android/vrassetstream";
			string url = "https://wptest.bgbridalgallery.com.ph/wp-content/uploads/2017/11/vrassetstream";
		#endif

        WWW www = new WWW(url);
		StartCoroutine (WaitforReq(www, "VRAssetStream"));
        
        print("Start Asset Loaded");
    }

    IEnumerator WaitforReq(WWW www, string AssetName){
        yield return www;
        AssetBundle bundle = www.assetBundle;
        
        if (www.error == null) {
            GameObject environmentThemes = (GameObject)bundle.LoadAsset (AssetName);
            Instantiate (environmentThemes);
        } else {
            Debug.Log (www.error);
            print("Error Loaded: "+www.error);
        }

        print("End Loaded");
    }

}