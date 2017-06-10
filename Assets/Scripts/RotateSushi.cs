using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum State : int {
	STOP = 0,
	ROTATE = 1,
}

public class RotateSushi : MonoBehaviour {

	[SerializeField]private TextMesh textMesh;
	[SerializeField]private Font[] font;
	private Vector3[] rotateAxises = new Vector3[6]{Vector3.back, Vector3.forward, Vector3.up, Vector3.down, Vector3.right, Vector3.left};
	private float t  = 0f;
	private float speed = 1f;
	private Vector3 rotateAxis = Vector3.back;
	private State state = State.STOP;

	private void Update () {
		if (state == State.ROTATE) {
			t += Time.deltaTime;
			t = Mathf.Clamp (t, 0, 1);
			transform.RotateAround (transform.position / 2f, rotateAxis, 360 * Time.deltaTime * speed);
			if (1 - t < Mathf.Epsilon) {
				t = 0;
			}
		}
	}

	public void SetFont(Dropdown _dropdown){
		DestroyImmediate (textMesh);
		textMesh = gameObject.AddComponent<TextMesh> ();
		textMesh.font = font [_dropdown.value];
		textMesh.alignment = TextAlignment.Center;
		textMesh.anchor = TextAnchor.MiddleCenter;
		textMesh.fontSize = 120;
		textMesh.characterSize = 100;
		textMesh.text = "鮨";
		gameObject.transform.localScale = new Vector3 (0.005f, 0.005f, 0);
		MeshRenderer rend = gameObject.GetComponentInChildren<MeshRenderer>();
		rend.material = textMesh.font.material;
	}

	public void SetSpeed(Slider slider){
		speed = slider.value;
	}

	public void SetRotateAxis(Dropdown _dropdown){
		gameObject.transform.rotation = Quaternion.Euler (0f, 0f, 0f);
		rotateAxis = rotateAxises [_dropdown.value];
	}

	public void Rotate(){
		state = State.ROTATE;
	}

	public void Stop(){
		state = State.STOP;
		gameObject.transform.rotation = Quaternion.Euler (0f, 0f, 0f);
	}
}
