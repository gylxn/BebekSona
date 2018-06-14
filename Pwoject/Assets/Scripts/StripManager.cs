using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StripManager : MonoBehaviour {

	public Sprite[] images;
	public Image strip;
	public string scenename;
	int scene = 1;

	void Awake() {
		scenename = SceneManager.GetActiveScene().name;
	}

	public void ShowComic () 
	{
		strip.sprite = images [scene];
	}

	public void NextScene() {
		//Debug.Log scene+1;
		if (scenename == "Cutscene") {
			if (scene < 7) {
				scene = scene + 1;
				ShowComic ();
			} else {
				SceneManager.LoadScene ("Cutscene 1");
			}
		} else if (scenename == "Comic1") {
			if (scene < 6) {
				scene = scene + 1;
				ShowComic ();
			} else {
				SceneManager.LoadScene ("Level1");
			}
		}

	}

}
