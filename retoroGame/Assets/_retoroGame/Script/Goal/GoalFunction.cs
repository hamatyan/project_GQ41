using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _retoroGame.Stage.Goal
{
	public class GoalFunction : MonoBehaviour
	{
		bool goalflag;
		public bool Goalflag
		{
			get
			{
				return goalflag;
			}
		}

		// Start is called before the first frame update
		void Start()
		{
			goalflag = false;
		}

		// Update is called once per frame
		void Update()
		{

		}

		private void OnTriggerEnter(Collider other)
		{
			if(other.tag == "Player")
			{
				goalflag = true;
			}
		}

	}
}
