using UnityEngine;
using System.Collections;

public class BestScore : MonoBehaviour {
	public int bestscore = 0;
	// Use this for initialization
	void Start () {
	
	}
	void Awake(){
		bestscore = getHighScore ();
		gameObject.GetComponent<GUIText> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

	}
	public int getHighScore(){
		int hs = 0;
		if (PlayerPrefs.HasKey ("highscore"))
			hs = PlayerPrefs.GetInt("highscore");
		else
			PlayerPrefs.SetInt("highscore",hs);
		return hs;
	}
	public void setHighScore(int highscore){
		PlayerPrefs.SetInt("highscore",highscore);
	}
}
