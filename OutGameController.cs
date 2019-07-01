using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutGameController : MonoBehaviour {
	void Update(){
		//backキー
		if (Input.GetKeyUp(KeyCode.Escape)){
			Application.Quit();	//アプリ終了
		}
	}

	//main用の制御関数
	public void ButtonClicked_Start(){
		SceneManager.LoadScene("main");	//シーンのロード
	}

	//遊び方ボタン用の制御関数
	public void ButtonClicked_HowToPlay(){
		SceneManager.LoadScene("howtoplay");	//シーンのロード
	}

	//return用の制御関数
	public void ButtonClicked_Return(){
		SceneManager.LoadScene("title");	//シーンのロード
	}

	//アプリ終了
	public void ButtonClicked_Exit(){
		Application.Quit();
		Debug.Log("exit");	
	}
/*
	//shop用の制御関数
	public void ButtonClicked_Shop(){
		SceneManager.LoadScene("shop");	//シーンのロード
	}

	//Debug用ハイスコアリセットボタン
	public void ButtonClicked_Reset(){
		PlayerPrefs.DeleteAll();
		Debug.Log("全データ削除しますた");	
	}
*/
}
