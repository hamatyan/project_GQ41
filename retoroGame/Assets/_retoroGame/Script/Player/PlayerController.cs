using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using _retoroGame.Player.State;

/// <summary>
/// 参考URL：https://www.hanachiru-blog.com/entry/2019/04/20/010740
/// </summary>
namespace _retoroGame.Player
{
	public class PlayerController : MonoBehaviour
	{
		//変更前のステート名
		public string _prevStateName;

		//ステート
		public StateProcessor StateProcessor { get; set; } = new StateProcessor();
		public PlayerStateIdle StateIdle { get; set; } = new PlayerStateIdle();
		public PlayerStateRun StateRun { get; set; } = new PlayerStateRun();
		public PlayerStateMove StateMove { get; set; } = new PlayerStateMove();
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

			//ステートの値が変更されたら実行を行うようにする
			StateProcessor.State
				.Where(_ => StateProcessor.State.Value.GetStateName() != _prevStateName)
				.Subscribe(_ =>
				{
					Debug.Log("Now State:" + StateProcessor.State.Value.GetStateName());
					_prevStateName = StateProcessor.State.Value.GetStateName();
					StateProcessor.Execute();
				})
				.AddTo(this);
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.A))
				StateProcessor.State.Value = StateMove;
		}

		public void Idle()
		{
			Debug.Log("StateがIdleに状態遷移しました。");
		}
		public void Run()
		{
			Debug.Log("StateがRunに状態遷移しました。");
		}
		public void Move()
		{
			PlayerMove _playerMove = new PlayerMove();
			_playerMove.Test(this.gameObject);

			Debug.Log("StateがMoveに状態遷移しました。");
		}
	}
}