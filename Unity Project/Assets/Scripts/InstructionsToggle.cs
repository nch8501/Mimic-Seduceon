using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsToggle : MonoBehaviour {

    public SpriteRenderer keyboard;
    public SpriteRenderer controller;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Tab))
        {
            keyboard.enabled = !keyboard.enabled;
            controller.enabled = !controller.enabled;
        }
	}
}
