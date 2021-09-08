using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _retoroGame.Stage.Gimmik
{
	public class StageRot : MonoBehaviour
	{
		public enum RotNum
		{
			Right,
			Left
		}

		public RotNum rotNum;

		public StageRot(GameObject obj)
		{
			if (obj.GetComponent<StageRot>() == null)
			{
				obj.AddComponent<StageRot>();
			}
		}

		// Start is called before the first frame update
		void Start()
		{
			switch(rotNum)
			{
				case RotNum.Left:
					this.transform.DORotate(Vector3.up * 0f, 1f);
					break;
				case RotNum.Right:
					this.transform.DORotate(Vector3.up * 90f, 1f);
					break;
			}
			Destroy(this.gameObject.GetComponent<StageRot>());
		}

		// Update is called once per frame
		void Update()
		{

		}
	}
}