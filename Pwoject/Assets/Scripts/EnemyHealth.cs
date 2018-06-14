using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

	public Sprite[] Hearts;
	public Image HeartImage;
	public Enemy enemy;

	// Update is called once per frame
	void Update () {
		HeartImage.sprite = Hearts[enemy.hp];
	}
}
