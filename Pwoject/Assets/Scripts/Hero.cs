using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour {
	public int hp;
	public int maxhp;
    public int attack = 1;
	public int chance;
    public Enemy target;
    public Text text;
    public GameManager game;
    public Animator anim;
	public AudioSource attackse;
	public float animspeed;

    public void Awake()
    {
        anim = GetComponent<Animator>();
        game = FindObjectOfType<GameManager>();
        target = FindObjectOfType<Enemy>();
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
        if (answer)
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
        else{
			StartCoroutine (attackanim ());
			target.takedamage(0);
        }
    }

    public void takedamage(int damage) {
		StartCoroutine (takedamageanim ());
        hp -= damage;
//        updatehps();
        if (hp == 0)
        {
			StartCoroutine (deadanim ());
        }
        else
        {
            game.refilltime();
            game.changequestion();
        }
    }

//    void updatehps() {
//        game.updatehp("a");
//    }

}
