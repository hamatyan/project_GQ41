using _retoroGame.Stage.Goal;
using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲームプレイ中の処理
/// </summary>
namespace _retoroGame.System
{
	public class SystemGamePlay : MonoBehaviour
	{
		GameState state;
		SystemObjInformation info;

		public SystemGamePlay(GameObject obj, GameState value)
		{
			if (obj.GetComponent<SystemGamePlay>() == null)
			{
				obj.AddComponent<SystemGamePlay>();
				state = value;
			}
		}

		private void Awake()
		{
			info = this.gameObject.GetComponent<SystemObjInformation>();
		}

		// Start is called before the first frame update
		async void Start()
		{
			await UniTask.WaitUntil(() => info.goalFunction.Goalflag);

			//GameStateをStateClearに切り替え
			var statecs = this.gameObject.GetComponent<GameStateController>();
			this.gameObject.GetComponent<GameStateController>().StateProcessor.State.Value = statecs.StateClear;

			//システム情報からthis情報を削除
			Destroy(this.GetComponent<SystemGamePlay>());
		}

		// Update is called once per frame
		void Update()
		{

		}
	}
}