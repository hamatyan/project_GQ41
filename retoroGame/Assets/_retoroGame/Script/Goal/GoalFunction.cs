using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _retoroGame.Stage.Goal
{
	public class GoalFunction : MonoBehaviour
	{
		// Start is called before the first frame update
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{

		}

		private void OnTriggerEnter(Collider other)
		{
			if(other.tag == "Player")
			{
				Debug.Log("ステージクリア");
			}
		}

	}
}
