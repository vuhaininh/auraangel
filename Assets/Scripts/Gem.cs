﻿using UnityEngine;
using System.Collections;

public class Gem : MonoBehaviour {
	public Vector2 velocity = new Vector2(-4, 0);
	public float range = 1.1f;
	public int gemType = 0;
	bool isActive = true;
	public AudioClip gemPick;
	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = velocity;
		transform.position = new Vector3(transform.position.x, transform.position.y - range * Random.value, transform.position.z); 
	}
	
	// Update is called once per frame
	void Update () {
		GetGem ();
		Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
		if (screenPosition.x < 0)
		{
			DestroyObject(gameObject);
		}
	}
	void GetGem(){
		float x = transform.position.x;
		float angelx = GameObject.Find ("flyingangel").transform.position.x ;
		float y = transform.position.y;
		float angely = GameObject.Find ("flyingangel").transform.position.y ;
		if ((angelx > x - 0.5&& angelx < x + 0.5&& angely > y - 0.5&& angely < y + 0.5) && isActive== true )
		{
			GameObject.Find ("flyingangel").GetComponent<Angel> ().status = gemType;
			AudioSource.PlayClipAtPoint(gemPick,transform.position);
			isActive = false;
			DestroyObject(gameObject);
		}
		
	}
}
