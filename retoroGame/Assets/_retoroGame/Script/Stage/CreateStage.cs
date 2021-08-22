using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _retoroGame.Stage
{
	public class CreateStage : MonoBehaviour
	{
		public List<GameObject> obj_stage;  //ステージ格納用
		public List<Parameter.StagePm> cs_stage;  //ステージ格納用
		public int stage_obj_cnt;

		private void Awake()
		{
			stage_obj_cnt = obj_stage.Count;


			for (int i = 0;i < stage_obj_cnt; i++)
			{
				if (null != obj_stage[i].gameObject.GetComponent<Parameter.StagePm>())
					cs_stage[i] = obj_stage[i].GetComponent<Parameter.StagePm>();
			}
		}

		// Start is called before the first frame update
		void Start()
		{
			//番号を順番につなげる(本当はエディタ上で動作したい)
			for (int i = 0; i < stage_obj_cnt; i++)
			{
				//エラー処理
				if (null != obj_stage[i].gameObject.GetComponent<Parameter.StagePm>())
				{
					var num =  cs_stage[i].s_data.Stage_Namber;
				}
			}

		}

		// Update is called once per frame
		void Update()
		{
			//番号を順番につなげる(本当はエディタ上で動作したい)
			for (int i = 0; i < stage_obj_cnt; i++)
			{
				// 自身の向きベクトル取得
				float angleDir = obj_stage[i].transform.eulerAngles.z * (Mathf.PI / 100.0f);
				Vector3 dir = new Vector3(Mathf.Cos(angleDir), Mathf.Sin(angleDir), 0.0f);
			}
		}
	}
}
