using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 一連の動作
/// </summary>
//
namespace _retoroGame.Stage.Gimmik
{
	public class StageGimmick : MonoBehaviour
	{
		enum StageGimmickState
		{
			NONE,
			START,
			UPDATE,
			END
		}

		Transform startTransform;
		public Transform StartTrans
		{
			get { return startTransform; }
		}

		private void Awake()
		{
			startTransform = this.gameObject.transform;
		}

		// Start is called before the first frame update
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{

		}
	}
}
