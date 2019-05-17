using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//cameraにMainCameraタグをアサイン忘れるな
//もしくはcameraをpublic経由でアサインする
public class TapChara : MonoBehaviour {
	GameObject gameController;	//検索したオブジェクト入れる用
	GameObject zombie;			//tapしたオブジェクト入れる用
	private bool isTap = false;		//一回だけ処理
//	public AudioClip audioClipTap;	//tap SE

	void Start () {
		gameController = GameObject.FindWithTag ("GameController");	//GameControllerオブジェクトを探す
	}

	void Update () {
		//タップした判定
 		if(Input.GetMouseButtonDown(0)){
			Ray ray = new Ray();
            RaycastHit hit = new RaycastHit();
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if(Physics.Raycast(ray, out hit)){
				zombie = hit.collider.gameObject;
			}

			//Zombieをtapしたら
			if(zombie.tag == "Zombie"){
				//タッチに反応
				if(isTap == false){
					//自分がタッチされたか判定
					if(this.transform.name == zombie.name){					
						Debug.Log("transform.name:" + this.transform.name);
						//gcって仮の変数にGameControllerのコンポーネントを入れる
						GameController gc = gameController.GetComponent<GameController>();
						gc.zombieTap ++;
						//ちょっとだけ拡大させる
						zombie.transform.localScale = new Vector3(1.4f, 1.4f, 1.4f);
						isTap = true;
	//					//SEをその場で鳴らす
	//					AudioSource.PlayClipAtPoint( audioClipTap, transform.position);
						//0.1秒後に呼び出す
						Invoke("ScaleReset", 0.1f);
					}
				}
			}
		}
	}
	//時間差でスケールを戻す用
	void ScaleReset(){
		//元のスケールに戻す
		zombie.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		isTap = false;
	}
}
