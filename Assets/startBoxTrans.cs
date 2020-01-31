using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startBoxTrans : MonoBehaviour
{
    public GameObject mbMain;
    public GameObject heart;
    public void theBoxTransition()
    {
        heart.GetComponent<BattleMovement>().pickapattern();
        heart.GetComponent<BattleMovement>().resetFight();
    }
}
