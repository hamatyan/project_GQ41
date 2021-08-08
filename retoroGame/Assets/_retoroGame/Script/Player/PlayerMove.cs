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
		public Rigidbody rb;
		float _moveSpeed = 1;

		/// <summary>
		/// 引数ありコンストラクタ
		/// </summary>
		public PlayerMove (GameObject obj)
		{
			obj.AddComponent<PlayerMove>();
			Debug.Log("PlayerMoveの引数なしコンストラクタ");
		}

		// Start is called before the first frame update
		void Start()
		{
			rb = this.GetComponent<Rigidbody>();
		}

		// Update is called once per frame
		void Update()
		{
		}

		void FixedUpdate()
		{
			Move();
		}

		/// <summary>
		/// キー移動
		/// </summary>
		private void Move()
		{
			var hori = Input.GetAxis("Horizontal");
			var vert = Input.GetAxis("Vertical");

			rb.MovePosition(rb.position + new Vector3(hori, 0, vert));
		}
	}
}
