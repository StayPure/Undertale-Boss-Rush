using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killingFlowey : MonoBehaviour
{
    public GameObject kF;

    void startHit()
    {
        GetComponent<Animator>().SetBool("hit", true);
        
    }

    void stopHit()
    {
        GetComponent<Animator>().SetBool("hit", false);
        kF.GetComponent<Animator>().SetInteger("numOfHits", kF.GetComponent<Animator>().GetInteger("numOfHits") + 1);

        if(kF.GetComponent<Animator>().GetInteger("numOfHits") == 8)
        {
            GetComponent<Animator>().SetBool("done", true);
        }
    }
}
