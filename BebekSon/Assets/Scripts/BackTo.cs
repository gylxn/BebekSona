using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackTo : MonoBehaviour {

	public SaveManager sm;

	void Awake() {
		sm = FindObjectOfType<SaveManager> ();
	}

    public void backto(int number) {
        SceneManager.LoadScene(number);
		Time.timeScale = 1;
    }

	public void decision() {
		if (sm.haveplayed == true) {
			SceneManager.LoadScene ("BreakRoom");
		} else { 
			startfrombeginning ();
		}
	}

	public void startfrombeginning() {
		SceneManager.LoadScene("Cutscene");
		Time.timeScale = 1;
	}
}
