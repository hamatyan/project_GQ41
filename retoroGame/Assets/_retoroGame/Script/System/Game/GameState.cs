using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace _retoroGame.System
{
	/// <summary>
	/// ステートの実行を管理するクラス
	/// </summary>
	public class StateProcessor
	{
		//ステート本体
		public ReactiveProperty<GameState> State { get; set; } = new ReactiveProperty<GameState>();
	
		//実行ブリッジ
		public void Execute() => State.Value.Execute();
	}
	
	public abstract class GameState
	{
		//デリゲート
		public Action ExecAction { get; set; }
	
		//実行処理
		public virtual void Execute()
		{
			if (ExecAction != null)
				ExecAction();
		}
	
		//ステート名を取得するメソッド
		public abstract string GetStateName();
	}

	//====================
	//以下状態クラス
	//====================
	public class GameStateStart : GameState
	{
		public override string GetStateName()
		{
			return "State:GameStart";
		}
	}

	public class GameStatePlay : GameState
	{
		public override string GetStateName()
		{
			return "State:GamePlay";
		}
	}

	public class GameStateClear : GameState
	{
		public override string GetStateName()
		{
			return "State:GameClear";
		}
	}

	public class GameStateOver : GameState
	{
		public override string GetStateName()
		{
			return "State:GameOver";
		}
	}

	public class GameStateEnd : GameState
	{
		public override string GetStateName()
		{
			return "State:GameEnd";
		}
	}
}