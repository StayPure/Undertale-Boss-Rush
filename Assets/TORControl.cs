using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TORControl : MonoBehaviour
{

	public GameObject Toriel;

	public void TorielSpeak()
	{
		Toriel.GetComponent<Animator>().SetBool("speak", true);
	}

	public void TorielStopSpeak()
	{
		Toriel.GetComponent<Animator>().SetBool("speak", false);
	}

	public void TorielSad()
	{
		Toriel.GetComponent<Animator>().SetBool("sad", true);
	}

	public void TorielCentered()
	{
		Toriel.GetComponent<Animator>().SetBool("center", true);
	}

	public void TorielStopHitStun()
	{
		GetComponent<Animator>().SetBool("Hit", false);
	}

	public void TorielShock ()
	{
		Toriel.GetComponent<Animator>().SetBool("shocked", true);
	}

	public void TorielShocked (int x)
	{
		Toriel.GetComponent<Animator>().SetBool("shocked", x != 0);
	}
	
	public void nextFight()
	{
		SceneManager.LoadScene("Toriel Fight");
	}

	public void playSound() 
	{
		GetComponent<AudioSource>().Play();
	}
}
