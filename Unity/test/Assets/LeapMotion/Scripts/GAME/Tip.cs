using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tip : MonoBehaviour {

	static List<string> tips = new List<string>();
	static string tip; 

	// Use this for initialization
	void Start () {	
		
	}


	public static bool tipHere (string str) {
		if (tips.Count == 0) {
			tips.Add ("Armario_Cozinha");
			tips.Add ("Sofa_Sala");
			tip = tips[0];
		}
		Debug.Log (str);
		if (str.Contains(tip)){
			if (tips.IndexOf (tip) + 1 == tips.Count) {				
				GameManager.End_Game ();
			} else {
				tip = tips [tips.IndexOf (tip) + 1];
				return true;
			}
		}
		return false;
	}
}


