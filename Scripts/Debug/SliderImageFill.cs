using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderImageFill : MonoBehaviour {

	[SerializeField]
	private Slider slider;
	private Image image;


	private void Awake() {
		image = GetComponent<Image>();
		slider.onValueChanged.AddListener(HandleSliderChanged);
	}

	// Use this for initialization
	private void Start () {
		HandleSliderChanged(slider.value);
	}

	private void HandleSliderChanged(float value){
		image.fillAmount = value;
	}
}
