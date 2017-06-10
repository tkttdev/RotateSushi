using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeStateButton : MonoBehaviour {
	[SerializeField] private RotateSushi rotateSushi;
	[SerializeField] private Text changeStateText;
	private State state = State.STOP;

	public void ChangeState(){
		if (state == State.STOP) {
			state = State.ROTATE;
			rotateSushi.Rotate ();
			changeStateText.text = "STOP";
		} else {
			state = State.STOP;
			rotateSushi.Stop ();
			changeStateText.text = "ROTATE";
		}
	}
}
