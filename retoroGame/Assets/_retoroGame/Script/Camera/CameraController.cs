using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 参考URL：https://xr-hub.com/archives/6272
/// </summary>
namespace _retoroGame.Camera
{
	public class CameraController : MonoBehaviour
	{
		private GameObject mainCamera;              //メインカメラ格納用
		[SerializeField] private GameObject playerObj;//回転の中心となるプレイヤー格納用
		public float rotateSpeed = 2.0f;            //回転の速さ

		private void Awake()
		{
			if(playerObj == null)
				Debug.LogError(this.gameObject.name + "の[playerObj]がアタッチされてない");
		}

		//呼び出し時に実行される関数
		void Start()
		{
			mainCamera = this.gameObject;
		}

		//単位時間ごとに実行される関数
		void Update()
		{
			//rotateCameraの呼び出し
			rotateCamera();
		}

		//カメラを回転させる関数
		private void rotateCamera()
		{
			//Vector3でX,Y方向の回転の度合いを定義
			Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * -rotateSpeed, Input.GetAxis("Mouse Y") * rotateSpeed, 0);

			//transform.RotateAround()をしようしてメインカメラを回転させる
			mainCamera.transform.RotateAround(playerObj.transform.position, Vector3.up, angle.x);
			mainCamera.transform.RotateAround(playerObj.transform.position, transform.right, angle.y);
		}
	}
}