using _retoroGame.Player.State;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _retoroGame.System
{
	public class SystemGameClear : MonoBehaviour
	{
		GameState state;
		GameObject mapCameraObj;		//マップカメラ
		GameObject player;

		public SystemGameClear(GameObject obj, GameState value)
		{
			if (obj.GetComponent<SystemGameClear>() == null)
			{
				obj.AddComponent<SystemGameClear>();
				state = value;
			}
		}
		private void Awake()
		{
			mapCameraObj = GameObject.Find("MapCamera").gameObject;
			player = GameObject.Find("player").gameObject;
		}

		// Start is called before the first frame update
		void Start()
		{
			mapCameraObj.SetActive(false);

			if (player.GetComponent<PlayerMove>() != null)
				Destroy(player.GetComponent<Player.State.PlayerMove>());
			if (player.GetComponent<PlayerJump>() != null)
				Destroy(player.GetComponent<Player.State.PlayerJump>());


			//GameStateをStateClearに切り替え
			var statecs = this.gameObject.GetComponent<GameStateController>();
			this.gameObject.GetComponent<GameStateController>().StateProcessor.State.Value = statecs.StateEnd;


			//システム情報からthis情報を削除
			Destroy(this.GetComponent<SystemGameClear>());
		}

		// Update is called once per frame
		void Update()
		{

		}
	}
}