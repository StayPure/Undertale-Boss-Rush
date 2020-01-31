using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battlePatternsHandler : MonoBehaviour
{
   public GameObject box; 
   public GameObject heart;
    public void destoryAllClones()
    {
        var bullets = GameObject.FindGameObjectsWithTag ("bullet");
        foreach (var bullet in bullets) Destroy(bullet);
    }

    public void returnToMenu()
    {   BattleMovement bM = heart.GetComponent<BattleMovement>();
        box.GetComponent<Animator>().SetInteger("boxShape", 0);
        bM.getRandMainQuote();
        bM.defending = false; bM.inMen = false; bM.deepMen = false;
        Vector2 x = heart.transform.localPosition;
        x.y = -0.396f;
        if (bM.fight) x.x = 1.406f;
        else if (bM.act) x.x = 2.16f;
        else if (bM.item) x.x = 2.93f;
        else if (bM.mercy) x.x = 3.682f;
        heart.transform.localPosition = x;
        GetComponent<Animator>().SetBool("fighting", false);
    }
}
