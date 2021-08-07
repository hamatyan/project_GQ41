using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using _retoroGame.Player;
using DG.Tweening;

/// <summary>
/// 移動処理
/// </summary>
namespace _retoroGame.Player.State
{
	public class PlayerMove: MonoBehaviour
	{
		/// <summary>
		/// 引数なしコンストラクタ
		/// </summary>
		public PlayerMove ()
		{
			Debug.Log("PlayerMoveの引数なしコンストラクタ");
		}

		// Start is called before the first frame update
		void Start()
		{
			
		}

		// Update is called once per frame
		void Update()
		{

		}

		public void Test(GameObject obj)
		{
			obj.transform.DOMove(endValue: new Vector3(5.0f, 0.5f, 0), duration: 2.0f);
		}
	}
}
