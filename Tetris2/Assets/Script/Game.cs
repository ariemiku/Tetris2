using UnityEngine;
using System.Collections;

using UnityEngine.UI;

// ステータス
public enum eStatus{
	Tutorial,
	Play,
	Gameover,
};

public enum eTetriminoType{
	OTetrimino,
	ITetrimino,
	STetrimino,
	ZTetrimino,
	JTetrimino,
	LTetrimino,
	TTetrimino,
};

enum eKeyCode{
	RightArrow,
	LeftArrow,
	DownArrow,
	ZKeyCode,
	XKeyCode,
	None,
};

enum eBlockState{
	Empty,
	Used,
	Ghost,
	Using,
};

class cBlock{
	GameObject block;

	public cBlock(){
	}

	// キューブを生成する関数
	public void CreateBlock(){
		block = GameObject.CreatePrimitive (PrimitiveType.Cube);
	}

	// ブロックの位置を設定する関数
	public void SetPosition(Vector2 pos){
		block.transform.position = new Vector3 (pos.y, pos.x, 0.0f);
	}

	// ブロックの色を設定する関数
	public void SetColor(Material color){
		Renderer renderer = block.GetComponent<Renderer>();
		renderer.material = new Material (color);
	}

	// ブロックの色を取得する関数
	public Material GetColor(){
		Renderer renderer = block.GetComponent<Renderer>();
		return 	renderer.material;
	}
}

public class Game : MonoBehaviour {
	public static readonly int Width = 10;		// 幅
	public static readonly int Height = 20;		// 高さ

	public static readonly int[,,] O_Tetrimino = new int [,,]{{{0,0,0,0,0},
																{0,0,0,0,0},						
																{0,1,1,0,0},
																{0,1,1,0,0},
																{0,0,0,0,0}},
																
																{{0,0,0,0,0},
																{0,1,1,0,0},
																{0,1,1,0,0},
																{0,0,0,0,0},
																{0,0,0,0,0}},
															
																{{0,0,0,0,0},
																{0,0,1,1,0},
																{0,0,1,1,0},
																{0,0,0,0,0},
																{0,0,0,0,0}},
															
																{{0,0,0,0,0},
																{0,0,0,0,0},
																{0,0,1,1,0},
																{0,0,1,1,0},
																{0,0,0,0,0}}};

	public static readonly int[,,] I_Tetrimino = new int [,,]{{{0,0,1,0,0},
																{0,0,1,0,0},
																{0,0,1,0,0},
																{0,0,1,0,0},
																{0,0,0,0,0}},

																{{0,0,0,0,0},
																{0,0,0,0,0},
																{0,1,1,1,1},
																{0,0,0,0,0},
																{0,0,0,0,0}},

																{{0,0,0,0,0},
																{0,0,1,0,0},
																{0,0,1,0,0},
																{0,0,1,0,0},
																{0,0,1,0,0}},

																{{0,0,0,0,0},
																{0,0,0,0,0},
																{1,1,1,1,0},
																{0,0,0,0,0},
																{0,0,0,0,0}}};
	
	public static readonly int[,,] S_Tetrimino = new int [,,]{{{0,0,0,0,0},
																{0,0,0,0,0},
																{0,0,1,1,0},
																{0,1,1,0,0},
																{0,0,0,0,0}},
		
																{{0,0,0,0,0},
																{0,1,0,0,0},
																{0,1,1,0,0},
																{0,0,1,0,0},
																{0,0,0,0,0}},
																
																{{0,0,0,0,0},
																{0,0,1,1,0},
																{0,1,1,0,0},
																{0,0,0,0,0},
																{0,0,0,0,0}},
																
																{{0,0,0,0,0},
																{0,0,1,0,0},
																{0,0,1,1,0},
																{0,0,0,1,0},
																{0,0,0,0,0}}};
	
	public static readonly int[,,] Z_Tetrimino = new int [,,]{{{0,0,0,0,0},
																{0,0,0,0,0},
																{0,1,1,0,0},
																{0,0,1,1,0},
																{0,0,0,0,0}},
		
																{{0,0,0,0,0},
																{0,0,1,0,0},
																{0,1,1,0,0},
																{0,1,0,0,0},
																{0,0,0,0,0}},
																
																{{0,0,0,0,0},
																{0,1,1,0,0},
																{0,0,1,1,0},
																{0,0,0,0,0},
																{0,0,0,0,0}},
															
																{{0,0,0,0,0},
																{0,0,0,1,0},
																{0,0,1,1,0},
																{0,0,1,0,0},
																{0,0,0,0,0}}};

	public static readonly int[,,] J_Tetrimino = new int [,,]{{{0,0,0,0,0},
																{0,0,1,0,0},
																{0,0,1,0,0},
																{0,1,1,0,0},
																{0,0,0,0,0}},
		
																{{0,0,0,0,0},
																{0,1,0,0,0},
																{0,1,1,1,0},
																{0,0,0,0,0},
																{0,0,0,0,0}},
		
																{{0,0,0,0,0},
																{0,0,1,1,0},
																{0,0,1,0,0},
																{0,0,1,0,0},
																{0,0,0,0,0}},
															
																{{0,0,0,0,0},
																{0,0,0,0,0},
																{0,1,1,1,0},
																{0,0,0,1,0},
																{0,0,0,0,0}}};
	
	public static readonly int[,,] L_Tetrimino = new int [,,]{{{0,0,0,0,0},
																{0,0,1,0,0},
																{0,0,1,0,0},
																{0,0,1,1,0},
																{0,0,0,0,0}},
																
																{{0,0,0,0,0},
																{0,0,0,0,0},
																{0,1,1,1,0},
																{0,1,0,0,0},
																{0,0,0,0,0}},
																
																{{0,0,0,0,0},
																{0,1,1,0,0},
																{0,0,1,0,0},
																{0,0,1,0,0},
																{0,0,0,0,0}},
															
																{{0,0,0,0,0},
																{0,0,0,1,0},
																{0,1,1,1,0},
																{0,0,0,0,0},
																{0,0,0,0,0}}};
															
	public static readonly int[,,] T_Tetrimino = new int [,,]{{{0,0,0,0,0},
																{0,0,0,0,0},
																{0,1,1,1,0},
																{0,0,1,0,0},
																{0,0,0,0,0}},
															
																{{0,0,0,0,0},
																{0,0,1,0,0},
																{0,1,1,0,0},
																{0,0,1,0,0},
																{0,0,0,0,0}},
																
																{{0,0,0,0,0},
																{0,0,1,0,0},
																{0,1,1,1,0},
																{0,0,0,0,0},
																{0,0,0,0,0}},
																
																{{0,0,0,0,0},
																{0,0,1,0,0},
																{0,0,1,1,0},
																{0,0,1,0,0},
																{0,0,0,0,0}}};
	private eStatus m_Status;

	// マテリアル
	private Material red;
	private Material blue;
	private Material lightBlue;
	private Material yello;
	private Material yelloGreen;
	private Material purple;
	private Material orange;
	private Material black;
	private Material white;

	cBlock[,] block=new cBlock[Height,Width];
	eBlockState[,] m_blockState = new eBlockState[Height, Width];

	eTetriminoType myTetriminoType;
	Vector2 myPos;
	int myTetriminoState=0;

	cBlock[,] nextTetrimino = new cBlock[5,5];
	eTetriminoType nextTetrimonoType;
	int m_shiftNum=0;

	public float timer = 0.0f;
	float downLAndRKeyTime = 0.0f;
	float downFallKeyTime = 0.0f;
	float m_slideTime = 0.0f;

	// Use this for initialization
	void Start () {
	// マテリアルの取得
	red = Resources.Load ("Material/red")as Material;
	blue = Resources.Load ("Material/blue")as Material;
	lightBlue = Resources.Load ("Material/lightBlue")as Material;
	yello = Resources.Load ("Material/yello")as Material;
	yelloGreen = Resources.Load ("Material/yelloGreen")as Material;
	purple = Resources.Load ("Material/purple")as Material;
	orange = Resources.Load ("Material/orange")as Material;
	black = Resources.Load ("Material/black")as Material;
	white = Resources.Load ("Material/white")as Material;

		for (int i=0; i<Height; i++) {
			for(int j=0;j<Width;j++){
				// クラスのインスタンスを初期化する
				block[i,j] = new cBlock();

				// 20*10ブロックの作成
				Vector2 pos = new Vector2((Height/2)-i,-(Width/2)+j);
				block[i,j].CreateBlock();
				block[i,j].SetPosition(pos);
				// ブロックの状態
				m_blockState[i,j] = eBlockState.Empty;
				block[i,j].SetColor(black);
			}
		}

		// 5*5ブロックの作成
		for (int i=0; i<5; i++) {
			for (int j=0; j<5; j++) {
				// クラスのインスタンスを初期化する
				nextTetrimino[i,j] = new cBlock();

				nextTetrimino[i,j].CreateBlock();
			}
		}
		nextTetrimonoType = SetTetriminoType();
		myTetriminoType = nextTetrimonoType;
		DrawNextTetrimino();
		myPos = new Vector2 (0.0f,0.0f);

		m_Status = eStatus.Tutorial;
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
				case eTetriminoType.OTetrimino:
					if(O_Tetrimino[myTetriminoState,i,j]==1){
						nextTetrimino[i,j].SetColor(yello);
					}
					break;
				case eTetriminoType.ITetrimino:
					if(I_Tetrimino[myTetriminoState,i,j]==1){
						nextTetrimino[i,j].SetColor(lightBlue);
					}
					break;
				case eTetriminoType.STetrimino:
					if(S_Tetrimino[myTetriminoState,i,j]==1){
						nextTetrimino[i,j].SetColor(yelloGreen);
					}
					break;
				case eTetriminoType.ZTetrimino:
					if(Z_Tetrimino[myTetriminoState,i,j]==1){
						nextTetrimino[i,j].SetColor(red);
					}
					break;
				case eTetriminoType.JTetrimino:
					if(J_Tetrimino[myTetriminoState,i,j]==1){
						nextTetrimino[i,j].SetColor(blue);
					}
					break;
				case eTetriminoType.LTetrimino:
					if(L_Tetrimino[myTetriminoState,i,j]==1){
						nextTetrimino[i,j].SetColor(orange);
					}
					break;
				case eTetriminoType.TTetrimino:
					if(T_Tetrimino[myTetriminoState,i,j]==1){
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
		case eStatus.Tutorial:
			UpdateTutorial ();
			break;
		case eStatus.Play:
			UpdatePlay ();
			break;
		case eStatus.Gameover:
			UpdateGameover ();
			break;
		}
	}

	// シーンを代える
	void Transit(eStatus NextStatus){
		switch (NextStatus) {
		case eStatus.Tutorial:
			m_Status = NextStatus;
			StartTutorial(m_Status);
			break;
		case eStatus.Play:
			m_Status = NextStatus;
			StartPlay(m_Status);
			break;
		case eStatus.Gameover:
			m_Status = NextStatus;
			StartGameover(m_Status);
			break;
		}
	}
	
	void StartTutorial(eStatus PrevStatus){
		// 代わった時に1回しかやらないことをする
		Debug.Log ("Tutorial");
	}

	// 操作ブロックの使用中だったところを空にする
	void ClearState(){
		for (int i=4; i>=0; i--) {
			for (int j=0; j<5; j++) {
				if((int)myPos.y+i < Height && (int)myPos.y+i >= 0 && 
				   (int)myPos.x+j < Width && (int)myPos.x+j >= 0 && 
				   m_blockState[(int)myPos.y+i,(int)myPos.x+j]==eBlockState.Using)
					m_blockState[(int)myPos.y+i,(int)myPos.x+j]=eBlockState.Empty;
			}
		}
	}

	// ステータスが空の場所を黒にする
	void DrawBlack(){
		for (int i=0; i<Height; i++) {
			for (int j=0; j<Width; j++) {
				if(m_blockState[i,j]==eBlockState.Empty)
					block[i,j].SetColor(black);
			}
		}
	}

	// 移動先が移動可能か判定する関数
	bool CheckHit(Vector2 movedPos){
		for (int i=4; i>=0; i--) {
			for(int j=0;j<5;j++){
				switch(myTetriminoType){
				case eTetriminoType.OTetrimino:
					if(O_Tetrimino[myTetriminoState,i,j]==1 && (int)movedPos.y+i >= 0 && (int)movedPos.x+j >= 0 && (int)movedPos.x+j < Width &&
					   (((int)movedPos.y+i >= Height) || m_blockState[(int)movedPos.y+i,(int)movedPos.x+j]==eBlockState.Used)){
							return true;
					}
					break;
				case eTetriminoType.ITetrimino:
					if(I_Tetrimino[myTetriminoState,i,j]==1 && (int)movedPos.y+i >= 0 && (int)movedPos.x+j >= 0 && (int)movedPos.x+j < Width && 
					   (((int)movedPos.y+i >= Height) || m_blockState[(int)movedPos.y+i,(int)movedPos.x+j]==eBlockState.Used)){
						return true;
					}
					break;
				case eTetriminoType.STetrimino:
					if(S_Tetrimino[myTetriminoState,i,j]==1 && (int)movedPos.y+i >= 0 && (int)movedPos.x+j >= 0 && (int)movedPos.x+j < Width &&
					   (((int)movedPos.y+i >= Height) || m_blockState[(int)movedPos.y+i,(int)movedPos.x+j]==eBlockState.Used)){
						return true;
					}
					break;
				case eTetriminoType.ZTetrimino:
					if(Z_Tetrimino[myTetriminoState,i,j]==1 && (int)movedPos.y+i >= 0 && (int)movedPos.x+j >= 0 && (int)movedPos.x+j < Width &&
					   (((int)movedPos.y+i >= Height) || m_blockState[(int)movedPos.y+i,(int)movedPos.x+j]==eBlockState.Used)){
						return true;
					}
					break;
				case eTetriminoType.JTetrimino:
					if(J_Tetrimino[myTetriminoState,i,j]==1 && (int)movedPos.y+i >= 0 && (int)movedPos.x+j >= 0 && (int)movedPos.x+j < Width &&
					   (((int)movedPos.y+i >= Height) || m_blockState[(int)movedPos.y+i,(int)movedPos.x+j]==eBlockState.Used)){
						return true;
					}
					break;
				case eTetriminoType.LTetrimino:
					if(L_Tetrimino[myTetriminoState,i,j]==1 && (int)movedPos.y+i >= 0 && (int)movedPos.x+j >= 0 && (int)movedPos.x+j < Width && 
					   (((int)movedPos.y+i >= Height) || m_blockState[(int)movedPos.y+i,(int)movedPos.x+j]==eBlockState.Used)){
						return true;
					}
					break;
				case eTetriminoType.TTetrimino:
					if(T_Tetrimino[myTetriminoState,i,j]==1 && (int)movedPos.y+i >= 0 && (int)movedPos.x+j >= 0 && (int)movedPos.x+j < Width && 
					   (((int)movedPos.y+i >= Height) || m_blockState[(int)movedPos.y+i,(int)movedPos.x+j]==eBlockState.Used)){
						return true;
					}
					break;
				}
			}
		}
		return false;
	}

	// 移動先でブロックが左右の枠からはみ出さないかチェックする関数
	bool CheckOverBlock(Vector2 movedPos){
		for (int i=4; i>=0; i--) {
			for(int j=0;j<5;j++){
				switch(myTetriminoType){
				case eTetriminoType.OTetrimino:
					if(O_Tetrimino[myTetriminoState,i,j]==1 && 
					   (((int)movedPos.x+j >= Width) || ((int)movedPos.x+j < 0))){
						return true;
					}
					break;
				case eTetriminoType.ITetrimino:
					if(I_Tetrimino[myTetriminoState,i,j]==1 && 
					   (((int)movedPos.x+j >= Width) || ((int)movedPos.x+j < 0))){
						return true;
					}
					break;
				case eTetriminoType.STetrimino:
					if(S_Tetrimino[myTetriminoState,i,j]==1 && 
					   (((int)movedPos.x+j >= Width) || ((int)movedPos.x+j < 0))){
						return true;
					}
					break;
				case eTetriminoType.ZTetrimino:
					if(Z_Tetrimino[myTetriminoState,i,j]==1 && 
					   (((int)movedPos.x+j >= Width) || ((int)movedPos.x+j < 0))){
						return true;
					}
					break;
				case eTetriminoType.JTetrimino:
					if(J_Tetrimino[myTetriminoState,i,j]==1 && 
					   (((int)movedPos.x+j >= Width) || ((int)movedPos.x+j < 0))){
						return true;
					}
					break;
				case eTetriminoType.LTetrimino:
					if(L_Tetrimino[myTetriminoState,i,j]==1 && 
					   (((int)movedPos.x+j >= Width) || ((int)movedPos.x+j < 0))){
						return true;
					}
					break;
				case eTetriminoType.TTetrimino:
					if(T_Tetrimino[myTetriminoState,i,j]==1 && 
					   (((int)movedPos.x+j >= Width) || ((int)movedPos.x+j < 0))){
						return true;
					}
					break;
				}
			}
		}
		return false;
	}

	// Gameoverか判定する関数
	bool CheckGameover(Vector2 movedPos){
		for (int i=4; i>=0; i--) {
			for(int j=0;j<5;j++){
				switch(myTetriminoType){
				case eTetriminoType.OTetrimino:
					if(O_Tetrimino[myTetriminoState,i,j]==1 && (int)movedPos.y+i < 0){
						return true;
					}
					break;
				case eTetriminoType.ITetrimino:
					if(I_Tetrimino[myTetriminoState,i,j]==1 && (int)movedPos.y+i < 0){
						return true;
					}
					break;
				case eTetriminoType.STetrimino:
					if(S_Tetrimino[myTetriminoState,i,j]==1 && (int)movedPos.y+i < 0){
						return true;
					}
					break;
				case eTetriminoType.ZTetrimino:
					if(Z_Tetrimino[myTetriminoState,i,j]==1 && (int)movedPos.y+i < 0){
						return true;
					}
					break;
				case eTetriminoType.JTetrimino:
					if(J_Tetrimino[myTetriminoState,i,j]==1 && (int)movedPos.y+i < 0){
						return true;
					}
					break;
				case eTetriminoType.LTetrimino:
					if(L_Tetrimino[myTetriminoState,i,j]==1 && (int)movedPos.y+i < 0){
						return true;
					}
					break;
				case eTetriminoType.TTetrimino:
					if(T_Tetrimino[myTetriminoState,i,j]==1 && (int)movedPos.y+i < 0){
						return true;
					}
					break;
				}
			}
		}
		return false;
	}

	// 使用中のブロックの位置を設定する
	void SetBlock(){
		for (int i=4; i>=0; i--) {
			for(int j=0;j<5;j++){
				switch(myTetriminoType){
					case eTetriminoType.OTetrimino:
					if(O_Tetrimino[myTetriminoState,i,j]==1 && (int)myPos.y+i >= 0 &&
					   ((int)myPos.x+j >= 0 && (int)myPos.x+j < Width)){
						block[(int)myPos.y+i,(int)myPos.x+j].SetColor(yello);
						m_blockState[(int)myPos.y+i,(int)myPos.x+j]=eBlockState.Using;
					}
						break;
					case eTetriminoType.ITetrimino:
					if(I_Tetrimino[myTetriminoState,i,j]==1 && (int)myPos.y+i >= 0 &&
					   ((int)myPos.x+j >= 0 && (int)myPos.x+j < Width)){
						block[(int)myPos.y+i,(int)myPos.x+j].SetColor(lightBlue);
						m_blockState[(int)myPos.y+i,(int)myPos.x+j]=eBlockState.Using;
					}
						break;
					case eTetriminoType.STetrimino:
					if(S_Tetrimino[myTetriminoState,i,j]==1 && (int)myPos.y+i >= 0 &&
					   ((int)myPos.x+j >= 0 && (int)myPos.x+j < Width)){
						block[(int)myPos.y+i,(int)myPos.x+j].SetColor(yelloGreen);
						m_blockState[(int)myPos.y+i,(int)myPos.x+j]=eBlockState.Using;
					}
						break;
					case eTetriminoType.ZTetrimino:
					if(Z_Tetrimino[myTetriminoState,i,j]==1 && (int)myPos.y+i >= 0 &&
					   ((int)myPos.x+j >= 0 && (int)myPos.x+j < Width)){
						block[(int)myPos.y+i,(int)myPos.x+j].SetColor(red);
						m_blockState[(int)myPos.y+i,(int)myPos.x+j]=eBlockState.Using;
					}
						break;
					case eTetriminoType.JTetrimino:
					if(J_Tetrimino[myTetriminoState,i,j]==1 && (int)myPos.y+i >= 0 &&
					   ((int)myPos.x+j >= 0 && (int)myPos.x+j < Width)){
						block[(int)myPos.y+i,(int)myPos.x+j].SetColor(blue);
						m_blockState[(int)myPos.y+i,(int)myPos.x+j]=eBlockState.Using;
					}
						break;
					case eTetriminoType.LTetrimino:
					if(L_Tetrimino[myTetriminoState,i,j]==1 && (int)myPos.y+i >= 0 &&
					   ((int)myPos.x+j >= 0 && (int)myPos.x+j < Width)){
						block[(int)myPos.y+i,(int)myPos.x+j].SetColor(orange);
						m_blockState[(int)myPos.y+i,(int)myPos.x+j]=eBlockState.Using;
					}
						break;
					case eTetriminoType.TTetrimino:
					if(T_Tetrimino[myTetriminoState,i,j]==1 && (int)myPos.y+i >= 0 &&
					   ((int)myPos.x+j >= 0 && (int)myPos.x+j < Width)){
						block[(int)myPos.y+i,(int)myPos.x+j].SetColor(purple);
						m_blockState[(int)myPos.y+i,(int)myPos.x+j]=eBlockState.Using;
					}
						break;
					}
			}
		}
		DrawBlack();
	}

	// ブロックの移動
	void MoveBlock (eKeyCode keyCode = eKeyCode.None) {
		int moveX = 0;
		int moveY = 0;
		switch (keyCode) {
		// 左が押された場合
		case eKeyCode.LeftArrow:
			moveX = -1;
			break;
		// 右が押された場合
		case eKeyCode.RightArrow:
			moveX = 1;
			break;
		// 落下
		case eKeyCode.DownArrow:
			moveY = 1;
			break;
		default:
			break;
		}

		// 移動先に移動できるか調べる
		if (!CheckOverBlock (new Vector2 (myPos.x + moveX, myPos.y + moveY)) &&
			!CheckHit (new Vector2 (myPos.x + moveX, myPos.y + moveY))) {
			ClearState ();
			myPos.x+=moveX;
			myPos.y+=moveY;
			SetBlock();
		}
	}

	bool RotateCheck(Vector2 movedPos){
		for (int i=4; i>=0; i--) {
			for(int j=0;j<5;j++){
				switch(myTetriminoType){
				case eTetriminoType.OTetrimino:
					if(O_Tetrimino[myTetriminoState,i,j]==1){
						if((int)movedPos.x+j >= Width){
							m_shiftNum=((int)movedPos.x+j)-(Width-1);
							return true;
						}
						else if((int)movedPos.x+j < 0){
							m_shiftNum=(int)movedPos.x+j;
							return true;
						}
					}
					break;
				case eTetriminoType.ITetrimino:
					if(I_Tetrimino[myTetriminoState,i,j]==1){
						if((int)movedPos.x+j >= Width){
							if(myTetriminoState!=1)
								m_shiftNum=((int)movedPos.x+j)-(Width-1);
							else
								m_shiftNum=((int)movedPos.x+j)-(Width-1)+1;

							return true;
						}
						else if((int)movedPos.x+j < 0){
							m_shiftNum=(int)movedPos.x+j;
							return true;
						}
					}
					break;
				case eTetriminoType.STetrimino:
					if(S_Tetrimino[myTetriminoState,i,j]==1){
						if((int)movedPos.x+j >= Width){
							m_shiftNum=((int)movedPos.x+j)-(Width-1);
							return true;
						}
						else if((int)movedPos.x+j < 0){
							m_shiftNum=(int)movedPos.x+j;
							return true;
						}
					}
					break;
				case eTetriminoType.ZTetrimino:
					if(Z_Tetrimino[myTetriminoState,i,j]==1){
						if((int)movedPos.x+j >= Width){
							m_shiftNum=((int)movedPos.x+j)-(Width-1);
							return true;
						}
						else if((int)movedPos.x+j < 0){
							m_shiftNum=(int)movedPos.x+j;
							return true;
						}
					}
					break;
				case eTetriminoType.JTetrimino:
					if(J_Tetrimino[myTetriminoState,i,j]==1){
						if((int)movedPos.x+j >= Width){
							m_shiftNum=((int)movedPos.x+j)-(Width-1);
							return true;
						}
						else if((int)movedPos.x+j < 0){
							m_shiftNum=(int)movedPos.x+j;
							return true;
						}
					}
					break;
				case eTetriminoType.LTetrimino:
					if(L_Tetrimino[myTetriminoState,i,j]==1){
						if((int)movedPos.x+j >= Width){
							m_shiftNum=((int)movedPos.x+j)-(Width-1);
							return true;
						}
						else if((int)movedPos.x+j < 0){
							m_shiftNum=(int)movedPos.x+j;
							return true;
						}
					}
					break;
				case eTetriminoType.TTetrimino:
					if(T_Tetrimino[myTetriminoState,i,j]==1){
						if((int)movedPos.x+j >= Width){
							m_shiftNum=((int)movedPos.x+j)-(Width-1);
							return true;
						}
						else if((int)movedPos.x+j < 0){
							m_shiftNum=(int)movedPos.x+j;
							return true;
						}
					}
					break;
				}
			}
		}
		m_shiftNum = 0;
		return false;
	}

	// 回転時ブロック同士が衝突する時どれだけずらすか設定する関数
	void SetShiftNum(){
		switch(myTetriminoType){
		case eTetriminoType.ITetrimino:
			if(myTetriminoState==1 || myTetriminoState==3)
				m_shiftNum=2;
			else
				m_shiftNum=1;
			break;
		default:
			m_shiftNum=1;
			break;
		}
	}

	// 回転処理を行う関数
	void RotateBlock(eKeyCode keyCode = eKeyCode.None){
		int moveStateNum = 0;
		switch (keyCode) {
			// Zが押された場合（左回転）
		case eKeyCode.ZKeyCode:
			moveStateNum = -1;

			if (moveStateNum + myTetriminoState < 0) {
				moveStateNum=3;
			}
			else{
				moveStateNum = myTetriminoState + moveStateNum;
			}
			break;
			// Xが押された場合（右回転）
		case eKeyCode.XKeyCode:
			moveStateNum = 1;

			if(moveStateNum + myTetriminoState > 3){
				moveStateNum=0;
			}
			else{
				moveStateNum = myTetriminoState + moveStateNum;
			}
			break;
		default:
			break;
		}

		int frontStateNum = myTetriminoState;
		myTetriminoState = moveStateNum;
		// 回転後ブロックにぶつからないか調べる
		if (!CheckHit (myPos)) {
			RotateCheck (myPos);

			if (m_shiftNum == 0 || !CheckHit (new Vector2 (myPos.x - m_shiftNum, myPos.y))){
				myPos.x -= m_shiftNum;
				ClearState ();
				SetBlock ();
			}
			// 回転不可能
			else{
				myTetriminoState = frontStateNum;
			}
		}
		else {
			// 回転すると当たってしまうが、ずらした場合に回転できるか調べる
			SetShiftNum();
			if(!CheckHit (new Vector2(myPos.x-m_shiftNum,myPos.y))){
				myPos.x -= m_shiftNum;
				ClearState ();
				SetBlock ();
			}
			else if(!CheckHit (new Vector2(myPos.x+m_shiftNum,myPos.y))){
				myPos.x += m_shiftNum;
				ClearState ();
				SetBlock ();
			}
			// 回転不可能
			else{
				myTetriminoState = frontStateNum;
				m_shiftNum=0;
			}
		}
	}

	// 一列そろっているか調べる関数
	bool CheckDeleteLine(int nowPositionY){
		for (int i=0; i<Width; i++) {
			if(nowPositionY >= 0 && m_blockState[nowPositionY,i]!=eBlockState.Used){
				return false;
			}
		}
		return true;
	}

	// そろっているブロックを消す関数
	void DeleteBlock(int nowPositionY){

		int lineCount = 0;
		ArrayList deleteList = new ArrayList ();
		Material[,] deleteAfterMaterial = new Material[4, Width];
		eBlockState[,] deleteAfterState = new eBlockState[4, Width];
		// 初期化
		for(int i=0;i<4;i++){
			for(int j=0;j<Width;j++){
				deleteAfterState[i,j]=eBlockState.Empty;
				deleteAfterMaterial[i,j] = black;
			}
		}

		for (int i=0; i<4; i++) {
			if(!CheckDeleteLine(nowPositionY-i)){
				for(int j=0;j<Width;j++){
					deleteAfterState[3-lineCount,j] = m_blockState[nowPositionY-i,j];
					deleteAfterMaterial[3-lineCount,j] = block[nowPositionY-i,j].GetColor();
				}
				lineCount+=1;
			}
			else{
				deleteList.Add(nowPositionY-i);
			}
		}
		if(lineCount!=0)
			lineCount = 4 - lineCount;

		// そろっているブロックがある場合　消して必要な分だけ下にずらす
		if (lineCount != 0) {
			//Flash(nowPositionY,deleteList);
			Debug.Log(lineCount);
			// 少し待つ
			System.Threading.Thread.Sleep(1000);
			//if(!m_flash){
			bool downFlag=true;
			for (int i=0; i<4; i++) {
				if((nowPositionY-i) >= 0){
					for (int j=0; j<Width; j++) {
						m_blockState[(nowPositionY-i),j]=deleteAfterState[3-i,j];
						block[(nowPositionY-i),j].SetColor(deleteAfterMaterial[3-i,j]);
					}
				}
				else{
					downFlag = false;
				}
			}

			for(int i=nowPositionY-(4-lineCount);i>lineCount;i--){
				if(i>=0){
					for (int j=0; j<Width; j++) {
						m_blockState[i,j]=m_blockState[i-1,j];
						block[i,j].SetColor(block[i-1,j].GetColor());
					}
				}
				else{
					downFlag=false;
				}
			}

			if(downFlag){
				for(int i=lineCount;i>=0;i--){
					for (int j=0; j<Width; j++) {
						m_blockState[i,j]=eBlockState.Empty;
						block[i,j].SetColor(black);
					}
				}
			}
		}
	}

	// ゴーストブロック更新時先に真っ黒にしておく関数
	void BlackDrawGhost(){
		for (int i=0; i<Height; i++) {
			for (int j=0; j<Width; j++) {
				if (m_blockState [i, j] == eBlockState.Ghost)
					block [i, j].SetColor (black);
			}
		}
	}

	// ゴーストブロックを描画する関数
	void DrawGhost(){
		int num = 1;
		while(!CheckHit (new Vector2(myPos.x,myPos.y+num))){
			num+=1;
		}

		num += 3;

		BlackDrawGhost ();
		for (int i=0; i<5; i++) {
			for(int j=0;j<5;j++){
				switch(myTetriminoType){
				case eTetriminoType.OTetrimino:
					if(O_Tetrimino[myTetriminoState,4-i,j]==1 && ((int)myPos.y+num)-i >= 0 && ((int)myPos.y+num)-i < Height){
						m_blockState[((int)myPos.y+num)-i,(int)myPos.x+j] = eBlockState.Ghost;
						block[((int)myPos.y+num)-i,(int)myPos.x+j].SetColor(white);
					}
					break;
				case eTetriminoType.ITetrimino:
					if(I_Tetrimino[myTetriminoState,4-i,j]==1 && ((int)myPos.y+num)-i >= 0 && ((int)myPos.y+num)-i < Height){
						m_blockState[((int)myPos.y+num)-i,(int)myPos.x+j] = eBlockState.Ghost;
						block[((int)myPos.y+num)-i,(int)myPos.x+j].SetColor(white);
					}
					break;
				case eTetriminoType.STetrimino:
					if(S_Tetrimino[myTetriminoState,4-i,j]==1 && ((int)myPos.y+num)-i >= 0 && ((int)myPos.y+num)-i < Height){
						m_blockState[((int)myPos.y+num)-i,(int)myPos.x+j] = eBlockState.Ghost;
						block[((int)myPos.y+num)-i,(int)myPos.x+j].SetColor(white);
					}
					break;
				case eTetriminoType.ZTetrimino:
					if(Z_Tetrimino[myTetriminoState,4-i,j]==1 && ((int)myPos.y+num)-i >= 0 && ((int)myPos.y+num)-i < Height){
						m_blockState[((int)myPos.y+num)-i,(int)myPos.x+j] = eBlockState.Ghost;
						block[((int)myPos.y+num)-i,(int)myPos.x+j].SetColor(white);
					}
					break;
				case eTetriminoType.JTetrimino:
					if(J_Tetrimino[myTetriminoState,4-i,j]==1 && ((int)myPos.y+num)-i >= 0 && ((int)myPos.y+num)-i < Height){
						m_blockState[((int)myPos.y+num)-i,(int)myPos.x+j] = eBlockState.Ghost;
						block[((int)myPos.y+num)-i,(int)myPos.x+j].SetColor(white);
					}
					break;
				case eTetriminoType.LTetrimino:
					if(L_Tetrimino[myTetriminoState,4-i,j]==1 && ((int)myPos.y+num)-i >= 0 && ((int)myPos.y+num)-i < Height){
						m_blockState[((int)myPos.y+num)-i,(int)myPos.x+j] = eBlockState.Ghost;
						block[((int)myPos.y+num)-i,(int)myPos.x+j].SetColor(white);
					}
					break;
				case eTetriminoType.TTetrimino:
					if(T_Tetrimino[myTetriminoState,4-i,j]==1 && ((int)myPos.y+num)-i >= 0 && ((int)myPos.y+num)-i < Height){
						m_blockState[((int)myPos.y+num)-i,(int)myPos.x+j] = eBlockState.Ghost;
						block[((int)myPos.y+num)-i,(int)myPos.x+j].SetColor(white);
					}
					break;
				}
			}
		}

		SetBlock();
	}

	void StartPlay(eStatus PrevStatus){
		// 代わった時に1回しかやらないことをする
		Debug.Log ("Play");

		// 自分の初期位置（仮）
		myPos = new Vector2 (3,-4);
		SetBlock();
	}

	void StartGameover(eStatus PrevStatus){
		// 代わった時に1回しかやらないことをする
		Debug.Log ("Gameover");
	}

	// tutorial状態の更新関数
	void UpdateTutorial(){
		// enterキーでゲームに遷移する（仮）
		if (Input.GetKeyDown (KeyCode.Return)) {
			Transit (eStatus.Play);
		}
	}

	// play状態の更新関数
	void UpdatePlay(){
		// 時間の取得
		timer += Time.deltaTime;

		// 自然落下処理
		if (!Input.GetKey (KeyCode.DownArrow) &&
		    (timer > 1.0f && !CheckHit (new Vector2 (myPos.x, myPos.y + 1)))) {
			timer=0.0f;
			ClearState ();
			myPos.y+=1;
			SetBlock();
		}

		// 一番下についた時またはブロックが下にあった場合の積む処理
		if (CheckHit (new Vector2 (myPos.x, myPos.y + 1))) {
			timer = 0.0f;
			m_slideTime += Time.deltaTime;

			// ゲームオーバーになるか確認する
			if (CheckGameover (new Vector2 (myPos.x, myPos.y))) {
				// もう積めない場合ゲームオーバーに遷移する
				Transit (eStatus.Gameover);
			} else {
				// ブロックのすべり時間処理
				if (m_slideTime > 0.5f) {
					int nowPosition = 0;
					// ブロックの位置を決定する
					for (int i=4; i>=0; i--) {
						for (int j=0; j<5; j++) {
							if ((int)myPos.y + i < Height && (int)myPos.y + i >= 0 &&
								(int)myPos.x + j < Width && (int)myPos.x + j >= 0 &&
								m_blockState [(int)myPos.y + i, (int)myPos.x + j] == eBlockState.Using) {
								if ((int)myPos.y + i > nowPosition) {
									nowPosition = (int)myPos.y + i;
								}
								m_blockState [(int)myPos.y + i, (int)myPos.x + j] = eBlockState.Used;
							}
						}
					}

					DeleteBlock (nowPosition);

					// 次のブロックの準備を行う
					myTetriminoState = 0;
					myTetriminoType = nextTetrimonoType;
					DrawNextTetrimino ();
					// 初期位置に戻す
					myPos = new Vector2 (3, -4);
					m_slideTime = 0.0f;
				}
			}
		}
		DrawGhost();

		// RightArrowキーで右へ移動
		if (Input.GetKey (KeyCode.RightArrow) && !Input.GetKey (KeyCode.LeftArrow)) {
			downLAndRKeyTime += Time.deltaTime;

			if(downLAndRKeyTime >= 0.1f){
				MoveBlock(eKeyCode.RightArrow);
				downLAndRKeyTime = 0.0f;
			}
		}

		// LeftArrowキーで左へ移動
		if (Input.GetKey (KeyCode.LeftArrow) && !Input.GetKey (KeyCode.RightArrow)) {
			downLAndRKeyTime += Time.deltaTime;
			
			if(downLAndRKeyTime >= 0.1f){
				MoveBlock(eKeyCode.LeftArrow);
				downLAndRKeyTime = 0.0f;
			}
		}

		// DownArroeキーで下へ移動
		if (Input.GetKey (KeyCode.DownArrow)) {
			downFallKeyTime += Time.deltaTime;
			
			if(downFallKeyTime >= 0.1f){
				MoveBlock(eKeyCode.DownArrow);
				downFallKeyTime = 0.0f;
			}
		}

		// Xキーで右回転を行う
		if (Input.GetKeyDown (KeyCode.X)) {
			RotateBlock(eKeyCode.XKeyCode);
		}

		// Zキーで左回転を行う
		if (Input.GetKeyDown (KeyCode.Z)) {
			RotateBlock(eKeyCode.ZKeyCode);
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
