﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeHP : MonoBehaviour {

	public Hero hero;
	public GameManager gm;

	public void Awake() {
		hero = FindObjectOfType<Hero>();
		gm = FindObjectOfType<GameManager>();
	}

	private IEnumerator freeze()
	{
		Time.timeScale = 0.1f;
		float pauseEndTime = Time.realtimeSinceStartup + 3;
		while (Time.realtimeSinceStartup < pauseEndTime)
		{
			yield return 0;
		}
		Time.timeScale = 1;
	}

	public void Upgrade() {
		if (hero.maxhp == 5 && gm.money >= 10) {
			gm.money -= 10;
			hero.maxhp = 6;
		} else if (hero.maxhp == 6 && gm.money >= 20) {
			gm.money -= 20;
			hero.maxhp = 7;
		} else if (hero.maxhp == 7 && gm.money >= 30) {
			gm.money -= 30;
			hero.maxhp = 8;
		} else if (hero.maxhp == 8 && gm.money >= 40) {
			gm.money -= 40;
			hero.maxhp = 9;
		} else if (hero.maxhp == 9 && gm.money >= 50) {
			gm.money -= 50;
			hero.maxhp = 10;
		}
		gm.updatemoney ();
	}

	public void UpgradeChance() {
		if (hero.chance == 0 && gm.money >= 10) {
			gm.money -= 10;
			hero.chance += 10;
		} else if (hero.chance == 10 && gm.money >= 20) {
			gm.money -= 20;
			hero.chance += 10;
		} else if (hero.chance == 20 && gm.money >= 30) {
			gm.money -= 30;
			hero.chance += 10;
		} else if (hero.chance == 30 && gm.money >= 40) {
			gm.money -= 40;
			hero.chance += 10;
		} else if (hero.chance == 40 && gm.money >= 50) {
			gm.money -= 50;
			hero.chance += 10;
		}
		gm.updatemoney ();
	}

	public void BuyHP() {
		if (gm.money >= 30) {
			gm.money -= 30;
			hero.hp += 1;
		}
		gm.updatemoney ();
	}

	public void BuyTime() {
		if (gm.money >= 50) {
			gm.money -= 50;
			gm.updatemoney ();
			StartCoroutine (freeze ());
		}
	}
}
