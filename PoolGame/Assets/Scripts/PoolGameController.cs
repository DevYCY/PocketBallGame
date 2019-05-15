using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PoolGameController : MonoBehaviour {
	public GameObject cue;
	public GameObject cueBall;
	public GameObject redBalls;
	public GameObject mainCamera;
	public GameObject scoreBar;
	public GameObject winnerMessage;
    public Button replay;
    public Button home;

	public float maxForce;
	public float minForce;
	public Vector3 strikeDirection;

	public const float MIN_DISTANCE = 27.5f;
	public const float MAX_DISTANCE = 32f;
	
	public IGameObjectState currentState;





	// This is kinda hacky but works
	static public PoolGameController GameInstance {
		get;
		private set;
	}

	void Start() {
		strikeDirection = Vector3.forward;
		

		GameInstance = this;
		winnerMessage.GetComponent<Canvas>().enabled = false;

		currentState = new GameStates.WaitingForStrikeState(this);
	}
	
	void Update() {
		currentState.Update();
	}

	void FixedUpdate() {
		currentState.FixedUpdate();
	}

	void LateUpdate() {
		currentState.LateUpdate();
	}



	public void EndMatch() {


		var msg = "Game Over\n";



		var text = winnerMessage.GetComponentInChildren<UnityEngine.UI.Text>();
		text.text = msg;
		winnerMessage.GetComponent<Canvas>().enabled = true;
	}

    public void Replay()
    {
        SceneManager.LoadScene("Stage1");
		Time.timeScale = 1.0f;
        GameManager.instance.stars[0].sprite = GameManager.instance.normalStar;
        GameManager.instance.stars[1].sprite = GameManager.instance.normalStar;
        GameManager.instance.stars[2].sprite = GameManager.instance.normalStar;
    }

    public void Home()
    {
        SceneManager.LoadScene("ChapterSelector");
    }
}
