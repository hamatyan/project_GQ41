using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace _retoroGame.System
{
	public class GameStateController : MonoBehaviour
	{
		//変更前のステート名
		public string _prevStateName;

		//ステート
		public StateProcessor StateProcessor { get; set; } = new StateProcessor();
		public GameStateStart StateStart { get; set; } = new GameStateStart();
		public GameStatePlay StatePlay { get; set; } = new GameStatePlay();
		public GameStateClear StateClear { get; set; } = new GameStateClear();
		public GameStateOver StateOver { get; set; } = new GameStateOver();
		public GameStateEnd StateEnd { get; set; } = new GameStateEnd();
		//随時追加

		private void Awake()
		{
			StateProcessor.State.Value = StateStart;
		}

		private void Start()
		{
			//ステート初期化
			StateStart.ExecAction = _Start;
			StatePlay.ExecAction = Play;
			StateClear.ExecAction = Clear;
			StateOver.ExecAction = Over;
			StateEnd.ExecAction = End;

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

		}

		public void _Start()
		{
			Debug.Log("Stateが「_Start」に状態遷移しました。");
			SystemGameStart systemGameStart = new SystemGameStart(this.gameObject, StateProcessor.State.Value);
		}

		public void Play()
		{
			Debug.Log("Stateが「Play」に状態遷移しました。");
			SystemGamePlay systemGamePlay = new SystemGamePlay(this.gameObject, StateProcessor.State.Value);
		}

		public void Clear()
		{
			Debug.Log("Stateが「Clear」に状態遷移しました。");
			SystemGameClear systemGameClear = new SystemGameClear(this.gameObject, StateProcessor.State.Value);
		}

		public void Over()
		{
			Debug.Log("Stateが「Over」に状態遷移しました。");
		}

		public void End()
		{
			Debug.Log("Stateが「End」に状態遷移しました。");
		}
	}
}