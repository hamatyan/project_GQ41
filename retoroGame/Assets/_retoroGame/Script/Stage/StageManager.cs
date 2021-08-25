using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _retoroGame.Stage.Button;

namespace _retoroGame.Stage
{
	public class StageManager : MonoBehaviour
	{
		public List<GameObject> stageObj;
		public ButtonManager buttonManager;

		private void Awake()
		{
			if (buttonManager == null)
				Debug.LogError(this.gameObject.name + "のbuttonManagerがアタッチされてない");
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