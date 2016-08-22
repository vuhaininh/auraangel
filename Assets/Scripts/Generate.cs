using UnityEngine;
using System.Collections;

public class Generate : MonoBehaviour {
	public GameObject rocks;
	public GameObject norgem;
	public GameObject upgem;
	public GameObject imagegem;
	int type;
	// Use this for initialization
	void Start () {
			InvokeRepeating("CreateObstacle", 1f, 1.1f);
			InvokeRepeating("CreateGem", 2f, 3.3f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void CreateObstacle()
	{
		if(GameObject.Find ("gameManager").GetComponent<GameManager> ().isStart == true)
			Instantiate(rocks);
	}

	void CreateGem()
	{
		if (GameObject.Find ("gameManager").GetComponent<GameManager> ().isStart == true) {
			type = Random.Range (0, 1000) % 3;
			if (type == 0)
				Instantiate (norgem);
			else if (type == 1)
				Instantiate (upgem);
			else
				Instantiate (imagegem);
		}
	}
}
