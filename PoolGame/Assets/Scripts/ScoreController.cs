﻿using UnityEngine;
using System;
using System.Collections;

public class ScoreController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var text = GetComponent<UnityEngine.UI.Text>();
		
		text.text = String.Format("* {0} - {1}\n  {2} - {3}");
	}
}
