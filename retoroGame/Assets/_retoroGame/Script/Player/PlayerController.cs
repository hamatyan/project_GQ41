using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using _retoroGame.Player.State;
using _retoroGame.Stage.Button;

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

			if(Input.GetKeyDown(KeyCode.Space))
				StateProcessor.State.Value = StateJump;
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
			Debug.Log("StateがMoveに状態遷移しました。");
			PlayerMove _playerMove = new PlayerMove(this.gameObject);

		}
		public void Jump()
		{
			Debug.Log("StateがJumpに状態遷移しました。");
			PlayerJump _playerJump = new PlayerJump(this.gameObject);
		}


		/// <summary>
		/// 当たり判定
		/// </summary>
		/// <param name="collider"></param>
		private void OnCollisionEnter(Collision collision)
		{
			switch (collision.collider.tag)
			{
				case "Button":
					ButtonFunction button = new ButtonFunction(collision.collider.gameObject);
					//ボタン表示
					break;
				case "Enemy":
					break;
			}
		}
	}
}