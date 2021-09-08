using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace _retoroGame.Stage.Gimmik
{
	public class StageResetTrans : MonoBehaviour
	{
		public StageGimmick stageGimmick;


		public StageResetTrans(GameObject obj)
		{
			if (obj.GetComponent<StageResetTrans>() == null)
			{
				obj.AddComponent<StageResetTrans>();
			}
		}

		// Start is called before the first frame update
		void Start()
		{
			this.transform.DORotate(Vector3.up * 0f, 1f);
			Destroy(this.gameObject.GetComponent<StageResetTrans>());
		}

		// Update is called once per frame
		void Update()
		{

		}
	}
}