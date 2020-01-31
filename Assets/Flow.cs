using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void idle()
	{
		GetComponent<Animator>().SetBool("isIdle", true);
	}

	public void notIdle()
	{
		GetComponent<Animator>().SetBool("isIdle", false);
	}

	public void spared()
	{
		GetComponent<Animator>().SetBool("isSpared", true);
	}

	public void talk()
	{
		GetComponent<Animator>().SetBool("talk", true);
	}

    public void notTalking()
    {
        GetComponent<Animator>().SetBool("talk", false);
    }

    public void killed()
    {
        GetComponent<Animator>().SetBool("killed", true);
    }
}
