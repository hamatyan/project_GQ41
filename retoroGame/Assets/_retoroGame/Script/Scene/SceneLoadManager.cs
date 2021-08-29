using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace _retoroGame.Load
{
	public class SceneLoadManager : MonoBehaviour
	{
		Scene scene;

		//Start is called before the first frame update
		void Start()
		{
			scene = SceneManager.GetActiveScene();
		}

		// Update is called once per frame
		void Update()
		{
			//デバッグ用
			//if (scene.name == "Title")
			//{
			//    DontDestroyOnLoad(aobject);
			//}
		}

		public void LoadTitle()
		{
			SceneManager.LoadScene("Title");
		}

		public void LoadOption()
		{
			
		}

		public void LoadResult()
		{
			SceneManager.LoadScene("Result");
		}
		public void LoadGame()
		{
			SceneManager.LoadScene("Game");
		}

		public void LoadRanking()
		{

		}
		public void LoadNameScene()
		{
		}

		public void LoadPoseScene()
		{
		}

		public void Restart()
		{
		}
	}
}

