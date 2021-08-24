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
		public ButtonPm buttonPm;
		public ButtonManager buttonManager;
		public int select_number;

		public ButtonFunction(GameObject obj, int selectnum)
		{
			if (obj.GetComponent<ButtonFunction>() == null)
			{
				obj.AddComponent<ButtonFunction>();
			}
			select_number = selectnum;
		}

		// Start is called before the first frame update
		void Start()
		{
			buttonPm = this.gameObject.GetComponent<ButtonPm>();
			buttonManager = this.gameObject.transform.parent.GetComponent<ButtonManager>();
			buttonPm._Button = Button.OFF;
		}

		// Update is called once per frame
		void Update()
		{
			
		}

		protected void ButtonSwich()
		{
			switch (buttonPm._Button)
			{
				case Button.ON:
					buttonPm._Button = Button.OFF;
					break;
				case Button.OFF:
					buttonPm._Button = Button.ON;
					break;
			}
		}

		private void OnCollisionStay(Collision collision)
		{
			switch (collision.collider.tag)
			{
				case "Player":
					//ボタン表示
					if (Input.GetKeyDown(KeyCode.Return))
					{
						buttonManager.Select_Number = select_number;
						ButtonSwich();
						Debug.Log("押した");
						//送信　ボタンの中身
					}
					break;
			}
		}

	}
}