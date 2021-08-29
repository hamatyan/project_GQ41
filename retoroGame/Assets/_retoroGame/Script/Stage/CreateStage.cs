using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 参考URL：https://www.hanachiru-blog.com/entry/2019/03/19/173335
/// </summary>
namespace _retoroGame.Stage
{
	public class CreateStage : MonoBehaviour
	{
		//ステージ生成列挙型
		public enum CreateStageEnum
		{
			BorderlineWall,
			Wall,
			GoalWall,
		}
		public CreateStageEnum createstageEnum;

		public StageManager stageManager;  //ステージ格納用
		public int stage_obj_cnt;

		//これは壁の生成に使う変数
		public Transform startPos;
		public Transform goalPos;

		private void Awake()
		{
			stage_obj_cnt = stageManager.stageObj.Count;
		}

		// Start is called before the first frame update
		void Start()
		{
			switch(createstageEnum)
			{
				case CreateStageEnum.BorderlineWall:
					CreateBorderlineWall();
					break;
				case CreateStageEnum.Wall:
					float p = 0;
					if (startPos.position.x == goalPos.position.x)
					{
						p = startPos.position.z - goalPos.position.z;
						startPos.transform.DOScaleZ(p, 1f).SetEase(Ease.Linear);
					}
					if (startPos.position.z == goalPos.position.z)
					{
						p = startPos.position.x - goalPos.position.x;
						startPos.transform.DOScaleX(p, 1f).SetEase(Ease.Linear);
					}
					break;
				case CreateStageEnum.GoalWall:
					break;
			}
		}

		// Update is called once per frame
		void Update()
		{

		}

		void CreateBorderlineWall()
		{
			float p = 0;
			//番号を順番につなげる(本当はエディタ上で動作したい)
			for (int i = 0; i < stage_obj_cnt - 1; i++)
			{
				if (stageManager.stageObj[i].transform.position.x == stageManager.stageObj[i + 1].transform.position.x)
				{
					p = stageManager.stageObj[i].transform.position.z - stageManager.stageObj[i + 1].transform.position.z;
					stageManager.stageObj[i].transform.DOScaleZ(p, 1f).SetEase(Ease.Linear);
				}
				if (stageManager.stageObj[i].transform.position.z == stageManager.stageObj[i + 1].transform.position.z)
				{
					p = stageManager.stageObj[i].transform.position.x - stageManager.stageObj[i + 1].transform.position.x;
					stageManager.stageObj[i].transform.DOScaleX(p, 1f).SetEase(Ease.Linear);
				}
			}
			p = stageManager.stageObj[0].transform.position.x - stageManager.stageObj[3].transform.position.x;
			stageManager.stageObj[3].transform.DOScaleX(p, 1f).SetEase(Ease.Linear);
		}
	}
}
