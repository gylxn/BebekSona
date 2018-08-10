using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroOnBoss : MonoBehaviour {
	public int hp;
	public int maxhp = 5;
	public int attack = 1;
	public int storei;
	public int chance;
	public int morestore;
	public bool helpme = false;
	int cq = 0;
	int uq = 0;
	int sq = 0;
	public Boss target;
	public Text text;
	public GameManagerBoss game;
	public Animator anim;
	public AudioSource attackse;
	public float animspeed;
	public Text healthpointer;
	public Text skilldialogue;
	public GameObject skilldialoguebox;

	public void Awake()
	{
		anim = GetComponent<Animator>();
		game = FindObjectOfType<GameManagerBoss>();
		target = FindObjectOfType<Boss>();
	}

	private void Start() {
		hp = maxhp;
	}

	IEnumerator attackanim() {
		game.timeup = true;
		anim.SetBool("Attacking", true);
		yield return new WaitForSeconds (animspeed);
		Debug.Log ("Jalan");
		anim.SetBool("Attacking", false);
		game.timeup = false;
	}

	IEnumerator takedamageanim() {
		game.timeup = true;
		anim.SetBool("TakingDamage", true);
		yield return new WaitForSeconds (animspeed);
		Debug.Log ("Jalan");
		anim.SetBool("TakingDamage", false);
		game.timeup = false;
	}

	IEnumerator deadanim() {
		game.timeup = true;
		anim.SetBool("Dead", true);
		yield return new WaitForSeconds (3);
		Debug.Log ("Jalan");
		anim.SetBool("Dead", false);
		game.lose();
	}

	IEnumerator doubleattack() {
		Time.timeScale = 1f;
		game.timeup = true;
		anim.SetBool("DoubleAttack", true);
		yield return new WaitForSeconds (animspeed);
		anim.SetBool("DoubleAttack", false);
		game.timeup = false;
	}

	public void attacking(bool answer)
	{
		Time.timeScale = 1f;
		if(answer && target.skill2wrong == true) {
			target.skill2wrong = false;
			target.onskill = false;
			attackse.Play ();
			StartCoroutine (attackanim ());
			target.takedamage (attack);
		} else if (answer)
		{
			if (chance == 10) {
				int roll = Random.Range (0, 101);
				if (roll <= 10) {
					attackse.Play ();
					StartCoroutine (doubleattack ());
					target.takedamage (attack * 2);
				} else {
					attackse.Play ();
					StartCoroutine (attackanim ());
					target.takedamage (attack);
				}
			} else if (chance == 20) {
				int roll = Random.Range (0, 101);
				if (roll <= 20) {
					attackse.Play ();
					StartCoroutine (doubleattack ());
					target.takedamage (attack * 2);
				} else {
					attackse.Play ();
					StartCoroutine (attackanim ());
					target.takedamage (attack);
				}
			} else if (chance == 30) {
				int roll = Random.Range (0, 101);
				if (roll <= 30) {
					attackse.Play ();
					StartCoroutine (doubleattack ());
					target.takedamage (attack * 2);
				} else {
					attackse.Play ();
					StartCoroutine (attackanim ());
					target.takedamage (attack);
				}
			} else if (chance == 40) {
				int roll = Random.Range (0, 101);
				if (roll <= 40) {
					attackse.Play ();
					StartCoroutine (doubleattack ());
					target.takedamage (attack * 2);
				} else {
					attackse.Play ();
					StartCoroutine (attackanim ());
					target.takedamage (attack);
				}
			} else if (chance == 50) {
				int roll = Random.Range (0, 101);
				if (roll <= 50) {
					attackse.Play ();
					StartCoroutine (doubleattack ());
					target.takedamage (attack * 2);
				} else {
					attackse.Play ();
					StartCoroutine (attackanim ());
					target.takedamage (attack);
				}
			} else if (chance == 0) {
				attackse.Play ();
				StartCoroutine (attackanim ());
				target.takedamage (attack);
			}
		}
		else {
			if (target.skill2wrong == true) {
				target.skill2counter++;
				if (target.skill2counter == 3) {
					game.lose ();
				}
			}
			StartCoroutine (attackanim ());
			target.takedamage(0);
		}

		skilldialoguebox.SetActive (false);
	}

	public void takedamage(int damage) {
		StartCoroutine (takedamageanim ());
		hp -= damage;
		if (hp > 5 && hp < 11) {
			healthpointer.text = "2x";
		} else if (hp > 0 && hp < 6) {
			healthpointer.text = "1x";
		}
		//        updatehps();
		if (hp == 0)
		{
			StartCoroutine (deadanim ());
		}
		else
		{
			if (target.choicesq == true) {
				storei = game.i;
				game.i = 20 + cq;
				morestore = game.i;
				cq++;
				Debug.Log ("Stored");
				skilldialoguebox.SetActive (true);
				skilldialogue.text = "I think you'll be confused with this...";
			} else if (target.unlearnedq == true) {
				storei = game.i;
				game.i = 30 + uq;
				morestore = game.i;
				uq++;
				Debug.Log ("Stored");
				skilldialoguebox.SetActive (true);
				skilldialogue.text = "Good. But can you answer this?";
			} else if (target.simpleq == true) {
				storei = game.i;
				game.i = 25 + sq;
				morestore = game.i;
				sq++;
				Debug.Log ("Stored");
				skilldialoguebox.SetActive (true);
				skilldialogue.text = "Can you even answer this easy one?";
			}
			game.refilltime();
			game.changequestion();
			if (target.choicesq == true) {
				target.choicesq = false;
				target.onskill = false;
				helpme = true;
				game.i = storei;
				Debug.Log ("Loaded");
			} else if (target.unlearnedq == true) {
				target.unlearnedq = false;
				target.onskill = false;
				helpme = true;
				game.i = storei;
				Debug.Log ("Loaded");
			} else if (target.simpleq == true) {
				target.simpleq = false;
				target.onskill = false;
				helpme = true;
				game.i = storei;
				Debug.Log ("Loaded");
			}
		}
	}

	//    void updatehps() {
	//        game.updatehp("a");
	//    }

}
