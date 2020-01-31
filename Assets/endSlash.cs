using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class endSlash : MonoBehaviour
{
   public GameObject boss;
   public GameObject dmgNum;
   public GameObject healthBar;
   public GameObject manager;

   void AnimationEnd()
    {
        manager = GameObject.FindGameObjectWithTag("manager");
        int dmg = int.Parse(dmgNum.GetComponent<Text>().text), maxHP = boss.GetComponent<bossStats>().mHP;
        GetComponent<Animator>().SetBool("Attacking", false);
        boss.GetComponent<Animator>().SetBool("Hit", true);
        dmgNum.GetComponent<Animator>().SetBool("hit", true);
        healthBar.GetComponent<Animator>().SetBool("hit", true);
        boss.GetComponent<bossStats>().cHP -= dmg;
        float minusHealth = (float) dmg / (float) maxHP;
        healthBar.GetComponent<takeDamage>().takesDamage(minusHealth);
        if (boss.GetComponent<bossStats>().cHP <= 0 && manager.GetComponent<Manager>().Lvl == 3) SceneManager.LoadScene("badEnd");
        else if (boss.GetComponent<bossStats>().cHP <= 0) SceneManager.LoadScene("NeturalEnd");
    }

    void playSound()
    {
        GetComponent<AudioSource>().Play();
    }
}
