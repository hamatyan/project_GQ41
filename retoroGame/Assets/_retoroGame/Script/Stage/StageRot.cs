using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _retoroGame.Stage.Gimmik
{
	public class StageRot : MonoBehaviour
	{
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
			this.transform.DORotate(Vector3.up * 90f, 1f);

			Destroy(this.gameObject.GetComponent<StageRot>());
		}

		// Update is called once per frame
		void Update()
		{

		}
	}
}