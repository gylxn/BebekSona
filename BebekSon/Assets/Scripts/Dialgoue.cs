using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialgoue : MonoBehaviour {

	public Text TextDisplay;
	public Text NameDisplay;
	public string[] sentences;
	public string[] name;
	private int index;
	public float typingSpeed;
	public Animator fairyanimate;
	public Animator enemyanimate;
	public Animator budianimate;
	public GameObject fairy;
	public GameObject enemy;
	public float animduration;
	public AudioSource sound;

	public GameObject continueButton;

	void Start() {
		StartCoroutine (Type ());
	}

	void Update() {
		if (TextDisplay.text == sentences [index]) {
			continueButton.SetActive (true);
		}
	}

	IEnumerator Type() {
		NameDisplay.text = name [index];
		foreach (char letter in sentences[index].ToCharArray()) {
			TextDisplay.text += letter;
			yield return new WaitForSeconds (typingSpeed);
		}
	}

	IEnumerator TutorialBegin() {
		yield return new WaitForSeconds (1);
		fairy.SetActive (false);
		enemy.SetActive (true);
	}

	IEnumerator Attackshowoff() {
		enemyanimate.SetBool ("Attacking", true);
		sound.Play ();
		yield return new WaitForSeconds (animduration);
		enemyanimate.SetBool ("Attacking", false);
	}

	public void NextSentence() {
		if (index == 11) {
			continueButton.SetActive (false);
			fairyanimate.SetTrigger ("Exit");
			enemyanimate.SetTrigger ("Enter");
			StartCoroutine (TutorialBegin ());

		} else if (index == 18) {
			continueButton.SetActive (false);
			StartCoroutine (Attackshowoff ());
		}
		continueButton.SetActive (false);

		if (index < sentences.Length - 1) {
			index++;
			TextDisplay.text = "";
			NameDisplay.text = "";
			StartCoroutine (Type ());
		} else {
			if (sentences [index] == "BELAJAR?!") {
				SceneManager.LoadScene ("Comic1");
			} else if (sentences [index] == "Bersiaplah. Boss VOC menantimu...") {
				SceneManager.LoadScene ("LevelBoss1");
			} else {
			Debug.Log ("Complete");
			SceneManager.LoadScene ("Level0");
			}
		}
	}
}
