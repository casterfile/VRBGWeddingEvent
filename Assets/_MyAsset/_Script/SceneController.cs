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
	using UnityEngine.Video;
	using UnityEngine.UI;

	public class SceneController : MonoBehaviour {
		public  GameObject[] objVideo,objVideoButton;
		private  VideoPlayer[] VideoPlayerControl;
		private string[] VideoURL;
		private GameObject BackgroundPicture, BackButton,VideoPanelContent,ButtonMoveUp,ButtonMoveDown;
		private float timeMouseDown = 0.0f;
		private int totalLoop = 0;
		private string NameAction = "";
		private int IntContentMove = 0;
		private int IntAction = -1;

		public RectTransform ContentVideos;

		public bool mouseDown = false;
	    void Start() {
			int ArrayLength = 9;
			totalLoop = ArrayLength - 1;
			objVideo = new GameObject[ArrayLength];
			objVideoButton = new GameObject[ArrayLength];
			VideoURL = new string[ArrayLength];
			VideoPlayerControl = new VideoPlayer[ArrayLength];
			FindAllVideos ();
			URLSetting ();

			BackButton.SetActive (false);
			ButtonMoveDown.SetActive (false);
			ButtonMoveUp.SetActive (true);
			ShowLimitedVideos (IntContentMove);
	    }

		void Update() {
			if (mouseDown == true) {
				timeMouseDown += Time.deltaTime;
//				print ("timeMouseDown: "+timeMouseDown);
				if(timeMouseDown >= 2){
					if(NameAction == "Video"){
						Controller("Video",IntAction);
						OnPointerUp ();
					}else if(NameAction == "BackMain"){
						Controller("BackMain",1);
						OnPointerUp ();
					}else if(NameAction == "ContentMoveUp"){
						Controller ("ContentMoveUp", 1);
						timeMouseDown = 0;
					}else if(NameAction == "ContentMoveDown"){
						Controller ("ContentMoveDown", 1);
						timeMouseDown = 0;
					}
				}
			}
		}

		public void SceneVideo(int number) {
			mouseDown = true;
			NameAction = "Video";
			IntAction = number;

		}

		public void SceneBackMain() {
			mouseDown = true;
			NameAction = "BackMain";
		}

		public void ContentMoveUp(){
			mouseDown = true;
			NameAction = "ContentMoveUp";
		}

		public void ContentMoveDown(){
			mouseDown = true;
			NameAction = "ContentMoveDown";
		}

		public void OnPointerUp(){
			mouseDown = false;
			timeMouseDown = 0;
		}

		private void Controller(string Output,int OutputNumber)
		{
			
			if(Output == "Video"){
				HideAllVideos ();
				objVideo[OutputNumber].SetActive (true);
				BackButton.SetActive (true);
				BackgroundPicture.SetActive (false);
				VideoPanelContent.SetActive (false);
			}

			if(Output == "BackMain"){
				HideAllVideos ();
				ShowAllVideosButtons ();
				BackButton.SetActive (false);
				VideoPanelContent.SetActive (true);
				BackgroundPicture.SetActive (true);
				ShowLimitedVideos (IntContentMove);
			}

			if(Output == "ContentMoveUp"){
				if(IntContentMove == 0 ){
					IntContentMove = 1;
					ShowLimitedVideos (IntContentMove);
					ContentVideos.anchoredPosition = new Vector2(0.0f, 220.0f);
					ButtonMoveDown.SetActive (true);
					ButtonMoveUp.SetActive (true);
				}
				else if(IntContentMove == 1){
					IntContentMove = 2;
					ShowLimitedVideos (IntContentMove);
					ContentVideos.anchoredPosition = new Vector2(0.0f, 430.0f);
					OnPointerUp ();// Put this at the end
					ButtonMoveDown.SetActive (true);
					ButtonMoveUp.SetActive (false);
				}

			}

			else if(Output == "ContentMoveDown"){
				if(IntContentMove == 1 ){
					IntContentMove = 0;
					ShowLimitedVideos (IntContentMove);
					ContentVideos.anchoredPosition = new Vector2(0.0f, 0.0f);
					OnPointerUp ();// Put this at the start
					ButtonMoveDown.SetActive (false);
					ButtonMoveUp.SetActive (true);
				}
				else if(IntContentMove == 2){
					IntContentMove = 1;
					ShowLimitedVideos (IntContentMove);
					ContentVideos.anchoredPosition = new Vector2(0.0f, 220.0f);
					ButtonMoveDown.SetActive (true);
					ButtonMoveUp.SetActive (true);
				}
			}

			print ("IntContentMove: "+ IntContentMove);

		}

		private void ShowLimitedVideos(int count){
			for (int x = 0; x <= totalLoop; x++) {
				objVideoButton [x].SetActive(false);
			}

			if(count == 0){
				objVideoButton [0].SetActive(true);
				objVideoButton [1].SetActive(true);
				objVideoButton [2].SetActive(true);
			}

			else if(count == 1){
				objVideoButton [3].SetActive(true);
				objVideoButton [4].SetActive(true);
				objVideoButton [5].SetActive(true);
			}

			else if(count == 2){
				objVideoButton [6].SetActive(true);
				objVideoButton [7].SetActive(true);
				objVideoButton [8].SetActive(true);
			}
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
				VideoPlayerControl[x] =  objVideo[x].GetComponent<VideoPlayer>();
				objVideoButton[x] =  GameObject.Find("VideoPanel ("+x+")");

				BackgroundPicture =  GameObject.Find("VRAssetStream/GamePlayAsset/VRGame/Photo");
				BackButton =  GameObject.Find("VRAssetStream/GamePlayAsset/VRGame/SceneController/BackButton");
				VideoPanelContent = GameObject.Find ("VideoPanelContent");
				ButtonMoveUp = GameObject.Find ("ButtonMoveUp");
				ButtonMoveDown = GameObject.Find ("ButtonMoveDown");
			}
		}



		void URLSetting(){
			VideoURL[0] = "https://wptest.bgbridalgallery.com.ph/wp-content/uploads/2017/10/Sample-Video.mp4";
			VideoURL[1] = "https://wptest.bgbridalgallery.com.ph/wp-content/uploads/2017/10/Sample-Video.mp4";
			VideoURL[2] = "https://wptest.bgbridalgallery.com.ph/wp-content/uploads/2017/10/Sample-Video.mp4";
			VideoURL[3] = "https://wptest.bgbridalgallery.com.ph/wp-content/uploads/2017/10/Sample-Video.mp4";
			VideoURL[4] = "https://wptest.bgbridalgallery.com.ph/wp-content/uploads/2017/10/Sample-Video.mp4";
			VideoURL[5] = "https://wptest.bgbridalgallery.com.ph/wp-content/uploads/2017/10/Sample-Video.mp4";
			VideoURL[6] = "https://wptest.bgbridalgallery.com.ph/wp-content/uploads/2017/10/Sample-Video.mp4";
			VideoURL[7] = "https://wptest.bgbridalgallery.com.ph/wp-content/uploads/2017/10/Sample-Video.mp4";
			VideoURL[8] = "https://wptest.bgbridalgallery.com.ph/wp-content/uploads/2017/10/Sample-Video.mp4";



			for (int x = 0; x <= totalLoop; x++) {
				VideoPlayerControl [x].source = VideoSource.Url;
				VideoPlayerControl [x].url = VideoURL[x];
			}
		}

  }
}
