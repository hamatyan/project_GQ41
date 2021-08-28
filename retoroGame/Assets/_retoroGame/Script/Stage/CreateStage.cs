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
		public StageManager stageManager;  //ステージ格納用
		public int stage_obj_cnt;

		private void Awake()
		{
			stage_obj_cnt = stageManager.stageObj.Count;
		}

		// Start is called before the first frame update
		void Start()
		{
			float p = 0;
			//番号を順番につなげる(本当はエディタ上で動作したい)
			for (int i = 0; i < stage_obj_cnt - 1; i++)
			{
				if(stageManager.stageObj[i].transform.position.x == stageManager.stageObj[i + 1].transform.position.x)
				{
					p = stageManager.stageObj[i].transform.position.z - stageManager.stageObj[i+1].transform.position.z;
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

		// Update is called once per frame
		void Update()
		{

		}
	}
}
