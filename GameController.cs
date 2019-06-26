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

	//ゲームステート
	enum State{
		GameStart,	//
		Play,		//
		Clear,		//不要かも
	}
	State state;

	void Start () {
		goSyougou = false;	//初期化
		GameStart();		//初期ステート
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
				syougou = text1[text1Index] + text2[text2Index];
				Debug.Log("syougou : " + syougou);
				goSyougou = true;
			}
		}else{
			goSyougou = false;
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
