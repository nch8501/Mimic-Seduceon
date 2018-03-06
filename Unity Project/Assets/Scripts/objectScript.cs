using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class objectScript : MonoBehaviour {

    public bool isActiveObject = false;
    public SpriteRenderer overlayText;
    
    public bool isFinished = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public abstract void Interact();

    public abstract void FinishInteracting(bool dialogComplete);

    public abstract void Overlay();
}
