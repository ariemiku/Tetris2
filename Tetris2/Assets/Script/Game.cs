using UnityEngine;
using System.Collections;

// ステータス
public enum eStatus{
	eTutorial,
	ePlay,
	eGameover,
};

// 色
/*
public enum eColor{
	eRed,
	eBlue,
	eLightBlue,
	eYello,
	eYelloGreen,
	ePurple,
	eOrange,
	None,
};

class Block{
	GameObject block;
	eColor color;
	Vector2 position;
}
*/

public class Game : MonoBehaviour {
	public static readonly int WIDTH = 10;		// 幅
	public static readonly int HEIGHT = 20;		// 高さ

	private eStatus m_Status;
	
	GameObject[,] block=new GameObject[HEIGHT,WIDTH]; 
	
	// Use this for initialization
	void Start () {
		// 20*10ブロックの作成
		for (int i=0; i<HEIGHT; i++) {
			for(int j=0;j<WIDTH;j++){
				block[i,j] = GameObject.CreatePrimitive(PrimitiveType.Cube);
				block[i,j].transform.position = new Vector3(-(WIDTH/2)+j,-(HEIGHT/2)+i,0.0f);
			}
		}

		m_Status = eStatus.eTutorial;
		Transit (m_Status);
	}
	
	// Update is called once per frame
	void Update () {
		switch (m_Status) {
		case eStatus.eTutorial:
			UpdateTutorial ();
			break;
		case eStatus.ePlay:
			UpdatePlay ();
			break;
		case eStatus.eGameover:
			UpdateGameover ();
			break;
		}
	}

	// シーンを代える
	void Transit(eStatus NextStatus){
		switch (NextStatus) {
		case eStatus.eTutorial:
			m_Status = NextStatus;
			StartTutorial(m_Status);
			break;
		case eStatus.ePlay:
			m_Status = NextStatus;
			StartPlay(m_Status);
			break;
		case eStatus.eGameover:
			m_Status = NextStatus;
			StartGameover(m_Status);
			break;
		}
	}

	void StartTutorial(eStatus PrevStatus){
		// 代わった時に1回しかやらないことをする
		Debug.Log ("Tutorial");
	}

	void StartPlay(eStatus PrevStatus){
		// 代わった時に1回しかやらないことをする
		Debug.Log ("Play");
	}

	void StartGameover(eStatus PrevStatus){
		// 代わった時に1回しかやらないことをする
		Debug.Log ("Gameover");
	}

	// tutorial状態の更新関数
	void UpdateTutorial(){
		// enterキーでゲームに遷移する
		if (Input.GetKeyDown (KeyCode.Return)) {
			Transit (eStatus.ePlay);
		}
	}

	// tutorial状態の更新関数
	void UpdatePlay(){
		// enterキーでゲームオーバーに遷移する
		if (Input.GetKeyDown (KeyCode.Return)) {
			Transit (eStatus.eGameover);
		}
	}

	// tutorial状態の更新関数
	void UpdateGameover(){
		// enterキーでタイトルに切り替える
		if(Input.GetKeyDown(KeyCode.Return))
		{
			Application.LoadLevel("Title");
		}
	}
}
