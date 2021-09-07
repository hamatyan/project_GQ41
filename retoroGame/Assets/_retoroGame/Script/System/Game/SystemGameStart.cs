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

		GameObject mapCameraObj;		//マップカメラ
		GameObject t_gamestartObj;    //ゲームスタート文字
		Material t_gamestartMaterial;     //ゲームスタート文字マテリアル
		private GameState state;

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
			t_gamestartObj = GameObject.Find("[Game]Canvas/T_Gamestart").gameObject;

			mapCameraObj = GameObject.Find("MapCamera").gameObject;

			t_gamestartMaterial = t_gamestartObj.GetComponent<Text>().material;
		}

		// Start is called before the first frame update
		async void  Start()
		{
			mapCameraObj.SetActive(false);

			//ローカルからワールド座標変換の座標に向かって移動
			var p = this.gameObject.transform.position;
			var worldP = transform.TransformPoint(t_gamestartObj.transform.parent.position);	
			t_gamestartObj.transform.DOMoveX(worldP.x, 2.0f);

			await UniTask.WaitUntil(() => t_gamestartObj.transform.position.x == 512);

			//テキストの色をだんだん黒にする
			var text = t_gamestartObj.GetComponent<Text>();	
			text.DOColor(Color.black, 3.0f);

			await UniTask.WaitUntil(() => text.color == Color.black);

			//システム情報からスタート情報を削除
			Destroy(this.GetComponent<SystemGameStart>());
			
			//フェード（見えなくなる）
			var parentObj = t_gamestartObj.transform.parent.gameObject;
			t_gamestartMaterial.DOFade(endValue: 0, duration: 1f);

			//マップカメラON
			mapCameraObj.SetActive(true);

			//GameStateをStatePlayに切り替え
			var statecs = this.gameObject.GetComponent<GameStateController>();
			this.gameObject.GetComponent<GameStateController>().StateProcessor.State.Value = statecs.StatePlay;
		}

		// Update is called once per frame
		void Update()
		{

		}
	}
}