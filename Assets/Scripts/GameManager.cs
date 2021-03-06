﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public bool isStart = false;
	public bool endGame = false;
	public GameObject initgem;
	private GUISkin skin;
	public Texture retry;
	public Texture rateus;
	// Use this for initialization
	void Start () {
		skin = Resources.Load("GUISkin") as GUISkin;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp("space") || Input.GetMouseButtonDown(0) ||(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) )
		{
			if(isStart == false){
				isStart = true;
				initgem.transform.position = new Vector3(5f, 0.5f, 0f); 
				Instantiate (initgem);
				GameObject.Find ("flyingangel").GetComponent<Rigidbody2D> ().isKinematic = false;
				GameObject.Find ("ready").renderer.enabled = false;
			}
		}
		if (Input.GetKeyDown(KeyCode.Escape)) { 
			Application.Quit(); 
		}
		if (endGame == true) {
			showBestScore();
		}
	
	}
	void showBestScore(){
		int score = GameObject.Find ("Score").GetComponent<Score> ().score;
		int bestscore = GameObject.Find ("BestScore").GetComponent<BestScore> ().bestscore;
		if (score > bestscore) {
			GameObject.Find ("BestScore").GetComponent<BestScore> ().setHighScore (score);
			GameObject.Find ("BestScore").GetComponent<GUIText> ().text =  "Best Score: " + score;
		}
		else
			GameObject.Find ("BestScore").GetComponent<GUIText> ().text =  "Best Score: " +bestscore;
		GameObject.Find ("BestScore").GetComponent<GUIText> ().enabled = true;
		GameObject.Find ("BestScore-shadow").GetComponent<GUIText> ().enabled = true;

	
	}
	void OnGUI()
	{
		if (endGame) {
			const int buttonWidth = 260;
			const int buttonHeight = 200;
			// Set the skin to use
			GUI.skin = skin;
			// Draw a button to start the game
			if (
			GUI.Button (
			// Center in X, 2/3 of the height in Y
			new Rect (
			Screen.width / 2 - (buttonWidth / 2),
			(2 * Screen.height / 3 - 20) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
						),
			retry
						)
			) {
								// On Click, load the first level.
								// "Stage1" is the name of the first scene we created.
								Application.LoadLevel(Application.loadedLevel); 
						}
						if (
			GUI.Button (
			// Center in X, 2/3 of the height in Y
			new Rect (
			Screen.width / 2 - (buttonWidth / 4),
			(2 * Screen.height / 3 + buttonHeight / 2) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
						),
			rateus
						)
			) {
								// On Click, load the first level.
								// "Stage1" is the name of the first scene we created.
								string urlString = "market://details?id=" + "com.aura.aa";
								Application.OpenURL(urlString);
			
						}
				}
		}
}
