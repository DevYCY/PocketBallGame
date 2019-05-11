using UnityEngine;
using System.Collections;

public class PocketsController : MonoBehaviour {
	public GameObject redBalls;
	public GameObject cueBall;

	// 게임오버 메세지 객체 //
	public GameObject messageCanv;

	private Vector3 originalCueBallPosition;
	public int hitRedBallCount = 0; 

	void Start() {
		originalCueBallPosition = cueBall.transform.position;
	}

	void OnCollisionEnter(Collision collision) {
		foreach (var transform in redBalls.GetComponentsInChildren<Transform>()) {
			if (transform.name == collision.gameObject.name) {
				var objectName = collision.gameObject.name;
				GameObject.Destroy(collision.gameObject);

                // RedBalls가 골에 들어갔을때 UI에 점수표기
				hitRedBallCount++; 
				if (hitRedBallCount == 6) {
					hitRedBallCount = 0;
					// 게임오버 메세지를 활성화 함 //
					messageCanv.gameObject.SetActive(true);
					messageCanv.gameObject.GetComponent<Canvas>().enabled = true;
					// 게임 정지 //
					Time.timeScale = 0;
				}
			}
		}
        // 큐볼이 포켓콜라이더로 들어갈시 원래대로
		if (cueBall.transform.name == collision.gameObject.name) {
			cueBall.transform.position = originalCueBallPosition;
		}
	}
}
