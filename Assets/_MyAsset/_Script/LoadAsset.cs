using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class LoadAsset : MonoBehaviour {
    // Use this for initialization
    void Start () { 
        string url = "https://wptest.bgbridalgallery.com.ph/wp-content/uploads/2017/09/spheresample";
        WWW www = new WWW(url);
        StartCoroutine (WaitforReq(www, "Sphere"));

        // string url = "https://wptest.bgbridalgallery.com.ph/wp-content/uploads/2017/09/villaenvironment";
        // WWW www = new WWW(url);
        // StartCoroutine (WaitforReq(www, "villaenvironment"));
        
        print("Start Asset Loaded");
    }
    
    // Update is called once per frame
    void Update () {
        
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