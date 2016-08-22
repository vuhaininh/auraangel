using UnityEngine;
using System.Collections;

public class Feather : MonoBehaviour {
	public Transform target;
	public float speed;
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<SpriteRenderer> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("gameManager").GetComponent<GameManager> ().endGame == true) {

			gameObject.GetComponent<SpriteRenderer> ().enabled = true;
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, target.position, step);
		}
	}
}
