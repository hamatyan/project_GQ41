using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using _retoroGame.Player;
using DG.Tweening;
using _retoroGame.Camera;

/// <summary>
/// 移動処理
/// </summary>
namespace _retoroGame.Player.State
{
	public class PlayerMove: MonoBehaviour
	{
		public Rigidbody rb;
		public float moveSpeed = 10f;

		/// <summary>
		/// 引数ありコンストラクタ
		/// </summary>
		public PlayerMove (GameObject obj)
		{
			if(obj.GetComponent<PlayerMove>() == null)
				obj.AddComponent<PlayerMove>();
		}

		// Start is called before the first frame update
		void Start()
		{
			rb = this.GetComponent<Rigidbody>();
			moveSpeed = 10;
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
		/// 十字キー移動
		/// </summary>
		private void Move()
		{
			var hori = Input.GetAxis("Horizontal");
			var vert = Input.GetAxis("Vertical");

			//速度は要調整
			//rb.MovePosition(rb.position + new Vector3(hori * 0.1f, 0, vert * 0.1f));


			// カメラの方向から、X-Z平面の単位ベクトルを取得
			Vector3 cameraForward = Vector3.Scale(UnityEngine.Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

			// 方向キーの入力値とカメラの向きから、移動方向を決定
			//Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;
			Vector3 moveForward_key = cameraForward * vert + UnityEngine.Camera.main.transform.right * hori;
			if (vert == 0)
			{
				moveForward_key = -cameraForward * vert + UnityEngine.Camera.main.transform.right * hori;
			}

			if (hori != 0 && vert != 0)
			{
				rb.velocity = moveForward_key * (moveSpeed * 0.5f) + new Vector3(0, rb.velocity.y, 0);
			}
			else
			{
				// 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
				rb.velocity = moveForward_key * moveSpeed + new Vector3(0, rb.velocity.y, 0);
			}
		}
	}
}
