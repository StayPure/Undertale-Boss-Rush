using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingFrisk : MonoBehaviour {
	public string nextScene;
	public string SameScene;
	public bool moveUp = false;
	public bool moveLeft = false;
	public bool moveRight = false;
	public bool moveDown = false;
	public bool changeScene = false;

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
			GetComponent<Animator>().SetBool("upPress", true);
		}

		Debug.Log("IT HIT!");
	}

	// Update is called once per frame
	void Update () {
		if (moveRight)
		{
			Vector2 position = transform.position;
			position.x += 0.01f;
			transform.position = position;
			changeDirection('r');
		}
		else if (moveLeft)
		{
			Vector2 position = transform.position;
			position.x -= 0.01f;
			transform.position = position;
			changeDirection('l');
		}
		else if (moveUp)
		{
			Vector2 position = transform.position;
			position.y += 0.01f;
			transform.position = position;
			changeDirection('u');
		}
		else if (moveDown)
		{
			Vector2 position = transform.position;
			position.y -= 0.01f;
			transform.position = position;
			changeDirection('d');
		}
		else
		{
			if (GetComponent<Animator>().GetBool("downPress"))
			{
				GetComponent<Animator>().Play("Frisk move down", 0, 0);
			}
			else if (GetComponent<Animator>().GetBool("rightPress"))
			{
				GetComponent<Animator>().Play("Frisk move right", 0, 0);
			}
			else if (GetComponent<Animator>().GetBool("leftPress"))
			{
				GetComponent<Animator>().Play("Frisk move left", 0, 0);
			}
			else if (GetComponent<Animator>().GetBool("upPress"))
			{
				GetComponent<Animator>().Play("Frisk move up", 0, 0);
			}

			GetComponent<Animator>().speed = 0f;
		}

		if (changeScene)
		{
			SceneManager.LoadScene("First Boss");
		}
	}

	void changeDirection(char d)
	{
		if (d == 'd')
		{
			GetComponent<Animator>().SetBool("downPress", true);
			GetComponent<Animator>().SetBool("rightPress", false);
			GetComponent<Animator>().SetBool("leftPress", false);
			GetComponent<Animator>().SetBool("upPress", false);
			GetComponent<Animator>().speed = .5f;
		}
		else if (d == 'u')
		{
			GetComponent<Animator>().SetBool("upPress", true);
			GetComponent<Animator>().SetBool("downPress", false);
			GetComponent<Animator>().SetBool("rightPress", false);
			GetComponent<Animator>().SetBool("leftPress", false);
			GetComponent<Animator>().speed = .5f;
		}
		else if (d == 'l')
		{
			GetComponent<Animator>().SetBool("leftPress", true);
			GetComponent<Animator>().SetBool("upPress", false);
			GetComponent<Animator>().SetBool("downPress", false);
			GetComponent<Animator>().SetBool("rightPress", false);
			GetComponent<Animator>().speed = .5f;
		}
		else if (d == 'r')
		{
			GetComponent<Animator>().SetBool("rightPress", true);
			GetComponent<Animator>().SetBool("leftPress", false);
			GetComponent<Animator>().SetBool("upPress", false);
			GetComponent<Animator>().SetBool("downPress", false);
			GetComponent<Animator>().speed = .5f;
		}
	}

}


