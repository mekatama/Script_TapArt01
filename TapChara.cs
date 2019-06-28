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
	public AudioClip seDamage1;	//damage SE
	public AudioClip seDamage2;	//damage SE
	public AudioClip seKill;	//kill SE

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
//				Debug.Log("name : " + zombie.transform.name);
			}

			//Zombieをtapしたら
			if(zombie.tag == "Zombie"){
				//再生中animation取得
				AnimatorClipInfo clipInfo = anim.GetCurrentAnimatorClipInfo (0)[0];
//				Debug.Log ("アニメーションクリップ名 : " + clipInfo.clip.name);
				string anim_name = clipInfo.clip.name;	//再生中animation名を保存
				//タッチに反応
				if(isTap == false){
					//自分がタッチされたか判定
					if(this.transform.name == zombie.name){
						//motion_wait再生中かどうか判定
						if(anim_name == "motion_wait"){
							int criticalType = Random.Range(0,4);	//ランダムでクリティカル攻撃決める
							int animType = Random.Range(0,2);		//ランダムでanimation決める
							//ダメージ発生
							if(criticalType < 1){
								//クリティカルダメージ
								zombieHP = zombieHP - criticalDamage;	//クリティカルダメージ
								//SEをその場で鳴らす
								AudioSource.PlayClipAtPoint(seDamage2, transform.position);	//SE再生
								Debug.Log("クリティカルダメージ");
							}else{
								//通常ダメージ
								zombieHP --;							//通常ダメージ
								//SEをその場で鳴らす
								AudioSource.PlayClipAtPoint(seDamage1, transform.position);	//SE再生
							}

							//tap数
								//gcって仮の変数にGameControllerのコンポーネントを入れる
								GameController gc = gameController.GetComponent<GameController>();
								gc.zombieTap ++;

							//ダメージ処理
							if(zombieHP > 0){
								anim.SetBool("isDamage",true);	//animator用flag変更
							}else if(zombieHP <= 0){
								gc.zombieKill ++;				//kill数加算
								//SEをその場で鳴らす
								AudioSource.PlayClipAtPoint(seKill, transform.position);	//SE再生
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
						}
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

	//animation event
	void motionStart(){
		isTap = true;
//		Debug.Log("isTap motionStart : " + isTap);
//		Debug.Log("animation start!!");
	}
	void motionDamageStart(){
		isTap = true;
//		Debug.Log("isTap motionDamageStart : " + isTap);
	}
	void motionDown1Start(){
		isTap = true;
//		Debug.Log("isTap motionDown1Start : " + isTap);
	}
	void motionDown2Start(){
		isTap = true;
//		Debug.Log("isTap motionDown2Start : " + isTap);
	}

	void motionDamageFinish(){
		anim.SetBool("isDamage",false);	//animator用flag変更
		isTap = false;
//		Debug.Log("isTap motionDamageFinish : " + isTap);
	}
	void motionDown1Finish(){
		anim.SetBool("isDown",false);	//animator用flag変更
		isTap = false;
//		Debug.Log("isTap motionDownFinish : " + isTap);
	}
	void motionDown2Finish(){
		anim.SetBool("isDown2",false);	//animator用flag変更
		isTap = false;
//		Debug.Log("isTap motionDown2Finish : " + isTap);
	}
	void motionWait(){
//		Debug.Log("wait : " + isTap);
	}
}
