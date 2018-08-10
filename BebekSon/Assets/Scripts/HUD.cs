using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

	public Sprite[] Hearts;
	public Image HeartImage;
	public Hero hero;

	// Update is called once per frame
	void Update () {
		HeartImage.sprite = Hearts[hero.hp];
	}
}
