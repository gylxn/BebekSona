using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BreakRoom : MonoBehaviour {

	public GameManager gm;
	public Hero hero;
	public GameObject trans;
	public GameObject upgrades;
	public GameObject lvlselect;
	public GameObject nxtlvl;
	public GameObject replay;
	public Text quack;

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

	void Awake() {
		gm = FindObjectOfType<GameManager> ();
		hero = FindObjectOfType<Hero> ();
	}

	void Start() {
		StartCoroutine (freeze ());
	}

	public void tapfairy() {
		trans.SetActive(true);
	}

	public void tapfairyhead() {
		trans.SetActive (false);
		nxtlvl.SetActive (true);
	}

	public void upgrade() {
		trans.SetActive(false);
		upgrades.SetActive(true);
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

	public void SaveGame() {
		SaveManager.Instance.currency = gm.money;
		SaveManager.Instance.currentmaxhealth = hero.maxhp;
		SaveManager.Instance.currentattackchance = hero.chance;
		SaveManager.Instance.currentlevel = gm.level;
		SaveManager.Instance.Save ();
		quack.text = "Progress Saved!";
	}

	public void LevelSelection() {
		trans.SetActive(false);
		lvlselect.SetActive(true);
	}

	public void tutorial() {
		quack.text = "Terlalu gampang. Kau takut?";
	}

	public void levelone() {
		SceneManager.LoadScene ("Level1");
	}

	public void Love() {
		quack.text = "Cintailah produk-produk Indonesia";
	}

	public void GoBack() {
		upgrades.SetActive (false);
		lvlselect.SetActive (false);
		nxtlvl.SetActive (false);
		trans.SetActive (true);
	}

	public void ReplayComic() {
		nxtlvl.SetActive (false);
		replay.SetActive (true);
	}

	public void GoBack2() {
		replay.SetActive (false);
		nxtlvl.SetActive (true);
	}

}
