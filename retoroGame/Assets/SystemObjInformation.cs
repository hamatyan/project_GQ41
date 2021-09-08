using _retoroGame.Stage.Goal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace _retoroGame.System
{
	public class SystemObjInformation : MonoBehaviour
	{
		public GameObject b_resultObj;   //リザルトボタン
		public GameObject mapCameraObj;		//マップカメラ
		public GameObject t_gamestartObj;    //ゲームスタート文字

		public GameObject Gamecanvas;

		public GoalFunction goalFunction;

		public List<CanvasGroup> canvasGroup;	//フェード

		private void Awake()
		{
			this.canvasGroup[0] = Gamecanvas.transform.GetChild(1).GetComponent<CanvasGroup>();
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