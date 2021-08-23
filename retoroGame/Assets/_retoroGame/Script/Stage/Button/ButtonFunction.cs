using _retoroGame.Stage.Parameter;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ボタン機能
/// 
/// </summary>
namespace _retoroGame.Stage.Button
{
	public class ButtonFunction : ButtonPm
	{
		ButtonPm.Button button;

		public ButtonFunction(GameObject obj)
		{
			if (obj.GetComponent<ButtonFunction>() == null)
			{
				obj.AddComponent<ButtonFunction>();
				button = Button.OFF;
			}
		}

		// Start is called before the first frame update
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{

		}

		protected void ButtonSwich()
		{
			switch (button)
			{
				case Button.ON:
					button = Button.OFF;
					break;
				case Button.OFF:
					button = Button.ON;
					break;
			}
		}

		void ButtonOn()
		{
			//番号のスイッチOn
			//ステージ回転起動
		}

		void ButtonOff()
		{
			//番号スイッチOff
			//ステージがもとに戻る
		}

		private void OnCollisionStay(Collision collision)
		{
			switch (collision.collider.tag)
			{
				case "Player":
					//ボタン表示
					Debug.Log("Enter");
					if (Input.GetKeyDown(KeyCode.Return))
					{
						ButtonSwich();
					}
					break;
			}
		}

	}
}