using _retoroGame.Stage.Parameter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;


namespace _retoroGame.Stage.Button
{
	public class ButtonManager : MonoBehaviour
	{
		public StageManager stageManager;
		public List<GameObject> buttonObjs;	//ボタンオブジェクト
		private List<ButtonPm>  buttonPms;	//ボタンパラメータcs

		private List<StagePm> stagePms;		//ステージパラメータcs
		public List<StagePm> buttonStagePms;//ボタンステージパラメータcs


		//今後テキスト用のスクリプト化
		public Text buttonstatetext;

		private int select_number;
		public int Select_Number
		{
			set
			{
				select_number = value;
			}
			get
			{
				return select_number;
			}
		}

		void Awake()
		{
			if(stageManager == null)
				Debug.LogError(this.gameObject.name + "のstageManagerがアタッチされてない");

			buttonPms = new List<ButtonPm>();
			stagePms = new List<StagePm>();
			buttonStagePms = new List<StagePm>();

			for (int i = 0;i < buttonObjs.Count;i++)
			{
				buttonPms.Add(buttonObjs[i].GetComponent<ButtonPm>());
				buttonStagePms.Add(buttonObjs[i].GetComponent<StagePm>());
			}
			for (int i = 0; i < stageManager.stageObj.Count; i++)
				stagePms.Add(stageManager.stageObj[i].GetComponent<StagePm>());
		}

		// Start is called before the first frame update
		void Start()
		{
			//ボタンが押された時
			this.UpdateAsObservable()
				.Where(_ => buttonPms[select_number].isbutton == true)
				.Subscribe(_ =>
				{
					var number = 0;
					for (int i = 0; i < stageManager.stageObj.Count; i++)
					{
						number = i;
						if (buttonStagePms[select_number].s_data.Stage_Namber == stagePms[i].s_data.Stage_Namber)
							break;
					}
					ButtonProsess(buttonPms[select_number]._Button, number);
				});
		}

		// Update is called once per frame
		void Update()
		{
			if(buttonstatetext != null)
				DrawText();
		}

		void DrawText()
		{
			buttonstatetext.text = "{";
			for (int i = 0; i < buttonPms.Count; i++)
			{
				buttonstatetext.text = buttonstatetext.text + buttonPms[i]._Button + ",";
			}
			buttonstatetext.text = buttonstatetext.text + "}";
		}

		void ButtonProsess(ButtonPm.Button button, int number)
		{
			switch(button)
			{
				case ButtonPm.Button.ON:
					Stage.Gimmik.StageRot stageRot = new Gimmik.StageRot(stagePms[number].gameObject);
					break;
				case ButtonPm.Button.OFF:
					Stage.Gimmik.StageResetTrans stageResetTrans = new Gimmik.StageResetTrans(stagePms[number].gameObject);

					break;
			}
		}
	}
}