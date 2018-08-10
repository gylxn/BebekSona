using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour {

	private static SaveManager instance;
	public static SaveManager Instance{get{return instance; }}

	public int currency;
	public int currentlevel;
	public int currentmaxhealth;
	public int currentattackchance;
	public bool haveplayed;

	private void Start() {
		instance = this;
		DontDestroyOnLoad (gameObject);

		if (PlayerPrefs.HasKey ("CurrentLevel")) {
			//We had a previous session
			currency = PlayerPrefs.GetInt("Currency");
			currentlevel = PlayerPrefs.GetInt ("CurrentLevel");
			currentmaxhealth = PlayerPrefs.GetInt ("CurrentMaxHealth");
			currentattackchance = PlayerPrefs.GetInt ("CurrentAttackChance");
			haveplayed = true;
		} else {
			haveplayed = false;
		}
	}

	public void Save() {
		PlayerPrefs.GetInt ("Currency", currency);
		PlayerPrefs.GetInt ("CurrentLevel", currentlevel);
		PlayerPrefs.GetInt ("CurrentMaxHealth", currentmaxhealth);
		PlayerPrefs.GetInt ("CurrentAttaackChance", currentattackchance);
	}

}
