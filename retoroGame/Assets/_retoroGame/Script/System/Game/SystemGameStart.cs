using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using Cysharp.Threading.Tasks;

/// <summary>
/// ゲーム開始の処理
/// </summary>
/// 
namespace _retoroGame.System
{
	public class SystemGameStart : MonoBehaviour
	{
		bool gamestartflag; //ゲームスタートフラグ

		private GameState state;
		SystemObjInformation info;

		public SystemGameStart(GameObject obj, GameState value)
		{
			if (obj.GetComponent<SystemGameStart>() == null)
			{
				obj.AddComponent<SystemGameStart>();
				state = value;
			}
		}

		private void Awake()
		{
			info = this.gameObject.GetComponent<SystemObjInformation>();
		}

		// Start is called before the first frame update
		async void  Start()
		{
			//ローカルからワールド座標変換の座標に向かって移動
			var p = this.gameObject.transform.position;
			var worldP = transform.TransformPoint(info.t_gamestartObj.transform.parent.position);	
			info.t_gamestartObj.transform.DOMoveX(worldP.x, 2.0f);

			await UniTask.WaitUntil(() => info.t_gamestartObj.transform.position.x == 512);

			//テキストの色をだんだん黒にする
			var text = info.t_gamestartObj.GetComponent<Text>();	
			text.DOColor(Color.black, 3.0f);

			await UniTask.WaitUntil(() => text.color == Color.black);

			//フェード（見えなくなる）
			info.t_gamestartMaterial.DOFade(endValue: 0, duration: 1f);

			//マップカメラON
			info.mapCameraObj.SetActive(true);

			//GameStateをStatePlayに切り替え
			var statecs = this.gameObject.GetComponent<GameStateController>();
			this.gameObject.GetComponent<GameStateController>().StateProcessor.State.Value = statecs.StatePlay;

			//システム情報からスタート情報を削除
			Destroy(this.GetComponent<SystemGameStart>());
		}

		// Update is called once per frame
		void Update()
		{

		}
	}
}