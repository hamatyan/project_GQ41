using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _retoroGame.System
{
	public class GameStateController : MonoBehaviour
	{
		//変更前のステート名
		public string _prevStateName;

		//ステート
		public StateProcessor StateProcessor { get; set; } = new StateProcessor();
		public PlayerStateIdle StateIdle { get; set; } = new PlayerStateIdle();
		public PlayerStateRun StateRun { get; set; } = new PlayerStateRun();
		public PlayerStateMove StateMove { get; set; } = new PlayerStateMove();
		public PlayerStateJump StateJump { get; set; } = new PlayerStateJump();
		//随時追加

		private void Awake()
		{
			StateProcessor.State.Value = StateIdle;

		}

		private void Start()
		{
			//ステート初期化
			StateIdle.ExecAction = Idle;
			StateRun.ExecAction = Run;
			StateMove.ExecAction = Move;
			StateJump.ExecAction = Jump;

			//ステートの値が変更されたら実行を行うようにする
			StateProcessor.State
				.Where(_ => StateProcessor.State.Value.GetStateName() != _prevStateName)
				.Subscribe(_ =>
				{
					_prevStateName = StateProcessor.State.Value.GetStateName();
					StateProcessor.Execute();
				})
				.AddTo(this);
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.A) ||
				Input.GetKeyDown(KeyCode.D) ||
				Input.GetKeyDown(KeyCode.W) ||
				Input.GetKeyDown(KeyCode.S))
				StateProcessor.State.Value = StateMove;

			if (Input.GetKeyDown(KeyCode.Space))
				StateProcessor.State.Value = StateJump;
		}
	}
}