using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//cameraにMainCameraタグをアサイン忘れるな
//もしくはcameraをpublic経由でアサインする
public class TapChara : MonoBehaviour {
	GameObject gameController;	//検索したオブジェクト入れる用
	GameObject zombie;			//tapしたオブジェクト入れる用
	private bool isTap = false;	//一回だけ処理
	Animator anim;				//Animator入れる用
	public int zombieHP;		//HP
	private int zombieHPMax;	//MaxHP一時保存用
	public int criticalDamage;	//クリティカルダメージ値
//	public AudioClip audioClipTap;	//tap SE

	void Start () {
		gameController = GameObject.FindWithTag ("GameController");	//GameControllerオブジェクトを探す
		anim = this.gameObject.GetComponent<Animator> ();			//Animatorを取得
		zombieHPMax = zombieHP;		//maxHP保存
	}

	void Update () {
		//タップした判定
 		if(Input.GetMouseButtonDown(0)){
			Ray ray = new Ray();
            RaycastHit hit = new RaycastHit();
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if(Physics.Raycast(ray, out hit)){
				zombie = hit.collider.gameObject;	//tapしたobject取得
			}

			//Zombieをtapしたら
			if(zombie.tag == "Zombie"){
				//タッチに反応
				if(isTap == false){
					//自分がタッチされたか判定
					if(this.transform.name == zombie.name){
						int animType = Random.Range(0,2);	//ランダムでanimation決める
						int criticalType = Random.Range(0,4);	//ランダムでクリティカル攻撃決める
						//gcって仮の変数にGameControllerのコンポーネントを入れる
						GameController gc = gameController.GetComponent<GameController>();
						gc.zombieTap ++;					//tap数加算
						//ダメージ発生
						if(criticalType < 1){
							zombieHP = zombieHP - criticalDamage;	//クリティカルダメージ
							Debug.Log("クリティカルダメージ");
						}else{
							zombieHP --;							//通常ダメージ
						}
						Debug.Log("HP:" + zombieHP + " : " +	this.transform.name);
						if(zombieHP > 0){
							//animator用flag変更
							anim.SetBool("isDamage",true);
						}else if(zombieHP <= 0){
							//animetion分岐
							switch(animType){
								case 0:
									anim.SetBool("isDown",true);	//animator用flag変更
									zombieHP = zombieHPMax;			//HP初期値にする
									break;
								case 1:
									anim.SetBool("isDown2",true);	//animator用flag変更
									zombieHP = zombieHPMax;			//HP初期値にする
									break;
							}
						}
						isTap = true;						//一回だけ処理用
						//SEをその場で鳴らす
	//					AudioSource.PlayClipAtPoint( audioClipTap, transform.position);
						//1秒後に呼び出す
						Invoke("PositionReset", 2.0f);
					}
				}
			}
		}
	}
	//時間差で位置を戻す用
	void PositionReset(){
		//元の位置に戻す
		anim.SetBool("isDown",false);	//animator用flag変更
		anim.SetBool("isDown2",false);	//animator用flag変更
		anim.SetBool("isDamage",false);	//animator用flag変更
		isTap = false;
	}
}
