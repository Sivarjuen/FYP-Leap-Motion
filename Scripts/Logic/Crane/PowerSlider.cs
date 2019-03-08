using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;

public class PowerSlider : MonoBehaviour {

	public InteractionSlider slider;
	private Vector2 p1, p2, p3;
	private const float close_limit = 0.03f;
	private const float far_limit = 0.3f;
	private int finishedPoints;
	private bool completed;
	public GameObject cube;
	private Renderer cubeRenderer;
	public GameObject light1, light2, light3;
	private Renderer light1R, light2R,light3R;
	
	// Use this for initialization
	void Start () {
		finishedPoints = 0;
		completed = false;
		initialiseSolution();
		cubeRenderer = cube.GetComponent<Renderer>();
		light1R = light1.GetComponent<Renderer>();
		light2R = light2.GetComponent<Renderer>();
		light3R = light3.GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!completed){
			Vector2 temp = new Vector2(slider.HorizontalSliderPercent, slider.VerticalSliderPercent);
			float dist1 = Vector2.Distance(p1, temp);
			float dist2 = Vector2.Distance(p2, temp);
			float dist3 = Vector2.Distance(p3, temp);
			if(dist1 <= close_limit){
				processPoint(1);
			} else if(dist2 <= close_limit){
				processPoint(2);
			} else if(dist3 <= close_limit){
				processPoint(3);
			}

			float minDist = Mathf.Min(dist1, dist2);
			minDist = Mathf.Min(dist3, minDist);
			if(minDist >= far_limit){
				cubeRenderer.material.color = Color.red;
			} else if(minDist <= close_limit){
				cubeRenderer.material.color = Color.green;
			} else {
				float range = far_limit - close_limit;
				float t = (far_limit - minDist) / range;
				cubeRenderer.material.color = Color.Lerp(Color.red, Color.green, t);
			}
			if(finishedPoints == 3){
				completed = true;
			}
		}

	}

	private void initialiseSolution(){
		p1 = new Vector2(Random.Range(0.0f, 0.3f), Random.Range(0.0f, 1.0f));
		p2 = new Vector2(Random.Range(0.7f, 1.0f), Random.Range(0.0f, 1.0f));
		p3 = new Vector2(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
		float dist1 = Vector2.Distance(p1, p3);
		float dist2 = Vector2.Distance(p2, p3);
		while(dist1 < 0.4f || dist2 < 0.4f){
			p3 = new Vector2( Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
			dist1 = Vector2.Distance(p1, p3);
			dist2 = Vector2.Distance(p2, p3);
		}
	}

	private void processPoint(int index){
		finishedPoints++;
		switch(index){
			case 1:
				p1.x = 10.0f;
				p1.y = 10.0f;
				break;
			case 2:
				p2.x = 10.0f;
				p2.y = 10.0f;
				break;
			case 3:
				p3.x = 10.0f;
				p3.y = 10.0f;
				break;
		}

		switch(finishedPoints){
			case 1:
				light1R.material.color = Color.green;
				break;
			case 2:
				light2R.material.color = Color.green;
				break;
			case 3:
				light3R.material.color = Color.green;
				break;
		}
	}

	public bool isCompleted(){
		return completed;
	}
}
