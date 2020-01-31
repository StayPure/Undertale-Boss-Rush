using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using System.Timers;
using UnityEngine.SceneManagement;
using System;

public class BattleMovement : MonoBehaviour
{
    public String bossName;
    public GameObject boss;
    public GameObject man;
    public GameObject FIT, ACT, ITM, MER;
    public GameObject mbFight, mbAct, mbItem, mbMercy, mbMain;
    public GameObject floweyControl, bossText, btBubble;
    public GameObject Theme;
    public GameObject playerSlash, dmgNums, missed, bossHealth, battlePatterns;
    public Manager manager;
    public bossStats bS;
    public int spare = 0, playeratk, playerDef, bossAtk, bossDef,
    bossShape = 0, main = 0, HPMod = 0, dead = 0, talked = 0;
    System.Random rand = new System.Random();
    public string lastScene;

    Vector2 position;

    public bool locked, fight, act, item, mercy,
    inMen, deepMen, fighting, check, talk, defending, gameOver, immune,
    doneFighting;

    // Start is called before the first frame update
    void Start()
    {
        changeOpt('f');
        man = GameObject.FindGameObjectWithTag("manager");
        manager = man.GetComponent<Manager>();
        bS = boss.GetComponent<bossStats>();
        playeratk = manager.atk; playerDef = manager.def;
        bossAtk = bS.atk; bossDef = bS.def;

        HPMod = findHPMod();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            if (dead == 0)
            {
                dead++;
                lastScene = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene("GameOver");
            }

            if (Input.GetKeyDown(KeyCode.Return)) SceneManager.LoadScene(lastScene);
            GetComponent<Animator>().SetBool("alive", false);
            return;
        }

        if (defending)
        {
            position = transform.position;
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                position.y += 0.01f;
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                position.y -= 0.01f;
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                position.x -= 0.01f;
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                position.x += 0.01f;
            }
            transform.position = position;
            return;
        }

        if ((check || talk) && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)))
        {
            if (check)
            {
                mbAct.transform.GetChild(3).gameObject.SetActive(false);
                mbAct.transform.GetChild(3).gameObject.GetComponent<Animator>().SetBool("stats", false);
                pickapattern();
                check = false;
            }
            else
            {
                mbAct.transform.GetChild(4).gameObject.SetActive(false);
                mbAct.transform.GetChild(4).gameObject.GetComponent<Animator>().SetBool("talk", false);
                pickapattern();
                talk = false;
            }
            GetComponent<SpriteRenderer>().sortingOrder = 1;
            return;
        }

        if (fighting)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            {
                mbFight.transform.GetChild(1).GetChild(0).GetComponent<Animator>().SetBool("Hit", true);
                endFighting();
                fighting = false;
                inMen = false;
                return;
            }
            else if (mbFight.transform.GetChild(1).GetChild(0).transform.localPosition.x >= 2.72f)
            {
                missedFighting();

                mbFight.SetActive(false);
                inMen = false;

                fighting = false;
                locked = false;
                return;
            }
            else
            {
                Vector2 cursorPosition = mbFight.transform.GetChild(1).GetChild(0).transform.position;
                cursorPosition.x += .03f;
                mbFight.transform.GetChild(1).GetChild(0).transform.position = cursorPosition;
            }
        }

        //To Talk
        if (((Input.GetKeyDown(KeyCode.D) && transform.position.x == 1.478f) || (Input.GetKeyDown(KeyCode.A) && transform.position.x == 1.478f)) && !locked && deepMen && act)
        {
            position = transform.position;
            position.x = 2.715f;
            transform.position = position;
            GetComponent<AudioSource>().Play();
        }
        //To Check
        else if (((Input.GetKeyDown(KeyCode.D) && transform.position.x == 2.715f) || (Input.GetKeyDown(KeyCode.A) && transform.position.x == 2.715f)) && !locked && deepMen && act)
        {
            position = transform.position;
            position.x = 1.478f;
            transform.position = position;
            GetComponent<AudioSource>().Play();
        }
        //To Spare
        else if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S)) && transform.position.y == 0.263f && !locked && mercy)
        {
            position = transform.position;
            position.y = 0.425f;
            transform.position = position;
            GetComponent<AudioSource>().Play();
        }
        //To Flee
        else if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S)) && transform.position.y == 0.425f && !locked && mercy)
        {
            position = transform.position;
            position.y = 0.263f;
            transform.position = position;
            GetComponent<AudioSource>().Play();
        }
        //To Act, From Item and Fight
        else if (((Input.GetKeyDown(KeyCode.D) && transform.position.x == 1.406f) || (Input.GetKeyDown(KeyCode.A) && transform.position.x == 2.93f)) && !locked)
        {
            position = transform.position;
            position.x = 2.16f;
            transform.position = position;
            changeOpt('a');
            GetComponent<AudioSource>().Play();
        }
        //To Mercy, From Item and Fight
        else if ((Input.GetKeyDown(KeyCode.D) && transform.position.x == 2.93f || (Input.GetKeyDown(KeyCode.A) && transform.position.x == 1.406f)) && !locked)
        {
            position = transform.position;
            position.x = 3.682f;
            transform.position = position;
            changeOpt('m');
            GetComponent<AudioSource>().Play();
        }
        //To Item, from Act and Mercy
        else if (((Input.GetKeyDown(KeyCode.D) && transform.position.x == 2.16f) || (Input.GetKeyDown(KeyCode.A) && transform.position.x == 3.682f)) && !locked)
        {
            position = transform.position;
            position.x = 2.93f;
            transform.position = position;
            changeOpt('i');
            GetComponent<AudioSource>().Play();
        }
        //To Fight, from Act and Mercy
        else if (((Input.GetKeyDown(KeyCode.A) && transform.position.x == 2.16f) || (Input.GetKeyDown(KeyCode.D) && transform.position.x == 3.682f)) && !locked)
        {
            position = transform.position;
            position.x = 1.406f;
            transform.position = position;
            changeOpt('f');
            GetComponent<AudioSource>().Play();
        }

        if ((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.X)) && !fighting && !locked)
        {
            if (fight)
            {
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
                {
                    if (!inMen)
                    {
                        mbFight.SetActive(true);
                        mbFight.transform.GetChild(0).gameObject.SetActive(true);
                        mbMain.GetComponent<Animator>().SetBool("Blank", true);
                        position = transform.position;
                        position.x = 1.478f; position.y = 0.425f;
                        transform.position = position;
                        inMen = true;
                    }
                    else
                    {
                        mbFight.transform.GetChild(0).gameObject.SetActive(false);
                        mbFight.GetComponent<Animator>().SetBool("fighting", true);
                        centerHeart();
                        fighting = true;
                    }
                }
                else if (Input.GetKeyDown(KeyCode.X) && inMen)
                {
                    position = transform.position;
                    position.y = -0.396f; position.x = 1.406f;
                    transform.position = position;
                    mbFight.SetActive(false);
                    mbMain.GetComponent<Animator>().SetBool("Blank", false);
                    inMen = false;
                }
            }
            else if (act)
            {
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
                {
                    if (!inMen)
                    {
                        mbAct.SetActive(true);
                        mbAct.transform.GetChild(0).gameObject.SetActive(true);
                        mbMain.GetComponent<Animator>().SetBool("Blank", true);
                        position = transform.position;
                        position.x = 1.478f; position.y = 0.425f;
                        transform.position = position;
                        inMen = true;
                    }
                    else if (deepMen)
                    {
                        if (transform.position.x == 1.478f)
                        {
                            mbAct.transform.GetChild(1).gameObject.SetActive(false);
                            mbAct.transform.GetChild(2).gameObject.SetActive(false);
                            mbAct.transform.GetChild(3).gameObject.SetActive(true);
                            mbAct.transform.GetChild(3).gameObject.GetComponent<Animator>().SetBool("stats", true);
                            position = transform.position;
                            position.x = 2.715f; position.y = 0.241f;
                            transform.position = position;
                            GetComponent<SpriteRenderer>().sortingOrder = -10;
                            check = true;
                        }
                        else if (transform.position.x == 2.715f)
                        {
                            mbAct.transform.GetChild(1).gameObject.SetActive(false);
                            mbAct.transform.GetChild(2).gameObject.SetActive(false);
                            mbAct.transform.GetChild(4).gameObject.SetActive(true);
                            mbAct.transform.GetChild(4).gameObject.GetComponent<Animator>().SetBool("talk", true);
                            position = transform.position;
                            position.x = 2.715f; position.y = 0.241f;
                            transform.position = position;
                            GetComponent<SpriteRenderer>().sortingOrder = -10;
                            talk = true;
                        }
                    }
                    else
                    {
                        mbAct.transform.GetChild(0).gameObject.SetActive(false);
                        mbAct.transform.GetChild(1).gameObject.SetActive(true);
                        mbAct.transform.GetChild(2).gameObject.SetActive(true);
                        deepMen = true;
                    }
                }
                else if (Input.GetKeyDown(KeyCode.X) && inMen)
                {
                    if (deepMen)
                    {
                        mbAct.transform.GetChild(0).gameObject.SetActive(true);
                        mbAct.transform.GetChild(1).gameObject.SetActive(false);
                        mbAct.transform.GetChild(2).gameObject.SetActive(false);
                        position = transform.position;
                        position.x = 1.478f; position.y = 0.425f;
                        transform.position = position;
                        deepMen = false;
                    }
                    else
                    {
                        position = transform.position;
                        position.y = -0.396f; position.x = 2.16f;
                        transform.position = position;
                        mbAct.SetActive(false);
                        mbMain.GetComponent<Animator>().SetBool("Blank", false);
                        inMen = false;
                    }
                }

            }
            else if (item)
            {
                //mbItem.SetActive(true);
                //inMen = true;
            }
            else if (mercy)
            {
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
                {
                    if (!inMen)
                    {
                        mbMercy.SetActive(true);
                        mbMercy.transform.GetChild(0).gameObject.SetActive(true);
                        mbMercy.transform.GetChild(1).gameObject.SetActive(true);
                        mbMain.GetComponent<Animator>().SetBool("Blank", true);
                        position = transform.position;
                        position.x = 1.478f; position.y = 0.425f;
                        transform.position = position;
                        inMen = true;
                    }
                    else
                    {
                        Spared();
                        locked = true;
                    }
                }
                else if (Input.GetKeyDown(KeyCode.X) && inMen)
                {
                    position = transform.position;
                    position.y = -0.396f; position.x = 3.682f;
                    transform.position = position;
                    mbMercy.SetActive(false);
                    mbMain.GetComponent<Animator>().SetBool("Blank", false);
                    inMen = false;
                }
            }
        }
    }

    void changeOpt(char o)
    {
        FIT.GetComponent<Animator>().SetBool("fitHovered", false);
        fight = false;
        ACT.GetComponent<Animator>().SetBool("actHovered", false);
        act = false;
        ITM.GetComponent<Animator>().SetBool("itmHovered", false);
        item = false;
        MER.GetComponent<Animator>().SetBool("merHovered", false);
        mercy = false;

        if (o == 'f')
        {
            FIT.GetComponent<Animator>().SetBool("fitHovered", true);
            fight = true;
        }
        else if (o == 'a')
        {
            ACT.GetComponent<Animator>().SetBool("actHovered", true);
            act = true;
        }
        else if (o == 'i')
        {
            ITM.GetComponent<Animator>().SetBool("itmHovered", true);
            item = true;
        }
        else if (o == 'm')
        {
            MER.GetComponent<Animator>().SetBool("merHovered", true);
            mercy = true;
        }
    }

    public void endFighting()
    {
        if (bossName == "Flowey")
        {
            floweyControl.GetComponent<Animator>().SetBool("Killed", true);
            Theme.GetComponent<Animator>().SetBool("kill", true);
            manager.lvlUp();
            manager.lvlUp();
            locked = true;
        }
        else if (bossName == "Toriel")
        {
            doDamage(findDamage());
            mbFight.GetComponent<Animator>().SetBool("fighting", false);
        }
    }

    public int findDamage()
    {
        double c = mbFight.transform.GetChild(1).GetChild(0).transform.localPosition.x;
        if (c < 0) c = c * -1;
        if (c <= .2) return (int)Math.Round((playeratk + 3 - bossDef + rand.Next(2)) * 2.2);
        else return (int)Math.Round((playeratk + 3 - bossDef + rand.Next(2)) * (1 - (c / 2.5)) * 2);
    }

    public void doDamage(int dmg)
    {
        dmgNums.GetComponent<Text>().text = dmg.ToString();
        playerSlash.GetComponent<Animator>().SetBool("Attacking", true);
    }

    public void missedFighting()
    {
        if (bossName == "Flowey")
        {
            floweyControl.GetComponent<Animator>().SetBool("Missed", true);
            bossText.GetComponent<Animator>().SetBool("Missed", true);
        }
        else if (bossName == "Toriel")
        {
            missed.GetComponent<Animator>().SetBool("hit", true);
            mbFight.GetComponent<Animator>().SetBool("fighting", false);
            main = rand.Next(4); mbMain.GetComponent<Animator>().SetInteger("mainState", main);
            resetFight();
            pickapattern();
        }
    }

    public void Spared()
    {
        if (bossName.Equals("Flowey"))
        {
            floweyControl.GetComponent<Animator>().SetBool("Spared", true);
            bossText.GetComponent<Animator>().SetBool("Spared", true);
        }
        else if (bossName.Equals("Toriel"))
        {
            mbMercy.transform.GetChild(0).gameObject.SetActive(false);
            mbMercy.transform.GetChild(1).gameObject.SetActive(false);
            centerHeart();
            setBox(0);
            bossText.GetComponent<Animator>().SetBool("talk", true);
            btBubble.GetComponent<Animator>().SetBool("talk", true);
        }
    }

    public void centerHeart()
    {
        position = transform.position;
        position.x = 2.715f; position.y = 0.241f;
        transform.position = position;
    }
    public void lockMove(bool x)
    {
        locked = x;
    }

    public void pickapattern()
    {
        defending = true;
        if (doneFighting)
        {
            battlePatterns.GetComponent<Animator>().SetInteger("pat", -1);
            battlePatterns.GetComponent<Animator>().SetBool("fighting", true);
            return;
        }
        else
        {
            int r = rand.Next(2);
            battlePatterns.GetComponent<Animator>().SetInteger("pat", r);
            battlePatterns.GetComponent<Animator>().SetBool("fighting", true);
            if (r == 3) setBox(0);
            else setBox(r);
        }
    }

    public void resetFight()
    {
        Vector2 cursorPosition = mbFight.transform.GetChild(1).GetChild(0).transform.localPosition;
        cursorPosition.x = -2.72f;
        mbFight.transform.GetChild(1).GetChild(0).transform.localPosition = cursorPosition;

        mbFight.transform.GetChild(0).gameObject.SetActive(false);
        mbFight.transform.GetChild(1).gameObject.SetActive(false);

    }

    public void getRandMainQuote()
    {
        if (doneFighting)
        {
            mbMain.GetComponent<Animator>().SetInteger("mainState", -1);
            mbMain.GetComponent<Animator>().SetBool("Blank", false);
        }
        else
        {
            int r = rand.Next(4);
            mbMain.GetComponent<Animator>().SetInteger("mainState", r);
            mbMain.GetComponent<Animator>().SetBool("Blank", false);
        }
        manager.GetComponent<Manager>().changeHealth(3);
    }

    public void setBox(int shape)
    {
        if (shape == 0) mbMain.GetComponent<Animator>().SetInteger("boxShape", 1);
        else if (shape == 1) mbMain.GetComponent<Animator>().SetInteger("boxShape", 2);
    }

    public void playHB()
    {
        transform.GetChild(0).GetComponent<AudioSource>().Play();
    }

    public void playDeath()
    {
        transform.GetChild(1).GetComponent<AudioSource>().Play();
    }

    public void destroy()
    {
        Destroy(gameObject);
    }

    public void immunity()
    {
        immune = true;
        GetComponent<Animator>().SetBool("immune", true);
    }
    public void noimmunity()
    {
        immune = false;
        GetComponent<Animator>().SetBool("immune", false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "bullet")
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), other.gameObject.GetComponent<Collider2D>());
            if (!immune) manager.changeHealth(-((int)Math.Round((bossAtk + (double)HPMod - (double)(playerDef / 5)))));
            immunity();
        }
        
    }

    public int findHPMod()
    {
        if (manager.maxHP <= 20) return 0;
        else if (manager.maxHP > 20 && manager.maxHP < 30) return 1;
        else if (manager.maxHP >= 30 && manager.maxHP < 40) return 2;
        else if (manager.maxHP >= 40 && manager.maxHP < 50) return 3;
        else if (manager.maxHP >= 50 && manager.maxHP < 60) return 4;
        else if (manager.maxHP >= 60 && manager.maxHP < 70) return 5;
        else if (manager.maxHP >= 70 && manager.maxHP < 80) return 6;
        else if (manager.maxHP >= 80 && manager.maxHP < 90) return 7;
        else return 8;
    }
}