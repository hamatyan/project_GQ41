using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using _retoroGame.Player;
using DG.Tweening;

/// <summary>
/// ジャンプ処理
/// </summary>
namespace _retoroGame.Player.State
{
	public class PlayerJump : MonoBehaviour
	{
		//スクリタブルobjに切り替えしたほうがいいかな
		private float jumppower = 5.0f;
		private int jumpcount = 1;
		private float jumpanimetiontime = 0.5f;

		public Rigidbody rb;

		/// <summary>
		/// 引数ありコンストラクタ
		/// </summary>
		public PlayerJump(GameObject obj)
		{
			if (obj.GetComponent<PlayerJump>() == null)
			{
				obj.AddComponent<PlayerJump>();
				jumppower = 5.0f;
				jumpcount = 1;
				jumpanimetiontime = 0.5f;
	}
		}

		// Start is called before the first frame update
		void Start()
		{
			rb = this.GetComponent<Rigidbody>();
			Jump();
		}

		// Update is called once per frame
		void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
				Jump();
		}

		public void Jump()
		{
			rb.transform.DOJump(
					rb.transform.position,			// 移動終了地点
					5.0f,						// ジャンプする力
					1,						// ジャンプする回数
					0.5f				// アニメーション時間
					);
		}
	}
}
