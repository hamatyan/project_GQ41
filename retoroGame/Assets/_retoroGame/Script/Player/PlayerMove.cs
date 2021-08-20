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
		}

		// Update is called once per frame
		void Update()
		{
			Move();
		}

		void FixedUpdate()
		{
			
		}

		/// <summary>
		/// 十字キー移動
		/// </summary>
		private void Move()
		{
			var hori = Input.GetAxis("Horizontal");
			var vert = Input.GetAxis("Vertical");

			//速度は要調整
			rb.MovePosition(rb.position + new Vector3(hori * 0.1f, 0, vert * 0.1f));
		}
	}
}
