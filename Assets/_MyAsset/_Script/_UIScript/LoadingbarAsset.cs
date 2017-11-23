using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingbarAsset : MonoBehaviour {
	private float waitTime = 3.0f; 
    public Slider UISlider;
    public Text Message;
    public static float LoadingValue;
	// Use this for initialization
	void Start () {
		UISlider.value = 0.0f;
		 LoadingValue = 0.0f;
		this.gameObject.SetActive(true);
//		LoadingValue = 1;
	}
	
	// Update is called once per frame
	void Update () {
		// objectRectTransform.sizeDelta = new Vector2(60, objectRectTransform.sizeDelta.y);
		UISlider.value += 1.0f / waitTime * Time.deltaTime;


        if( UISlider.value >= 1){
			Application.LoadLevel ("Scene_1_SceneMain");
        }
	}
}
