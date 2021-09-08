using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲームエンド処理
/// </summary>
namespace _retoroGame.System
{
	public class SystemGameEnd : MonoBehaviour
	{
		GameState state;

		SystemObjInformation info;

		public SystemGameEnd(GameObject obj, GameState value)
		{
			if (obj.GetComponent<SystemGameEnd>() == null)
			{
				obj.AddComponent<SystemGameEnd>();
				state = value;
			}
		}

		private void Awake()
		{
			info = this.gameObject.GetComponent<SystemObjInformation>();
		}

		// Start is called before the first frame update
		void Start()
		{
			info.b_resultObj.SetActive(true);

			info.t_gamestartObj.SetActive(false);

			//フェード（見えるようになる）
			info.canvasGroup[0].DOFade(endValue: 1, duration: 0f);
		}

		// Update is called once per frame
		void Update()
		{

		}
	}
}