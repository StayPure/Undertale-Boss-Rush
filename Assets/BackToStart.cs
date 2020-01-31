using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToStart : MonoBehaviour
{   
    public Manager man;
    // Start is called before the first frame update
    void Start()
    {
        GameObject m = GameObject.FindGameObjectWithTag("manager");
        man = m.GetComponent<Manager>();
    }

    public void GoBackToStart()
    {
        man.reset();
        SceneManager.LoadScene("Start Screen");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
