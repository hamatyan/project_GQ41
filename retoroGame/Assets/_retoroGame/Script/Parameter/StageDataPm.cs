using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace _retoroGame.Stage.Parameter
{
	[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CreateStageData")]
	public class StageDataPm : ScriptableObject
	{
		[SerializeField] protected int stage_number;  //ステージ用の番号
		//[SerializeField] protected int pair_number;  //ステージ連携のペア番号
		[SerializeField] protected Color color;

		public int Stage_Namber
		{
			get { return stage_number; }
		}

		//public int Pair_Number
		//{
		//	get { return pair_number; }
		//}

		public Color stage_Color
		{
			get { return color; }
		}
	}

}
