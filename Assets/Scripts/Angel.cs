using UnityEngine;
using System.Collections;

public class Angel : MonoBehaviour {
	public Vector2 jumpForce = new Vector2(0,360);
	public Vector2 downForce = new Vector2(0,-260);
	public AudioClip flySound;
	public AudioClip punchSound;
	public int status = 0;
	public Sprite feather = new Sprite();
	bool normove = true;

	private Animator anim;	
	// Use this for initialization
	void Start () {
		Vector3 angelPos = new Vector3 (Screen.width / 5, Screen.height / 2, 0);
		Vector3 angelPos2 = GameObject.Find ("Main Camera").camera.ScreenToWorldPoint(angelPos);
		angelPos2.z = transform.position.z;
		transform.position = angelPos2 ;
		angelPos2.y = -5;
		angelPos2.x = transform.position.x;
		GameObject.Find ("dropfeather").transform.position = angelPos2;
		GameObject.Find ("ground").transform.position = angelPos2;
		angelPos2.y = transform.position.y +6 ;

		GameObject.Find ("ceiling").transform.position = angelPos2;
	}

	// Update is called once per frame
	void Update () {
		if (status == 0) { 
			normove = true;
			gameObject.GetComponent<Rigidbody2D>().gravityScale = 2.5f;
		}
		if (status == 1) {
			normove = false;
			gameObject.GetComponent<Rigidbody2D>().gravityScale = -1.0f;
		}
		// Jump
		if (Input.GetKeyUp("space") || Input.GetMouseButtonDown(0) ||(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) )
		{

			AudioSource.PlayClipAtPoint(flySound,transform.position,volume:1f);
			rigidbody2D.velocity = Vector2.zero;
			if(normove)
				rigidbody2D.AddForce(jumpForce);
			else
				rigidbody2D.AddForce(downForce);
		}	

	}
	// Die by collision
	void OnCollisionEnter2D(Collision2D other)
	{
		AudioSource.PlayClipAtPoint(punchSound,transform.position,volume:1f);
		Die();
	}
	
	void Die()
	{
		GetComponent<Angel>().enabled = false;
		GetComponent<SpriteRenderer> ().enabled = false;
		GetComponent<Animator> ().enabled = false;
		GetComponent<BoxCollider2D> ().enabled = false;
		GameObject.Find ("feather").transform.position = gameObject.transform.position;
		GameObject.Find ("gameManager").GetComponent<GameManager> ().endGame = true;
	}

}
