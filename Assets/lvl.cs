using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class lvl : MonoBehaviour
{
	public Text text;
	public Manager manager;
	public GameObject man;

	// Start is called before the first frame update
	void Start()
	{
		man = GameObject.FindGameObjectWithTag("manager");
        manager = man.GetComponent<Manager>();
		text.text = "lv " + manager.Lvl.ToString();
	}

	// Update is called once per frame
	void Update()
	{
		text.text = "lv " + manager.Lvl.ToString();
	}
}
