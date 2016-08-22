using UnityEngine;
using System.Collections;

public class BestScoreShadow : MonoBehaviour {

	public GameObject guiCopy;
	void Awake()
	{
		gameObject.GetComponent<GUIText> ().enabled = false;
		// Set the position to be slightly down and behind the other gui.
		Vector3 behindPos = transform.position;
		behindPos = new Vector3(guiCopy.transform.position.x, guiCopy.transform.position.y-0.005f, guiCopy.transform.position.z-1);
		transform.position = behindPos;
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = guiCopy.guiText.text;
	}
}
