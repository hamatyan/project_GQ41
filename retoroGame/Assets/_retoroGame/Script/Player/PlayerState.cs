using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

/// <summary>
/// プレイヤーの状態
/// </summary>
namespace _retoroGame.Player.State
{
	/// <summary>
	/// ステートの実行を管理するクラス
	/// </summary>
	public class StateProcessor
	{
		//ステート本体
		public ReactiveProperty<PlayerState> State { get; set; } = new ReactiveProperty<PlayerState>();

		//実行ブリッジ
		public void Execute() => State.Value.Execute();
	}

	public abstract class PlayerState
	{
		//デリゲート
		public Action ExecAction { get; set; }

		//実行処理
		public virtual void Execute()
		{
			if(ExecAction != null)
				ExecAction();
		}
		
		//ステート名を取得するメソッド
		public abstract string GetStateName();
	}

	//====================
	//以下状態クラス
	//====================
	public class PlayerStateIdle : PlayerState
	{
		public override string GetStateName()
		{
			return "State:Idle";
		}
	}

	public class PlayerStateMove : PlayerState
	{
		public override string GetStateName()
		{
			return "State:Move";
		}
	}

	public class PlayerStateRun : PlayerState
	{
		public override string GetStateName()
		{
			return "State:Run";
		}
	}

	public class PlayerStateJump : PlayerState
	{
		public override string GetStateName()
		{
			return "State:Jump";
		}
	}
}


