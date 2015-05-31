using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {
	public Transform[] layers;
	public float[] scales;
	public float smoothing = 1f;

	private Transform cam;
	private Vector3 previousCamPos;

	void Awake(){
		cam = Camera.main.transform;
	}
	// Use this for initialization
	void Start () {
		previousCamPos = cam.position;
		scales = new float[layers.Length];
		for (int i = 0; i < layers.Length; i++) {
			scales[i] = layers[i].position.z* - 2;
		}
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < layers.Length; i++) {
			float parallax = (previousCamPos.x - cam.position.x) * scales[i];
			Vector3 newPos = new Vector3(layers[i].position.x + parallax, layers[i].position.y, layers[i].position.z);
			layers[i].position = Vector3.Lerp(layers[i].position, newPos, smoothing * Time.deltaTime);
		}
		previousCamPos = cam.position;
	}
}
