using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public Image timer;
    public float waittime = 10.0f;
    public bool timeup = false;
    public Hero hero;
    public Enemy enemy;
    public Text herohp;
    public Text enemyhp;
	public Text moneytext;
    public GameObject[] question;
    public int i = 0;
    public GameObject Win;
    public GameObject loses;
	public GameObject ShopandStuff;
	public AudioSource[] effect;
	public int money;
	public int level;
	public Text healthpointer;

	void Awake () {
        hero = FindObjectOfType<Hero>();
        enemy = FindObjectOfType<Enemy>();
	}

	void Start() {
		moneytext.text = money.ToString();
		if (hero.hp > 5 && hero.hp < 11) {
			healthpointer.text = "2x";
		} else if (hero.hp > 10 && hero.hp < 16) {
			healthpointer.text = "3x";
		}
	}
	
	// Update is called once per frame
	void Update () {
        if (!timeup) {
            timer.fillAmount -= 1.0f / waittime * Time.deltaTime;
            if (timer.fillAmount == 0) {
                timeup = true;
                enemy.attacking();
                refilltime();
            }
        }

	}

    public void refilltime() {
        timer.fillAmount = 1.0f;
        timeup = false;
    }

//    public void updatehp(string declare) {
//        if (declare == "a")
//        {
//           herohp.text = hero.hp.ToString() + "x";
//        }
//        else {
//            enemyhp.text = enemy.hp.ToString() + "x";
//        }
//    }

    public void lose() {
		effect [2].Stop ();
        loses.SetActive(true);
		ShopandStuff.SetActive (false);
		effect [1].Play ();
        Time.timeScale = 0;
    }

    public void win() {
		effect [2].Stop ();
        Win.SetActive(true);
		ShopandStuff.SetActive (false);
		effect [0].Play ();
        Time.timeScale = 0;
    }

    public void changequestion() {
        question[i + 1].SetActive(true);
        question[i].SetActive(false);
        i++;
    }

	public void updatemoney() {
		moneytext.text = money.ToString ();
	}
}
