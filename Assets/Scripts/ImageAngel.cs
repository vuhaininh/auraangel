using UnityEngine;
using System.Collections;

public class ImageAngel : MonoBehaviour {
	public GameObject angelCopy;
	public int imageNum;
	// Use this for initialization
	void Start () {
	
	}
	void Awake()
	{
		renderer.enabled = false;
		imagePos ();
	}
	// Update is called once per frame
	void Update () {
		imagePos ();	
	}
	void imagePos(){
		// Set the position to be slightly down and behind the other gui.
		Vector3 behindPos = transform.position;
		if(imageNum == 0)
			behindPos = new Vector3(angelCopy.transform.position.x, angelCopy.transform.position.y-1f, angelCopy.transform.position.z);
		else 
			behindPos = new Vector3(angelCopy.transform.position.x, angelCopy.transform.position.y+1f, angelCopy.transform.position.z);
		transform.position = behindPos;
		if (GameObject.Find ("flyingangel").GetComponent<Angel> ().status == 2)
						renderer.enabled = true;
				else
						renderer.enabled = false;
	}
}
