using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
	public string sceneName;


	public static Manager Instance { get; private set; }
	public static GameObject canvas;
	public GameObject Lv;
	public GameObject HPwords;
	public GameObject Health;
	public GameObject back;
	
	public GameObject HitPoints;
	public GameObject heart;
	
	

	public int maxHP = 20;
	public int HP = 20;
	public int atk = 10;
	public int def = 10;
	public int Lvl = 1;
	public float maxScale = 1f;

	public void reset()
	{
		maxHP = 20; HP = 20;
		atk = 10; def = 10; 
		Lvl = 1; maxScale = 1;
	}


	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public void changeHealth(int x)
	{
		Vector2 scale = Health.transform.localScale;

		if (HP + x >= maxHP)
		{
			HP = maxHP;
			scale.x = maxScale;
		}
		else if (HP + x <= 0)
		{
			HP = 0;
			scale.x = 0f;
			DontDestroyOnLoad(heart);
			heart.GetComponent<BattleMovement>().gameOver = true;
		}
		else
		{
			float change = scale.x * ((float)x / (float)HP);
			HP += x;
			scale.x += change;
			
		}

		Health.transform.localScale = scale;
		Debug.Log("CHANGE: " + ((float)x / (float)HP)); Debug.Log("SCALE: " + scale.x); Debug.Log("HP: " + HP); Debug.Log("X: " + x);
		

	}

	public void lvlUp()
	{
		maxHP += 4;
		Lvl++;
		atk += 2;

		if (Lvl == 5) def = 11;
		else if (Lvl == 9) def = 12;
		else if (Lvl == 13) def = 13;
		else if (Lvl == 17) def = 14;

		changeHealth(maxHP - HP);

		Vector2 scale = Health.transform.localScale;
		scale.x += .15f;
		maxScale += .15f;
		Health.transform.localScale = scale;

		
		Vector2 bScale = back.transform.localScale;
		bScale.x += 1.9379355f;
		back.transform.localScale = bScale;

		
		Vector2 position = Health.transform.position;
		position.x -= 0.011f;
		Health.transform.position = position;

		Vector2 bPosition = back.transform.position;
		bPosition.x -= 0.0012f;
		back.transform.position = bPosition;

		Vector2 hPosition = HitPoints.transform.position;
		hPosition.x += 0.011f;
		HitPoints.transform.position = hPosition;

		Vector2 iPosition = HPwords.transform.position;
		iPosition.x -= 0.011f;
		HPwords.transform.position = iPosition;

		Vector2 lPosition = Lv.transform.position;
		lPosition.x -= 0.011f;
		Lv.transform.position = lPosition;

		Debug.Log("LEVEL UP!");

	}


	void Update()
	{
		if (Input.GetKeyDown(KeyCode.L)) lvlUp();
		else if (Input.GetKeyDown(KeyCode.H)) changeHealth(-5);
		else if (Input.GetKeyDown(KeyCode.P)) changeHealth(5);
		if (sceneName != SceneManager.GetActiveScene().name)
		{
			sceneName = SceneManager.GetActiveScene().name;
			canvas = GameObject.FindGameObjectWithTag("canvas");
			Lv = canvas.transform.GetChild(6).GetChild(0).gameObject;
			HPwords = canvas.transform.GetChild(6).GetChild(1).gameObject;
			Health = canvas.transform.GetChild(6).GetChild(2).GetChild(0).gameObject;
			back = canvas.transform.GetChild(6).GetChild(2).GetChild(1).gameObject;
			HitPoints = canvas.transform.GetChild(6).GetChild(3).gameObject;
			heart = GameObject.FindGameObjectWithTag("playerHeart");
		}
	}
}
