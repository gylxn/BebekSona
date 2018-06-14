using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour{
	public int hp = 3;
	public int attack = 1;
	public int combocounter;
	public int wrongcounter;
	public int skill2counter;
	public int skillchoice;
	public bool choicesq;
	public bool doubleatt;
	public bool unlearnedq;
	public bool simpleq;
	public bool skill2wrong;
	public bool onskill;
	public HeroOnBoss target;
	public Text text;
	public GameManagerBoss game;
	public GameObject offer;
	public Animator anim;
	public AudioSource attackse;
	public float animspeed;

	public void Awake()
	{
		anim = GetComponent<Animator>();
		game = FindObjectOfType<GameManagerBoss>();
		target = FindObjectOfType<HeroOnBoss>();
	}

	//    private void Start()
	//    {
	//        updatehps();
	//   }

	IEnumerator attackanimu() {
		game.timeup = true;
		anim.SetBool ("Attacking", true);
		yield return new WaitForSeconds (animspeed);
		anim.SetBool ("Attacking", false);
		game.timeup = false;
	}

	IEnumerator hurtanimu() {
		game.timeup = true;
		anim.SetBool ("TakingDamage", true);
		yield return new WaitForSeconds (animspeed);
		anim.SetBool ("TakingDamage", false);
		game.timeup = false;
	}

	IEnumerator deadanimu() {
		game.timeup = true;
		anim.SetBool ("Dead", true);
		yield return new WaitForSeconds (2);
		game.win();
	}

	// Use this for initialization
	public void attacking() {
		attackse.Play ();
		StartCoroutine (attackanimu ());
		target.takedamage(attack);
	}

	IEnumerator chottomatte() {
		yield return new WaitForSeconds (1);
		attacking();
		Debug.Log ("Done");
	}

	IEnumerator doubleattack() {
		game.timeup = true;
		anim.SetBool ("DoubleAttack", true);
		yield return new WaitForSeconds (1);
		anim.SetBool ("DoubleAttack", false);
		game.timeup = false;
	}

	public void dogood() {
		skillchoice = Random.Range (1, 4);
		if (skillchoice == 1) {
			//go to 6-choices question list
			Debug.Log ("Skill 1");
			choicesq = true;
			onskill = true;
		} else if (skillchoice == 2) {
			Debug.Log ("Skill 2");
			doubleatt = true;
			attackse.Play ();
			StartCoroutine (doubleattack ());
			target.takedamage (attack * 2);
		} else if (skillchoice == 3) {
			//go to unlearned question list
			Debug.Log ("Skill 3");
			unlearnedq = true;
			onskill = true;
		} else {
			Debug.Log ("Nani kore");
		}
	}

	public void dobad() {
		skillchoice = Random.Range (1, 4);
		if (skillchoice == 1) {
			//go to elementary question list
			Debug.Log("Skill 1");
			simpleq = true;
			onskill = true;
		} else if (skillchoice == 2) {
			Debug.Log("Skill 2");
			skill2counter = 0;
			skill2wrong = true;
			onskill = true;
		} else if (skillchoice == 3) {
			Debug.Log("Skill 3");
			offer.SetActive (true);
		} else {
			Debug.Log ("Nani kore");
		}
	}

	public void takedamage(int damage)
	{
		if (damage != 0) {
			wrongcounter = 0;
			combocounter++;
			StartCoroutine (hurtanimu ());
			if (combocounter == 5 || combocounter == 10 || combocounter == 15 || combocounter == 20 || combocounter == 25 && onskill == false) {
				//doing good
				dogood();
			}
		} else if (damage == 0) {
			combocounter = 0;
			wrongcounter++;
			if (wrongcounter == 3 || wrongcounter == 6 || wrongcounter == 9 || wrongcounter == 12 || wrongcounter == 15 || wrongcounter == 18 || wrongcounter == 21 || wrongcounter == 24 || wrongcounter == 27 && onskill == false) {
				//doing bad
				dobad();
			}
			if (skill2wrong == true && skill2counter == 3) {
				game.lose();
			}
		}
		if (hp == 1 && damage > 1) {
			hp = 0;
		} else {
			hp -= damage;
		}
		//		updatehps();
		if (hp == 0)
		{
			StartCoroutine (deadanimu ());
		}
		else
		{
			if (doubleatt == true) {
				doubleatt = false;
			} else if (skill2wrong == true) {
				game.changequestion();
			} else {
				StartCoroutine (chottomatte ());
			}
		}
	}

	//    void updatehps()
	//    {
	//        game.updatehp("b");
	//    }
}
