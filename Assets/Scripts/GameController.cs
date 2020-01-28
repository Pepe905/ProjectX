using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public void QuitGame(){
#if UNITY_EDITOR
		Debug.Break();
#endif
		Application.Quit();
	}

	public void RestartGame(){
		SceneManager.LoadScene(StringCollection.S_INGAME);
	}
}
