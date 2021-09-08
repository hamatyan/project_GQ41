using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace _retoroGame.Stage.Parameter
{
	public class ButtonPm : MonoBehaviour
	{
		[SerializeField] Renderer[] rendererComponent = new Renderer[2];
		[SerializeField] StagePm stagePm;

		private Button button;
		public Button _Button
		{
			set
			{
				button = value;
			}
			get
			{
				return button;
			}
		}
		public bool isbutton; //押したことあるか


		public enum Button
		{
			ON,
			OFF
		}

		private void Awake()
		{
			button = Button.OFF;
			isbutton = false;
		}

		// Start is called before the first frame update
		void Start()
		{
			this.rendererComponent[0].material.DOColor(stagePm.s_data.stage_Color, 1f);
			this.rendererComponent[1].material.DOColor(stagePm.s_data.stage_Color, 1f);
		}

		// Update is called once per frame
		void Update()
		{

		}
	}
}