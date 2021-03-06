﻿using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {
	public Vector2 velocity = new Vector2(-3, 0);
	public float range = 4;
	public bool isScore = true;
	public AudioClip scoreSound;
	
	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = velocity;
		transform.position = new Vector3(transform.position.x, transform.position.y - range * Random.value, transform.position.z); 
	}
	
	// Update is called once per frame
	void Update () {

		Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
		Score ();
		if (screenPosition.x < 0)
		{
			DestroyObject(gameObject);
		}
		if (GameObject.Find ("gameManager").GetComponent<GameManager> ().endGame == true)
						Destroy (rigidbody);
	}
	void Score(){
		if (transform.position.x < GameObject.Find ("flyingangel").transform.position.x - 0.6 && isScore== true &&GameObject.Find ("gameManager").GetComponent<GameManager> ().endGame == false )
		{
			AudioSource.PlayClipAtPoint(scoreSound,transform.position);
			GameObject.Find ("Score").GetComponent<Score> ().score++;
			isScore = false;
		}

	}
}
