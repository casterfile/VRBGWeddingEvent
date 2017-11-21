using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class LoadAssetStreaming : MonoBehaviour {

	//Code for unity 2017.2
	/*
	void Start() {
		StartCoroutine(GetAssetBundle());
	}

	IEnumerator GetAssetBundle() {
		UnityWebRequest www = UnityWebRequest.GetAssetBundle("http://www.my-server.com/myData.unity3d");
		yield return www.SendWebRequest();

		if(www.isNetworkError || www.isHttpError) {
			Debug.Log(www.error);
		}
		else {
			AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(www);
		}
	}
	*/
}
