using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

namespace GameStates {
	public class WaitingForStrikeState  : AbstractGameObjectState {
		private GameObject cue;
		private GameObject cueBall;
		private GameObject mainCamera;

		private PoolGameController gameController;

		public WaitingForStrikeState(MonoBehaviour parent) : base(parent) { 
			gameController = (PoolGameController)parent;
			cue = gameController.cue;
			cueBall = gameController.cueBall;
			mainCamera = gameController.mainCamera;

			cue.GetComponent<Renderer>().enabled = true;
		}

		public override void Update() {
			var x = CrossPlatformInputManager.GetAxis("Horizontal");
			// 큐가 회전하는 속도
			if (x != 0) {
				var angle = x * 80 * Time.deltaTime;
				gameController.strikeDirection = Quaternion.AngleAxis(angle, Vector3.up) * gameController.strikeDirection;
				mainCamera.transform.RotateAround(cueBall.transform.position, Vector3.up, angle);
				cue.transform.RotateAround(cueBall.transform.position, Vector3.up, angle);
			}
			Debug.DrawLine(cueBall.transform.position, cueBall.transform.position + gameController.strikeDirection * 10);

			if (CrossPlatformInputManager.GetButtonDown("Fire1")) {
				gameController.currentState = new GameStates.StrikingState(gameController);
			}
		}
	}
}