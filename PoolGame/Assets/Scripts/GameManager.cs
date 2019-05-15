using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GameManager : MonoBehaviour {
    public Image[] stars = new Image[3];
    public Sprite greyedStar;
    public Sprite normalStar; 
    public static GameManager instance;

    void Awake()
    {
        if (instance == null) instance = this;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
