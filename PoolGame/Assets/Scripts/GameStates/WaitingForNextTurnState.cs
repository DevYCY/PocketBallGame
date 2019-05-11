using UnityEngine;
using System.Collections;

namespace GameStates {
	public class WaitingForNextTurnState : AbstractGameObjectState {
		private PoolGameController gameController;
		private GameObject cue;
		private GameObject cueBall;
		private GameObject redBalls;
		private GameObject mainCamera;

		private Vector3 cameraOffset;
		private Vector3 cueOffset;
		private Quaternion cameraRotation;
		private Quaternion cueRotation;

		public WaitingForNextTurnState(MonoBehaviour parent) : base(parent) {
			gameController = (PoolGameController)parent;

			cue = gameController.cue;
			cueBall = gameController.cueBall;
			redBalls = gameController.redBalls;
			mainCamera = gameController.mainCamera;
			
			cameraOffset = cueBall.transform.position - mainCamera.transform.position;
			cameraRotation = mainCamera.transform.rotation;
			cueOffset = cueBall.transform.position - cue.transform.position;
			cueRotation = cue.transform.rotation;
		}

		public override void FixedUpdate() {
			Debug.Log(redBalls.GetComponentsInChildren<Transform>().Length);
			if (redBalls.GetComponentsInChildren<Transform>().Length == 1) {
				gameController.EndMatch();
			} else {
				var cueBallBody = cueBall.GetComponent<Rigidbody>();
				if (!(cueBallBody.IsSleeping() || cueBallBody.velocity == Vector3.zero))
					return;
				
				foreach (var rigidbody in redBalls.GetComponentsInChildren<Rigidbody>()) {
					if (!(rigidbody.IsSleeping() || rigidbody.velocity == Vector3.zero))
						return;
				}

				// 모든 볼이 가만히 있을때 다음턴으로 넘어감
				// 컨트롤러 패널 이동
				gameController.currentState = new WaitingForStrikeState(gameController);
			}
		}

		public override void LateUpdate() {
			mainCamera.transform.position = cueBall.transform.position - cameraOffset;
			mainCamera.transform.rotation = cameraRotation;
			
			cue.transform.position = cueBall.transform.position - cueOffset;
			cue.transform.rotation = cueRotation;
		}
	}
}