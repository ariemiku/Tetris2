using UnityEngine;
using System.Collections;

// ステータス
public enum eStatus{
	eTutorial,
	ePlay,
	eGameover,
};

public class Game : MonoBehaviour {
	private eStatus m_Status;
	
	// Use this for initialization
	void Start () {
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
