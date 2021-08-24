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
		public List<GameObject> buttonObjs;
		public List<ButtonPm>  buttonPms;
		List<StagePm> stagePms;
		List<int> stageNamber;

		public int select_number;
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
		public int old_select_number;


		void Awake()
		{
			buttonPms = new List<ButtonPm>();
			stagePms = new List<StagePm>();
			stageNamber = new List<int>();

			for(int i = 0;i < buttonObjs.Count;i++)
				buttonPms.Add(buttonObjs[i].GetComponent<ButtonPm>());
		}

		// Start is called before the first frame update
		void Start()
		{
		
			this.UpdateAsObservable()
				.Where(_ => buttonPms[select_number]._Button == ButtonPm.Button.ON)
				.Subscribe(_ =>
				{
					Debug.Log("押した番号" + select_number);
				});


			//ボタンが押されたタイミング
			//押されているボタンの情報を取得
			//取得したボタンの番号のstageに回転ギミック処理のスクリプトをnewする
		}

		// Update is called once per frame
		void Update()
		{

		}
	}
}