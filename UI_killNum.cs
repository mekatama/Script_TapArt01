using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_killNum : MonoBehaviour {
	public GameObject gameController;	//GameController取得
	public Text killNumText;				//Textコンポーネント取得用

	void Update () {
		//gcって仮の変数にGameControllerのコンポーネントを入れる
		GameController gc = gameController.GetComponent<GameController>();
		//tap数表示
		killNumText.text = "kill : " + gc.zombieKill.ToString("000000");
	}
}
