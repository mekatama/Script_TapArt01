using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	public int zombieTap;	//Tap数
	public string[] text1;	//称号text1
	public string[] text2;	//称号text1
	public string syougou;	//称号表示用text
	private bool goSyougou;	//1回だけ用
	public Text syougouText;	//Textコンポーネント取得用
	float syougouUITime = 3.0f;	//UIを表示する時間
	float time_UI = 0f;			//UIを表示する時間用の変数

	//ゲームステート
	enum State{
		GameStart,	//
		Play,		//
		Clear,		//不要かも
	}
	State state;

	void Start () {
		goSyougou = false;				//初期化
		syougouText.enabled = false;	//UI非表示
		GameStart();					//初期ステート
	}

	void LateUpdate () {
		//ステートの制御
		switch(state){
			case State.GameStart:
//				Debug.Log("game start");
				Play();		//ステート移動		
				break;
			//
			case State.Play:
//				Debug.Log("play");
				//finish判定
//				if(isGameOver){
//					Clear();	//ステート移動
//				}
				break;
			//
			case State.Clear:
//				Debug.Log("clear");
				break;
		}
	}


	void Update () {
		//称号表示判定
		if(zombieTap %3 == 0 && zombieTap > 0){
//		if(zombieTap == 2){
			if(goSyougou == false){
				int text1Index = Random.Range(0,text1.Length);	//ランダムでtext決める
				int text2Index = Random.Range(0,text2.Length);	//ランダムでtext決める
				syougou = text1[text1Index] + text2[text2Index];//text合成
				Debug.Log("syougou : " + syougou);
				goSyougou = true;
				syougouText.enabled = true;		//UI表示
			}
		}else{
			goSyougou = false;
		}

		//UIを時間で非表示にする
		if(syougouText.enabled == true){
			time_UI += Time.deltaTime;
			if(time_UI > syougouUITime){
				syougouText.enabled = false;	//UI非表示
				time_UI = 0f;					//初期化
			}
		}
	}

	void GameStart(){
		state = State.GameStart;
	}
	void Play(){
		state = State.Play;
	}
	void Clear(){
		state = State.Clear;
	}
}
