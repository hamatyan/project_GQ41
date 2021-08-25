using _retoroGame.Stage.Parameter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;
using UniRx.Triggers;


namespace _retoroGame.Stage.Button
{
	public class ButtonManager : MonoBehaviour
	{
		public List<GameObject> buttonObjs;	//ボタンオブジェクト
		public List<ButtonPm>  buttonPms;	//ボタンパラメータcs
		public List<StagePm> stagePms;				//ステージパラメータcs
		public List<StagePm> buttonStagePms;				//ボタンステージパラメータcs
		List<int> stageNamber;				//ステージナンバー
		public List<bool> buttonOn;

		public StageManager stageManager;

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
			buttonPms = new List<ButtonPm>();
			//stagePms = new List<StagePm>();
			stageNamber = new List<int>();

			for(int i = 0;i < buttonObjs.Count;i++)
			{
				buttonPms.Add(buttonObjs[i].GetComponent<ButtonPm>());
			}
		}

		// Start is called before the first frame update
		void Start()
		{
			
			//ボタンが押された時
			this.UpdateAsObservable()
				.Where(_ => buttonPms[select_number]._Button == ButtonPm.Button.ON)
				.Subscribe(_ =>
				{
					var b = buttonPms[select_number]._Button;
					var number = 0;
					
					for(int i = 0; i < stageManager.stageObj.Count; i++)
					{
						number = i;
						if (buttonStagePms[select_number].s_data.Stage_Namber == stagePms[i].s_data.Stage_Namber)
							break;
					}

					Debug.Log()
					Stage.Gimmik.StageRot stageRot = new Gimmik.StageRot(stagePms[number].gameObject);
				});
		}

		// Update is called once per frame
		void Update()
		{
		}
	}
}