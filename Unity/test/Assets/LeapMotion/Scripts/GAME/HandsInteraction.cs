using UnityEngine;
using System.Collections;
using Leap;

public class HandsInteraction : MonoBehaviour {

	Controller controller;
	int cont_right = 0;
	int cont_left = 0;

	bool grabbing (Hand hand) {
		//Debug.Log ("+"+hand.GrabStrength+"+");
		if (hand.GrabStrength >=0.9f){
			return true;
		}
		return false;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {	
		controller = new Controller ();
		Frame frame = controller.Frame ();
		bool left = false;
		bool right = false;
		foreach (Hand hand in frame.Hands) {
			if (grabbing(hand)) {
				if (hand.IsLeft) {
					//Debug.Log ("left");
					left = true;

				}
				if (hand.IsRight) {
					//Debug.Log ("right");
					right = true;
				} 
			}

			if (right && left) {
				if (cont_left < cont_right) {
					cont_left = cont_right;
				}
				cont_left++;
				cont_right++;
			} else if (right) {
				cont_right++;
				Debug.Log ("+"+hand.GrabStrength+"+right");
				cont_left = 0;
			} else if (left) {
				cont_left++;
				Debug.Log ("+"+hand.GrabStrength+"+left");
				cont_right = 0;

			} else {
				cont_left = 0;
				cont_right = 0;
			}
		}
		//Debug.Log ("right" + cont_right);
		//Debug.Log ("left" + cont_left);
		if (cont_left == 200 && cont_right == 200) {
			Debug.Log ("!!!!!!!!!!!!!!!!!!!!!!!!!!!!mapa");
			//Application.LoadLevel("MAPA_LUGAR");
			cont_left = 0;
			cont_right = 0;

		}

		else if (cont_left == 300){
			Debug.Log ("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!virar left");
			GameObject obj = GameObject.Find("Camera");
			obj.transform.Rotate(0, 90, 0);
			cont_left = 0;
			cont_right = 0;

		}
		else if (cont_right == 300){
			Debug.Log ("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!virar right");
			GameObject obj = GameObject.Find("Camera");
			obj.transform.Rotate(0, -90, 0);
			cont_left = 0;
			cont_right = 0;

		}
	}
}
