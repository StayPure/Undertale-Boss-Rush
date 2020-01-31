using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sp : MonoBehaviour
{
	public GameObject Flowey;

    // Start is called before the first frame update
    void Start()
    {
		Flowey.GetComponent<Flow>().idle();
    }

	public void idle()
	{
		Flowey.GetComponent<Flow>().idle();
	}

	public void notIdle()
	{
		Flowey.GetComponent<Flow>().notIdle();
	}

	public void spared()
	{
		Flowey.GetComponent<Flow>().spared();
	}

    public void killed()
    {
        Flowey.GetComponent<Flow>().killed();
    }

	public void talk()
	{
		Flowey.GetComponent<Flow>().talk();
	}

    public void notTalking()
    {
        Flowey.GetComponent<Flow>().notTalking();
    }

    public void getSpared()
    {
        SceneManager.LoadScene("GoodKid");
    }

    public void getKilled()
    {
        SceneManager.LoadScene("BadKid");
    }

	// Update is called once per frame
	void Update()
    {
        
    }
}
