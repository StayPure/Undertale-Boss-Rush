using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stopTalking : MonoBehaviour
{
    public GameObject battleHeart;
    public GameObject toriel;
    void endTalking()
    {
        GetComponent<Animator>().SetBool("talk", false);
        battleHeart.GetComponent<BattleMovement>().btBubble.GetComponent<Animator>().SetBool("talk", false);
        battleHeart.GetComponent<BattleMovement>().battlePatterns.GetComponent<Animator>().SetBool("spare", true);
        battleHeart.GetComponent<BattleMovement>().pickapattern();
    }

    void pickALine()
    {
        battleHeart.GetComponent<BattleMovement>().spare++;
        int s = battleHeart.GetComponent<BattleMovement>().spare;
        AutoText aT = GetComponent<AutoText>();

        if (s == 1) aT.UpdateText(".....");
        else if (s == 2) aT.UpdateText("..... .....");
        else if (s == 3) aT.UpdateText("..... ..... .....");
        else if (s == 4) aT.UpdateText("...?");
        else if (s == 5) aT.UpdateText("What are you doing?");
        else if (s == 6) aT.UpdateText("Attack or lets go! ");
        else if (s == 7) aT.UpdateText("What are you proving this way?");
        else if (s == 8) aT.UpdateText("Fight me or leave! ");
        else if (s == 9) aT.UpdateText("Stop it.");
        else if (s == 10)
        {
            aT.UpdateText("Stop looking at me that way. ");
            toriel.transform.GetChild(0).GetComponent<Animator>().SetInteger("state", 1);
        }
        else if (s == 11) aT.UpdateText("Go away!");
        else if (s == 12) aT.UpdateText("...");
        else if (s == 13)
        {
            toriel.transform.GetChild(0).GetComponent<Animator>().SetInteger("state", 2);
            aT.UpdateText("... ...");
            battleHeart.transform.GetChild(2).gameObject.SetActive(true);
            GetComponent<Animator>().SetBool("long", true);
            battleHeart.GetComponent<BattleMovement>().btBubble.GetComponent<Animator>().SetBool("long", true);
        }
        else if (s == 14)
        {
            aT.UpdateText("I know you want to fight for out home, but...");
            battleHeart.GetComponent<BattleMovement>().doneFighting = true;
            //setPosition();
        }
        else if (s == 15) aT.UpdateText("But please... Let's go now.");
        else if (s == 16)
        {
            toriel.transform.GetChild(0).GetComponent<Animator>().SetInteger("state", 3);
            aT.UpdateText("I promise I will take good care of you.");
        }
        else if (s == 17) aT.UpdateText("I know we do not have much, but...");
        else if (s == 18) aT.UpdateText("We can have a good life somewhere else.");
        else if (s == 19)
        {
            toriel.transform.GetChild(0).GetComponent<Animator>().SetInteger("state", 4);
            aT.UpdateText("Why are you making this so difficult?");
        }
        else if (s == 20) aT.UpdateText("Please, lets go.");
        else if (s == 21)
        {
            toriel.transform.GetChild(0).GetComponent<Animator>().SetInteger("state", 5);
            aT.UpdateText(".....");
        }
        else if (s == 22)
        {
            toriel.transform.GetChild(0).GetComponent<Animator>().SetInteger("state", 6);
            aT.UpdateText("Ha ha...");
        }
        else if (s == 23) aT.UpdateText("Pathetic, is it not? I cannot protect even a single child.");
        else if (s == 24)
        {
            aT.UpdateText("Fine, I'll believe in you... Fight for our home!");
        }
    }

    void setPosition()
    {
        Vector3 position = transform.GetChild(0).gameObject.transform.position;
        transform.position = new Vector3(258.2f, 141.6f, 0);
        transform.GetChild(0).gameObject.transform.position = position;
    }

    void LoadGoodScene()
    {
        if (battleHeart.GetComponent<BattleMovement>().spare == 24) SceneManager.LoadScene("GoodEnd");
    }
}
