using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_BonusText : MonoBehaviour {
	public GameObject gameController;	//GameController取得
	public Text syougouText;			//Textコンポーネント取得用

	void Update () {
		//gcって仮の変数にGameControllerのコンポーネントを入れる
		GameController gc = gameController.GetComponent<GameController>();
		//tap数表示
		syougouText.text = "test : " + gc.syougou;
	}
}
