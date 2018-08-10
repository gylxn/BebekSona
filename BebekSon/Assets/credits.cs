using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class credits : MonoBehaviour {

	public GameObject credito;

	public void showcredits() {
		credito.SetActive (true);
	}

	public void closecredits() {
		credito.SetActive (false);
	}

}
