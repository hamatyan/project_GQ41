using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _retoroGame.Stage
{
	public class CreateStage : MonoBehaviour
	{
		public StageManager stageManager;  //ステージ格納用
		public int stage_obj_cnt;

		private void Awake()
		{
			stage_obj_cnt = stageManager.stageObj.Count;
		}

		// Start is called before the first frame update
		void Start()
		{
			//番号を順番につなげる(本当はエディタ上で動作したい)
			for (int i = 0; i < stage_obj_cnt; i++)
			{
				if (i >= 3) return;

				//var nowstageT = stageManager.stageObj[i].transform;
				//var nextstageT = stageManager.stageObj[i + 1].transform;

				//var nowstageP = nowstageT.position;
				//var nextstageP = nextstageT.position;

				////1番の座標ー0番の座標＝大きさ
				//var s = nextstageP - nowstageP;
				////座標は現在いる場所
				//var p = nowstageP - s;


				//stageManager.stageObj[i].transform.position = p;
				//stageManager.stageObj[i].transform.localScale = s;

				var c = stageManager.stageObj[i + 1].transform.position - stageManager.stageObj[i].transform.position;
				Debug.DrawLine(stageManager.stageObj[i].transform.position, c);


				//エラー処理
				//if (null != stageManager.stageObj[i].gameObject.GetComponent<Parameter.StagePm>())
				//{
				//	var num = cs_stage[i].s_data.Stage_Namber;
				//}
			}

		}

		// Update is called once per frame
		void Update()
		{
			for (int i = 0; i < stage_obj_cnt; i++)
			{
				Vector3 c; 
				if (i >= 3)
				{
					 c = stageManager.stageObj[0].transform.position - stageManager.stageObj[i].transform.position;
				}
				else
					c = stageManager.stageObj[i + 1].transform.position - stageManager.stageObj[i].transform.position;

				Debug.DrawLine(stageManager.stageObj[i].transform.position, c);
			}
		}
	}
}
