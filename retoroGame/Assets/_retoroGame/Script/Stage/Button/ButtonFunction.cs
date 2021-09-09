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

		public ButtonFunction(GameObject obj)
		{
			if (obj.GetComponent<ButtonFunction>() == null)
			{
				obj.AddComponent<ButtonFunction>();
			}
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

		private void OnTriggerStay(Collider collider)
		{
			switch (collider.tag)
			{
				case "Player":
					//ボタン表示
					if (Input.GetKeyDown(KeyCode.K))
					{
						ButtonSwich();
						buttonPm.isbutton = true;
						//送信　ボタンの中身(現在plyerControllerでやってる)
					}
					break;
			}
		}

	}
}