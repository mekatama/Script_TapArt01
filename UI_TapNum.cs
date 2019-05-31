using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_TapNum : MonoBehaviour {
	public GameObject gameController;	//GameController取得
	public Text tapNumText;				//Textコンポーネント取得用

	void Update () {
		//gcって仮の変数にGameControllerのコンポーネントを入れる
		GameController gc = gameController.GetComponent<GameController>();
		//tap数表示
		tapNumText.text = "zombie : " + gc.zombieTap.ToString("000000" + "p");
	}
}
