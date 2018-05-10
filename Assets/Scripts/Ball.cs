﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var mousePositionToBlock = Mathf.Clamp((Input.mousePosition.x / Screen.width) * 16, 0.5f, 15.5f);

        this.transform.position = new Vector3(mousePositionToBlock, this.transform.position.y, 0f);
	}
}
