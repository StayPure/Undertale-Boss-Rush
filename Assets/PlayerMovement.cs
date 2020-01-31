using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour {
	public string nextScene;
	public string SameScene;

	// Use this for initialization
	void Start () {
		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		//if collide with finish change scenes
		if (collision.gameObject.tag == "Finish")
		{
			//change scene to next scene
			SceneManager.LoadScene(nextScene);
		}

		if (collision.gameObject.tag == "Respawn")
		{
			//change scene to next scene
			SceneManager.LoadScene(SameScene);
		}


		Debug.Log("IT HIT!");
	}

	// Update is called once per frame
	void Update () {
		//Check for D press, if so move right
		if (Input.GetKey(KeyCode.D))
		{
			Vector2 position = transform.position;
			position.x += 0.1f;
			transform.position = position;
		}

		if (Input.GetKey(KeyCode.A))
		{
			Vector2 position = transform.position;
			position.x -= 0.1f;
			transform.position = position;
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			//if space is pressed jump up (add a force up)
			gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 250f));
		}

	}

	
}
