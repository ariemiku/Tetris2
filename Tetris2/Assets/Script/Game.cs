using UnityEngine;
using System.Collections;

// ステータス
public enum eStatus{
	eTutorial,
	ePlay,
	eGameover,
};

public enum eTetriminoType{
	eO_Tetrimino,
	eI_Tetrimino,
	eS_Tetrimino,
	eZ_Tetrimino,
	eJ_Tetrimino,
	eL_Tetrimino,
	eT_Tetrimino,
};

// 色
public enum eColor{
	eRed,
	eBlue,
	eLightBlue,
	eYello,
	eYelloGreen,
	ePurple,
	eOrange,
	eBlack,
	None,
};

enum eBlockState{
	eEmpty,
	eUesd,
	eGhost,
	eUsing,
};

class Block{
	GameObject block;
	//public Material red;
	//public Material black;

	public Block(){
	}

	// キューブを生成する関数
	public void CreateBlock(){
		block = GameObject.CreatePrimitive (PrimitiveType.Cube);
	}

	// ブロックの位置を設定する関数
	public void SetPosition(Vector2 pos){
		block.transform.position = new Vector3 (pos.y, pos.x, 0.0f);
	}

	// ブロックの色を変える関数
	/*public void SetColorE(eColor color){
		Renderer renderer = block.GetComponent<Renderer>();
		switch (color) {
		case eColor.eRed:
			renderer.material = new Material (red);
			break;
		case eColor.eBlue:
			break;
		case eColor.eLightBlue:
			break;
		case eColor.eYello:
			break;
		case eColor.eYelloGreen:
			break;
		case eColor.ePurple:
			break;
		case eColor.eOrange:
			break;
		case eColor.eBlack:
			renderer.material = new Material (black);
			break;
		case eColor.None:
			break;
		}
	}*/

	public void SetColor(Material color){
		Renderer renderer = block.GetComponent<Renderer>();
		renderer.material = new Material (color);
	}

	public Material GetColor(){
		Renderer renderer = block.GetComponent<Renderer>();
		return renderer.material;
	}
}

/*
class Tetrimino{
	private int[,] tetrimino = new int [5, 5];
	
	public Tetrimino(){
	}
	
	public void SetTetrimino(eTetriminoType tetriminoType){
		switch(tetriminoType){
		case eTetriminoType.eO_Tetrimino:
			tetrimino = new int [,]{{0,0,0,0,0},
									{0,0,0,0,0},						
									{0,1,1,0,0},
									{0,1,1,0,0},
									{0,0,0,0,0}};
			break;
		case eTetriminoType.eI_Tetrimino:
			tetrimino = new int [,]{{0,0,1,0,0},
									{0,0,1,0,0},
									{0,0,1,0,0},
									{0,0,1,0,0},
									{0,0,0,0,0}};
			break;
		case eTetriminoType.eS_Tetrimino:
			tetrimino = new int [,]{{0,0,0,0,0},
									{0,0,0,0,0},
									{0,0,1,1,0},
									{0,1,1,0,0},
									{0,0,0,0,0}};
			break;
		case eTetriminoType.eZ_Tetrimino:
			tetrimino = new int [,]{{0,0,0,0,0},
									{0,0,0,0,0},
									{0,1,1,0,0},
									{0,0,1,1,0},
									{0,0,0,0,0}};
			break;
		case eTetriminoType.eJ_Tetrimino:
			tetrimino = new int [,]{{0,0,0,0,0},
									{0,0,1,0,0},	
									{0,0,1,0,0},
									{0,1,1,0,0},
									{0,0,0,0,0}};
			break;
		case eTetriminoType.eL_Tetrimino:
			tetrimino = new int [,]{{0,0,0,0,0},
									{0,0,1,0,0},
									{0,0,1,0,0},
									{0,0,1,1,0},
									{0,0,0,0,0}};
			break;
		case eTetriminoType.eT_Tetrimino:
			tetrimino = new int [,]{{0,0,0,0,0},
									{0,0,0,0,0},
									{0,1,1,1,0},
									{0,0,1,0,0},
									{0,0,0,0,0}};
			break;
		}
	}
} */

public class Game : MonoBehaviour {
	public static readonly int WIDTH = 10;		// 幅
	public static readonly int HEIGHT = 20;		// 高さ

	public static readonly int[,] O_Tetrimino = new int [,]{{0,0,0,0,0},
															{0,0,0,0,0},						
															{0,1,1,0,0},
															{0,1,1,0,0},
															{0,0,0,0,0}};
	
	public static readonly int[,] I_Tetrimino = new int [,]{{0,0,1,0,0},
															{0,0,1,0,0},
															{0,0,1,0,0},
															{0,0,1,0,0},
															{0,0,0,0,0}};
	
	public static readonly int[,] S_Tetrimino = new int [,]{{0,0,0,0,0},
															{0,0,0,0,0},
															{0,0,1,1,0},
															{0,1,1,0,0},
															{0,0,0,0,0}};
	
	public static readonly int[,] Z_Tetrimino = new int [,]{{0,0,0,0,0},
															{0,0,0,0,0},
															{0,1,1,0,0},
															{0,0,1,1,0},
															{0,0,0,0,0}};
	
	public static readonly int[,] J_Tetrimino = new int [,]{{0,0,0,0,0},
															{0,0,1,0,0},	
															{0,0,1,0,0},
															{0,1,1,0,0},
															{0,0,0,0,0}};
	
	public static readonly int[,] L_Tetrimino = new int [,]{{0,0,0,0,0},
															{0,0,1,0,0},
															{0,0,1,0,0},
															{0,0,1,1,0},
															{0,0,0,0,0}};
	
	public static readonly int[,] T_Tetrimino = new int [,]{{0,0,0,0,0},
															{0,0,0,0,0},
															{0,1,1,1,0},
															{0,0,1,0,0},
															{0,0,0,0,0}};




	private eStatus m_Status;
	//private eColor m_color;

	// マテリアル
	public Material red;
	public Material blue;
	public Material lightBlue;
	public Material yello;
	public Material yelloGreen;
	public Material purple;
	public Material orange;
	public Material black;

	Block[,] block=new Block[HEIGHT,WIDTH];
	eBlockState[,] m_blockState = new eBlockState[HEIGHT, WIDTH];

	eTetriminoType myTetrimonoType;
	Vector2 myPos;

	Block[,] nextTetrimino = new Block[5,5];
	eTetriminoType nextTetrimonoType;
	
	// Use this for initialization
	void Start () {
		for (int i=0; i<HEIGHT; i++) {
			for(int j=0;j<WIDTH;j++){
				// クラスのインスタンスを初期化する
				block[i,j] = new Block();

				// 20*10ブロックの作成
				Vector2 pos = new Vector2((HEIGHT/2)-i,-(WIDTH/2)+j);
				block[i,j].CreateBlock();
				block[i,j].SetPosition(pos);
				// ブロックの状態
				m_blockState[i,j] = eBlockState.eEmpty;
				block[i,j].SetColor(black);
			}
		}

		// 5*5ブロックの作成
		for (int i=0; i<5; i++) {
			for (int j=0; j<5; j++) {
				// クラスのインスタンスを初期化する
				nextTetrimino[i,j] = new Block();

				nextTetrimino[i,j].CreateBlock();
			}
		}
		DrawNextTetrimino();

		nextTetrimonoType = SetTetriminoType();
		myTetrimonoType = nextTetrimonoType;

		myPos = new Vector2 (0.0f,0.0f);
		m_Status = eStatus.eTutorial;
		Transit (m_Status);


	}

	// ランダムにテトリミノをセット
	eTetriminoType SetTetriminoType(){
		int type = Random.Range(0,7);
	
		return (eTetriminoType)type;
	}

	// 次のテトリミノを表示
	void DrawNextTetrimino(){
		nextTetrimonoType = SetTetriminoType();
		for (int i=0; i<5; i++) {
			for(int j=0;j<5;j++){
				Vector2 pos = new Vector2(5-i,6+j);
				nextTetrimino[i,j].SetPosition(pos);
				nextTetrimino[i,j].SetColor(black);

				switch(nextTetrimonoType){
				case eTetriminoType.eO_Tetrimino:
					if(O_Tetrimino[i,j]==1){
						nextTetrimino[i,j].SetColor(yello);
					}
					break;
				case eTetriminoType.eI_Tetrimino:
					if(I_Tetrimino[i,j]==1){
						nextTetrimino[i,j].SetColor(lightBlue);
					}
					break;
				case eTetriminoType.eS_Tetrimino:
					if(S_Tetrimino[i,j]==1){
						nextTetrimino[i,j].SetColor(yelloGreen);
					}
					break;
				case eTetriminoType.eZ_Tetrimino:
					if(Z_Tetrimino[i,j]==1){
						nextTetrimino[i,j].SetColor(red);
					}
					break;
				case eTetriminoType.eJ_Tetrimino:
					if(J_Tetrimino[i,j]==1){
						nextTetrimino[i,j].SetColor(blue);
					}
					break;
				case eTetriminoType.eL_Tetrimino:
					if(L_Tetrimino[i,j]==1){
						nextTetrimino[i,j].SetColor(orange);
					}
					break;
				case eTetriminoType.eT_Tetrimino:
					if(T_Tetrimino[i,j]==1){
						nextTetrimino[i,j].SetColor(purple);
					}
					break;
				}
			}
		}
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

	void Black(){
		for (int i=0; i<5; i++) {
			for (int j=0; j<5; j++) {
				if((int)myPos.y-j>=0 && ((int)myPos.y-j)< WIDTH)
				block[(int)myPos.x+i,(int)myPos.y-j].SetColor(black);
			}
		}
	}

	void SetBlock(){
		for (int i=0; i<5; i++) {
			for(int j=0;j<5;j++){
				if((int)myPos.y-j>=0 && ((int)myPos.y-j)< WIDTH){
					switch(myTetrimonoType){
					case eTetriminoType.eO_Tetrimino:
						if(O_Tetrimino[i,j]==1){
							block[(int)myPos.x+i,(int)myPos.y-j].SetColor(yello);
						}
						break;
					case eTetriminoType.eI_Tetrimino:
						if(I_Tetrimino[i,j]==1){
							block[(int)myPos.x+i,(int)myPos.y-j].SetColor(lightBlue);
						}
						break;
					case eTetriminoType.eS_Tetrimino:
						if(S_Tetrimino[i,j]==1){
							block[(int)myPos.x+i,(int)myPos.y-j].SetColor(yelloGreen);
						}
						break;
					case eTetriminoType.eZ_Tetrimino:
						if(Z_Tetrimino[i,j]==1){
							block[(int)myPos.x+i,(int)myPos.y-j].SetColor(red);
						}
						break;
					case eTetriminoType.eJ_Tetrimino:
						if(J_Tetrimino[i,j]==1){
							block[(int)myPos.x+i,(int)myPos.y-j].SetColor(blue);
						}
						break;
					case eTetriminoType.eL_Tetrimino:
						if(L_Tetrimino[i,j]==1){
							block[(int)myPos.x+i,(int)myPos.y-j].SetColor(orange);
						}
						break;
					case eTetriminoType.eT_Tetrimino:
						if(T_Tetrimino[i,j]==1){
							block[(int)myPos.x+i,(int)myPos.y-j].SetColor(purple);
						}
						break;
					}
				}
			}
		}
	}

	void StartPlay(eStatus PrevStatus){
		// 代わった時に1回しかやらないことをする
		Debug.Log ("Play");

		// 自分の初期位置（仮）
		myPos = new Vector2 (0,5);
		SetBlock ();

	}

	void StartGameover(eStatus PrevStatus){
		// 代わった時に1回しかやらないことをする
		Debug.Log ("Gameover");
	}

	// tutorial状態の更新関数
	void UpdateTutorial(){
		// enterキーでゲームに遷移する（仮）
		if (Input.GetKeyDown (KeyCode.Return)) {
			Transit (eStatus.ePlay);
		}
	}

	// play状態の更新関数
	void UpdatePlay(){
		// RightArrowキーで右へ移動
		if (Input.GetKeyDown (KeyCode.RightArrow) && myPos.y < WIDTH) {
			Black();
			myPos.y+=1;
			SetBlock ();
		}

		// LeftArrowキーで左へ移動
		if (Input.GetKeyDown (KeyCode.LeftArrow) && myPos.y > 3) {
			Black();
			myPos.y-=1;
			SetBlock ();
		}

		// nextブロックをspaceキーで変更する（仮）
		if (Input.GetKeyDown (KeyCode.Space)) {
			DrawNextTetrimino();
		}

		// enterキーでゲームオーバーに遷移する（仮）
		if (Input.GetKeyDown (KeyCode.Return)) {
			Transit (eStatus.eGameover);
		}
	}

	// gameover状態の更新関数
	void UpdateGameover(){
		// enterキーでタイトルに切り替える（仮）
		if(Input.GetKeyDown(KeyCode.Return))
		{
			Application.LoadLevel("Title");
		}
	}
}

