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
			SceneManager.LoadScene("StageSelect");
		}

		public void LoadStage1()
		{
			SceneManager.LoadScene("Stage1");
		}

		public void LoadStage2()
		{
			SceneManager.LoadScene("Stage2");
		}

		public void LoadStage3()
		{
			SceneManager.LoadScene("Stage3");
		}

		public void LoadStage4()
		{
			SceneManager.LoadScene("Stage4");
		}

		public void LoadStage5()
		{
			SceneManager.LoadScene("Stage5");
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

