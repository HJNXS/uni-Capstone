using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JMiles42.ItemSystem;
using UnityEngine.SceneManagement;

namespace levelOrganisation{

    [CreateAssetMenu(fileName = "New Level", menuName = "LevelOrganisation/New Level Scene")]
    public class LevelScene : CustomScene
    {
        public Puzzle puzzle;

		public int numberOfReset;

		public GameEvent ResetGame;
		public GameEvent ResetScene;

		//public List<GameEvent> decreaseLifeEvent;

		//private void Awake()
		//{
			//decreaseLifeEvent[numberOfReset].Invoke();

		//}

		public void UpdateLevel()
        {
            puzzle.UpdatePuzzle();
		}

		[System.Obsolete("Not decrease life")]
		public void IncreaseReset()
		{
			if (numberOfReset < 4)
			{
				numberOfReset++;
				ResetScene.Invoke();
			}
			else
			{
				ResetGame.Invoke();
			}
		}
	}
}

