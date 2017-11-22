// Copyright 2014 Google Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace GoogleVR.GVRDemo {
  	using UnityEngine;
	using System.Collections;

	public class SceneController : MonoBehaviour {
		private  GameObject[] objVideo,objVideoButton;
		private GameObject BackgroundPicture, BackButton;
		private float timeMouseDown = 0.0f;
		private int totalLoop = 0;
		private string NameAction = "";
		private int IntAction = -1;
		public bool mouseDown = false;
	    void Start() {
			int ArrayLength = 3;
			totalLoop = ArrayLength - 1;
			objVideo = new GameObject[ArrayLength];
			objVideoButton = new GameObject[ArrayLength];
			FindAllVideos ();

			BackButton.SetActive (false);
	    }

		void Update() {
			if (mouseDown == true) {
				timeMouseDown += Time.deltaTime;
				print ("timeMouseDown: "+timeMouseDown);
				if(timeMouseDown >= 3){
					if(NameAction == "Video"){
						StartCoroutine(Controller("Video",IntAction));
						OnPointerUp ();
					}else if(NameAction == "BackMain"){
						StartCoroutine(Controller("BackMain",1));
						OnPointerUp ();
					}
				}
			}
		}

		public void SceneVideo(int number) {
			mouseDown = true;
			NameAction = "Video";
			IntAction = number;
//			if(timeMouseDown >= 3){
//				StartCoroutine(Controller("Video",number));
//			}

		}

		public void SceneBackMain() {
			mouseDown = true;
			NameAction = "BackMain";
//			if(timeMouseDown >= 3){
//				StartCoroutine(Controller("BackMain",1));
//			}

		}

		public void OnPointerUp(){
			mouseDown = false;
			timeMouseDown = 0;
		}

		IEnumerator Controller(string Output,int OutputNumber)
		{
			HideAllVideos ();
			if(Output == "Video"){
				objVideo[OutputNumber].SetActive (true);
				BackButton.SetActive (true);
				BackgroundPicture.SetActive (false);
			}

			if(Output == "BackMain"){
				ShowAllVideosButtons ();
				BackButton.SetActive (false);
				BackgroundPicture.SetActive (true);
			}
			yield return new WaitForSeconds(1.5f);

		}

		private void HideAllVideos(){
			for (int x = 0; x <= totalLoop; x++) {
				objVideo [x].SetActive(false);
				objVideoButton [x].SetActive(false);
			}
		}

		private void ShowAllVideosButtons(){
			for (int x = 0; x <= totalLoop; x++) {
				objVideoButton [x].SetActive(true);
			}
		}


		private void FindAllVideos(){
			for (int x = 0; x <= totalLoop; x++) {
				objVideo[x] =  GameObject.Find("VRAssetStream/GamePlayAsset/VRGame/VideoList/Videos ("+x+")");
				BackgroundPicture =  GameObject.Find("VRAssetStream/GamePlayAsset/VRGame/Photo");
				BackButton =  GameObject.Find("VRAssetStream/GamePlayAsset/VRGame/SceneController/BackButton");
				objVideoButton[x] =  GameObject.Find("VRAssetStream/GamePlayAsset/VRGame/SceneController/VideoPanel ("+x+")");
			}
		}

  }
}
