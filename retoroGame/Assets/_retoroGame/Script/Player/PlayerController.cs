using UnityEngine;
using UniRx;
using _retoroGame.Player.State;
using _retoroGame.Stage.Button;
using _retoroGame.System;

/// <summary>
/// 参考URL：https://www.hanachiru-blog.com/entry/2019/04/20/010740
/// </summary>
namespace _retoroGame.Player
{
	public class PlayerController : MonoBehaviour
	{
		//変更前のステート名
		public string _prevStateName;

		public ButtonManager buttonManager;
		public GameStateController stateController;

		bool b;

		//ステート
		public State.StateProcessor StateProcessor { get; set; } = new State.StateProcessor();
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
			b = false;

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
			if (stateController.StateProcessor.State.Value != stateController.StatePlay) return;

			if (Input.GetKeyDown(KeyCode.A) ||
				Input.GetKeyDown(KeyCode.D) ||
				Input.GetKeyDown(KeyCode.W) ||
				Input.GetKeyDown(KeyCode.S))
				StateProcessor.State.Value = StateMove;

			if(Input.GetKeyDown(KeyCode.Space) && !b)
			{
				b = true;
				StateProcessor.State.Value = StateJump;
			}
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
		private void OnTriggerEnter(Collider collider)
		{
			switch (collider.tag)
			{
				case "Button":
					if (buttonManager == null)
						Debug.LogError(this.gameObject.name + "のbuttonManagerがアタッチされてない");

					var name = collider.gameObject.name.GetLastChar(-1).ToString();
					var number = int.Parse(name);
					ButtonFunction button = new ButtonFunction(collider.gameObject/*, number*/);
					buttonManager.Select_Number = number;
					//ボタン表示
					buttonManager.canvasbutton.SetActive(true);
					break;
				//case "Enemy":
				//	break;
			}
		}

		private void OnTriggerExit(Collider collider)
		{
			buttonManager.canvasbutton.SetActive(false);
		}
	}
}