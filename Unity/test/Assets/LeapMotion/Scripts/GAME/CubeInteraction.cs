using UnityEngine;
using System.Collections;
using Leap;
using System.Collections.Generic;
using System;

public class CubeInteraction : MonoBehaviour
{
	public AudioClip dindon;
	private AudioSource source;
	private int time = 0;
	private bool flag_right = true;
	private bool flag_left = true;
	Controller controller;

	string whichHand (GameObject obj) {
		name = obj.transform.parent.gameObject.transform.parent.gameObject.name;
		//Debug.Log (name);
		if (name.Contains ("RigidRoundHand_R")) {
			return "right";
		}
		else if (name.Contains ("RigidRoundHand_L")){
			return "left";
		}
		return "error";
	}	

	void OnTriggerEnter (Collider col)
	{	
		time = 1;
		//Debug.Log ("+"+col.gameObject.name+"+");
		if (col.gameObject.name.Equals("bone3")) {
			source = GetComponent<AudioSource> ();
			if (flag_right && whichHand (col.gameObject).Equals ("right")) {
				Debug.Log ("mão direita!");
				source.panStereo = 1.0f;
				flag_right = false;
				source.PlayOneShot (dindon, 1);

			}
			else if (flag_left && whichHand (col.gameObject).Equals ("left")) {
				Debug.Log ("mão esquerda!");
				source.panStereo = -1.0f;
				flag_left = false;
				source.PlayOneShot (dindon, 1);
			}
		}
	}
	void OnTriggerExit (Collider col) {
		time = 0;
		if (col.gameObject.name.Equals("bone3")) {
			if (whichHand (col.gameObject).Equals ("right")) {				
				flag_right = true;
			} else if (whichHand (col.gameObject).Equals ("left")) {				
				flag_left = true;
			}
		}
	}

	// PARA PORTA!! - muda de room depois de um tempo esperando com a mão na porta (colocar som!)
	void Update () {
		if (!flag_left || !flag_right) {
			time++;
			if (time > 180) {
				time = 0;
				Debug.Log ("muda de room");
				string next_room = this.gameObject.name.Replace("Interaction", "");
				Debug.Log (next_room);
				//Application.LoadLevel("NOME_LUGAR");
			}
		} else {
			time = 0;
		}
	}
}