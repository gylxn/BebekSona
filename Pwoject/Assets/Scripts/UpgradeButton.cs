using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour {

	public GameObject butt1;
	public GameObject butt2;
	private bool nyot;

	void Start() {
		nyot = false;
	}

	public void ClickityClick() {
		if (nyot == false) {
			butt1.SetActive (true);
			butt2.SetActive (true);
			nyot = true;
		} else if (nyot == true) {
			butt1.SetActive (false);
			butt2.SetActive (false);
			nyot = false;
		}
	}



}
