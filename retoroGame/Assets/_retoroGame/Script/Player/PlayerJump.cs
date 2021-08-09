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
		[SerializeField] private float jumppower = 10.0f;
		[SerializeField] private int jumpcount = 1;
		[SerializeField] private float jumpanimetiontime = 0.5f;

		/// <summary>
		/// 引数ありコンストラクタ
		/// </summary>
		public PlayerJump(GameObject obj)
		{
			if (obj.GetComponent<PlayerJump>() == null)
				obj.AddComponent<PlayerJump>();
		}

		// Start is called before the first frame update
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{

		}

		public void Jump(GameObject obj)
		{
			obj.transform.DOJump(
					Vector3.up,      // 移動終了地点
					jumppower,               // ジャンプする力
					jumpcount,               // ジャンプする回数
					jumpanimetiontime              // アニメーション時間
					);
		}
	}
}
