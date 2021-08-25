using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace _retoroGame.Stage.Parameter
{
	public class ButtonPm : MonoBehaviour
	{
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

		}

		// Update is called once per frame
		void Update()
		{

		}
	}
}