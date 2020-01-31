using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actHandler : MonoBehaviour
{
    public GameObject heart;
    public void notDone()
    {
        GetComponent<Animator>().SetBool("done", false);
    }

    public void startPattern()
    {
        heart.GetComponent<BattleMovement>().pickapattern();
        GetComponent<Animator>().SetBool("stats", false);

    }
}
