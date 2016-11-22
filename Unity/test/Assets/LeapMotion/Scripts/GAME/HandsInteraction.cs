using UnityEngine;
using System.Collections;
using Leap;

public class HandsInteraction : MonoBehaviour {

	Controller controller;
	bool flag_right = true;
	bool flag_left = true;

	bool grabbing (Hand hand) {
		//Debug.Log ("+"+hand.GrabStrength+"+");
		if (hand.GrabStrength > 0.5){
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
				if (flag_left && hand.IsLeft) {
					//Debug.Log ("left");
					left = true;
					flag_left = false;
				} else {
					flag_left = true;
				}
				if (flag_right && hand.IsRight) {
					//Debug.Log ("right");
					right = true;
					flag_right = false;
				} else {
					flag_right = true;
				}
			}
			if (right && left) {
				Debug.Log ("mapa!");
			} else if (right) {
				Debug.Log ("vira direita!");				
			} else if (left) {
				Debug.Log ("vira esquerda!");				
			}				
		}
	}
}
