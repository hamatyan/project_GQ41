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
		public GameObject mapCameraObj;
		public GameObject canvas;
		public GameObject t_gamestartObj;    //ゲームスタート文字

		public GoalFunction goalFunction;

		public Material t_gamestartMaterial;     //ゲームスタート文字マテリアル

		private void Awake()
		{
			t_gamestartMaterial = t_gamestartObj.GetComponent<Text>().material;
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