using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class WhereTo : MonoBehaviour
{
    public float holdingEnter = 0, holdingSpace = 0;
    public GameObject manager;

    private string last;
    void Start()
    {
        GameObject heart = GameObject.FindGameObjectWithTag("playerHeart");
        last = heart.GetComponent<BattleMovement>().lastScene;
        manager = GameObject.FindGameObjectWithTag("manager");
    }

    // Update is called once per frame
    void Update()
    {
        checkDetermination(KeyCode.Return);
        checkNewGame(KeyCode.Space);
    }

    private void checkDetermination(KeyCode k)
    {
        if (Input.GetKeyDown(k)) holdingEnter = Time.time;
        else if (Input.GetKey(k))
        {
            if (Time.time - holdingEnter > 3f)
            {
                manager.GetComponent<Manager>().HP = manager.GetComponent<Manager>().maxHP;
                Debug.Log(manager.GetComponent<Manager>().HP);
                //manager.GetComponent<Manager>().changeHealth(manager.GetComponent<Manager>().maxHP);
                holdingEnter = float.PositiveInfinity; SceneManager.LoadScene(last);
            }
        }
        else holdingEnter = float.PositiveInfinity;
    }


    private void checkNewGame(KeyCode k)
    {
        if (Input.GetKeyDown(k)) holdingSpace = Time.time;
        else if (Input.GetKey(k))
        {
            if (Time.time - holdingSpace > 3f)
            {
                holdingSpace = float.PositiveInfinity; 
                manager.GetComponent<Manager>().reset();
                SceneManager.LoadScene("Start Screen");
            }
        }
        else holdingSpace = float.PositiveInfinity;
    }

    
}
