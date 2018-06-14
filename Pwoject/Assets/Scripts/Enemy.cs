using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour{
    public int hp;
    public int attack = 1;
    public Hero target;
    public Text text;
    public GameManager game;
    public Animator anim;
	public AudioSource attackse;
	public float animspeed;

   public void Awake()
    {
        anim = GetComponent<Animator>();
        game = FindObjectOfType<GameManager>();
        target = FindObjectOfType<Hero>();
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

    public void takedamage(int damage)
    {
		if (damage != 0) {
			StartCoroutine(hurtanimu ());
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
			StartCoroutine(chottomatte ());
        }
    }
//    void updatehps()
//    {
//        game.updatehp("b");
//    }
}
