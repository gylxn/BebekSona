using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackTo : MonoBehaviour {

    public void backto(int number) {
        SceneManager.LoadScene(number);
    }

	public void startfrombeginning() {
		SceneManager.LoadScene("Cutscene");
	}
}
