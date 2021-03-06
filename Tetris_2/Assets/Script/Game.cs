using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// ステータス.
public enum eStatus{
	Tutorial,
	Play,
	Gameover,
};

// テトリミノの種類.
public enum eTetriminoType{
	OTetrimino,
	ITetrimino,
	STetrimino,
	ZTetrimino,
	JTetrimino,
	LTetrimino,
	TTetrimino,
};

// 使用するキー.
enum eKeyCode{
	RightArrow,
	LeftArrow,
	DownArrow,
	ZKeyCode,
	XKeyCode,
	None,
};

// ブロックの状態.
enum eBlockState{
	Empty,
	Used,
	Ghost,
	Using,
};

class cMyTetrimino{
	protected eTetriminoType m_myTetriminoType;
	protected Vector2 m_myPosition;
	protected int[,] m_myTetrimino = new int[5,5];

	public cMyTetrimino(){
		m_myPosition = new Vector2 (0.0f,0.0f);
	}

	public void SetType(eTetriminoType tetriminoType){
		m_myTetriminoType = tetriminoType;
	}

	public eTetriminoType GetType(){
		return m_myTetriminoType;
	}

	public void SetPosition(Vector2 position){
		m_myPosition = position;
	}

	public Vector2 GetPosition(){
		return m_myPosition;
	}

	public int[,] GetTetrimino(){
		return m_myTetrimino;
	}
}

public class Game : MonoBehaviour {
	public static readonly int Width = 10;		// 幅.
	public static readonly int Height = 20;		// 高さ.
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
	
	// マテリアル.
	private Material m_red;
	private Material m_blue;
	private Material m_lightBlue;
	private Material m_yello;
	private Material m_yelloGreen;
	private Material m_purple;
	private Material m_orange;
	private Material m_black;
	private Material m_white;
	private Material m_ghost;
	
	// 全体のゲームブロック.
	private GameObject[,] m_block=new GameObject[Height,Width];
	private eBlockState[,] m_blockState = new eBlockState[Height, Width];
	
	// 次のブロック.
	private GameObject[,] m_nextBlock = new GameObject[5,5];
	private int[,] m_nextTetrimino = new int[5,5];
	private eTetriminoType m_nextTetrimonoType;
	
	// 操作ブロック.
	private int m_myTetriminoState=0;
	private int m_shiftNum=0;
	private int m_myExistUnderPositionY=0;
	private cMyTetrimino m_myTetrimino = new cMyTetrimino();
	
	private bool m_deleteFlag = false;
	private bool deleteEndFlag = true;
	private int m_deleteLineNumber=0;
	
	private Text m_scoreText;
	private Text m_levelText;
	private Text m_menuText;
	private Text m_tutorialText;
	private int m_score = 0;
	private int m_downPoint=0;
	private int m_level=0;
	
	private float m_timer = 0.0f;
	private float m_fallSpeed = 1.0f;
	private float m_slideTime = 0.0f;
	private float m_downLAndRKeyTime = 0.0f;
	private float m_downFallKeyTime = 0.0f;
	private float m_flashTime = 0.0f;
	
	private Material[,] m_deleteAfterMaterial = new Material[4, Width];
	
	// Use this for initialization
	 public void Start () {
		// マテリアルの取得.
		m_red = Resources.Load ("Material/red")as Material;
		m_blue = Resources.Load ("Material/blue")as Material;
		m_lightBlue = Resources.Load ("Material/lightBlue")as Material;
		m_yello = Resources.Load ("Material/yello")as Material;
		m_yelloGreen = Resources.Load ("Material/yellowGreen")as Material;
		m_purple = Resources.Load ("Material/purple")as Material;
		m_orange = Resources.Load ("Material/orange")as Material;
		m_black = Resources.Load ("Material/black")as Material;
		m_white = Resources.Load ("Material/white")as Material;
		m_ghost = Resources.Load ("Material/ghost")as Material;
		
		// テキスト.
		m_scoreText = GameObject.Find ("Canvas/ScoreText").GetComponent<Text> ();
		m_levelText =  GameObject.Find ("Canvas/LevelText").GetComponent<Text> ();
		m_menuText = GameObject.Find ("Canvas/MenuText").GetComponent<Text>();
		m_tutorialText = GameObject.Find ("Canvas/TutorialText").GetComponent<Text> ();
		
		// 全体のゲームブロックの生成.
		for (int i=0; i<Height; i++) {
			for (int j=0; j<Width; j++) {
				Vector2 pos = new Vector2((Height/2)-i,-(Width/2)+j);
				m_block[i,j] = GameObject.CreatePrimitive (PrimitiveType.Cube);
				m_block[i,j].transform.position = new Vector3 (pos.y, pos.x, 0.0f);
				
				// ブロックの状態.
				m_blockState[i,j] = eBlockState.Empty;
				// ブロックの色を設定.
				Renderer renderer = m_block[i,j].GetComponent<Renderer>();
				renderer.material = m_black;
			}
		}
		
		m_nextTetrimonoType = SetTetriminoType();
		m_myTetrimino.SetType (m_nextTetrimonoType);
		SetTetrimino (m_myTetrimino.GetTetrimino(), m_myTetrimino.GetType(), m_myTetriminoState);
		
		// 5*5ブロックの作成.
		m_nextTetrimonoType = SetTetriminoType();
		SetTetrimino (m_nextTetrimino, m_nextTetrimonoType, 0);
		for (int i=0; i<5; i++) {
			for (int j=0; j<5; j++) {
				m_nextBlock[i,j] = GameObject.CreatePrimitive (PrimitiveType.Cube);
				Vector2 pos = new Vector2(5-i,7+j);
				m_nextBlock[i,j].transform.position = new Vector3 (pos.y, pos.x, 0.0f);
			}
		}
		SetColor (m_nextBlock, m_nextTetrimino, m_nextTetrimonoType);
		
		m_Status = eStatus.Tutorial;
		Transit (m_Status);
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
	
	// シーンを代える.
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
		// 代わった時に1回しかやらないことをする.
		Debug.Log ("Tutorial");
		m_menuText.text = "Tutorial\npush  Enter";
		m_tutorialText.text = "操作説明\n\n←→キー：左右の移動\n↓キー：落下速度の加速操作\nZキー：左回転\nXキー：右回転";
	}
	
	void StartPlay(eStatus PrevStatus){
		// 代わった時に1回しかやらないことをする.
		Debug.Log ("Play");
		
		m_menuText.text = "";
		m_tutorialText.text = "";

		m_myTetrimino.SetType (m_nextTetrimonoType);
		SetTetrimino (m_myTetrimino.GetTetrimino(), m_myTetrimino.GetType(), m_myTetriminoState);
		// 自分の初期位置.
		m_myTetrimino.SetPosition (new Vector2 (3, -4));
		
		// 次のブロックの準備を行う.
		m_nextTetrimonoType = SetTetriminoType();
		SetTetrimino (m_nextTetrimino, m_nextTetrimonoType, 0);
		SetColor (m_nextBlock, m_nextTetrimino, m_nextTetrimonoType);
		
		SetBlock ();
		m_scoreText.text = "Score\n"+m_score.ToString();
		m_level = 1;
		m_levelText.text = "Level\n" + m_level.ToString ();
	}
	
	void StartGameover(eStatus PrevStatus){
		// 代わった時に1回しかやらないことをする.
		Debug.Log ("Gameover");
		m_menuText.text = "Gameover\npush  Enter\n\nYour score:"+m_score.ToString();
	}
	
	// tutorial状態の更新関数.
	void UpdateTutorial(){
		// enterキーでゲームに遷移する.
		if (Input.GetKeyDown (KeyCode.Return)) {
			Transit (eStatus.Play);
		}
	}
	
	// play状態の更新関数.
	void UpdatePlay(){
		if (!m_deleteFlag) {
			// 時間の取得.
			m_timer += Time.deltaTime;
			
			// 一番下についた時またはブロックが下にあった場合の積む処理.
			if (CheckHit (new Vector2 (m_myTetrimino.GetPosition().x, m_myTetrimino.GetPosition().y + 1))) {
				m_timer = 0.0f;
				m_slideTime += Time.deltaTime;
				
				// ゲームオーバーになるか確認する.
				if (CheckGameover (new Vector2 (m_myTetrimino.GetPosition().x, m_myTetrimino.GetPosition().y))) {
					// もう積めない場合ゲームオーバーに遷移する.
					Transit (eStatus.Gameover);
				}
				else{
					// ブロックのすべり時間処理.
					if (m_slideTime > 0.5f) {
						// ブロックを決定する.
						DecisionBlock ();
						m_deleteFlag = true;
					}
				}
			}
			// 自然落下処理.
			else if (!Input.GetKey (KeyCode.DownArrow) &&
			         (m_timer > m_fallSpeed)) {
				m_timer = 0.0f;
				ClearState ();
				DrawBlack();
				m_myTetrimino.SetPosition(new Vector2(m_myTetrimino.GetPosition().x, m_myTetrimino.GetPosition().y+1));
				SetBlock ();
			}
			
			// RightArrowキーで右へ移動.
			if (Input.GetKeyDown (KeyCode.RightArrow)){
				MoveBlock(eKeyCode.RightArrow);
				m_downLAndRKeyTime = 0.0f;
			}
			else if (Input.GetKey (KeyCode.RightArrow) && !Input.GetKey (KeyCode.LeftArrow)) {
				m_downLAndRKeyTime += Time.deltaTime;
				
				if(m_downLAndRKeyTime >= 0.1f){
					MoveBlock(eKeyCode.RightArrow);
					m_downLAndRKeyTime = 0.0f;
				}
			}
			
			// LeftArrowキーで左へ移動.
			if (Input.GetKeyDown (KeyCode.LeftArrow)){
				MoveBlock(eKeyCode.LeftArrow);
				m_downLAndRKeyTime = 0.0f;
			}
			if (Input.GetKey (KeyCode.LeftArrow) && !Input.GetKey (KeyCode.RightArrow)) {
				m_downLAndRKeyTime += Time.deltaTime;
				
				if(m_downLAndRKeyTime >= 0.1f){
					MoveBlock(eKeyCode.LeftArrow);
					m_downLAndRKeyTime = 0.0f;
				}
			}
			
			// DownArroeキーで下へ移動.
			if (Input.GetKey (KeyCode.DownArrow)) {
				m_downFallKeyTime += Time.deltaTime;
				
				if(m_downFallKeyTime >= 0.1f){
					MoveBlock(eKeyCode.DownArrow);
					m_downFallKeyTime = 0.0f;
					m_downPoint+=1;
				}
			}
			
			// Xキーで右回転を行う.
			if (Input.GetKeyDown (KeyCode.X)) {
				RotateBlock(eKeyCode.XKeyCode);
			}
			
			// Zキーで左回転を行う.
			if (Input.GetKeyDown (KeyCode.Z)) {
				RotateBlock(eKeyCode.ZKeyCode);
			}
			
			DrawGhost();
		}
		else {
			DeleteBlock (m_myExistUnderPositionY);
			
			if(deleteEndFlag == true){
				CalculateScore();
				
				// 操作ブロックに次のものをセットする.
				m_myTetriminoState = 0;
				m_myTetrimino.SetType (m_nextTetrimonoType);
				SetTetrimino (m_myTetrimino.GetTetrimino(), m_myTetrimino.GetType(), m_myTetriminoState);
				// 初期位置に戻す.
				m_myTetrimino.SetPosition(new Vector2 (3, -4));
				// 次のブロックの準備を行う.
				m_nextTetrimonoType = SetTetriminoType();
				SetTetrimino (m_nextTetrimino, m_nextTetrimonoType, 0);
				SetColor (m_nextBlock, m_nextTetrimino, m_nextTetrimonoType);
				
				m_slideTime = 0.0f;
				m_downPoint=0;
				m_level+=m_deleteLineNumber;
				m_deleteLineNumber=0;
				m_level+=1;
				m_levelText.text = "Level\n" + m_level.ToString ();
				// レベルに伴ったスピードアップ.
				if (m_level % 20 == 0) {
					m_fallSpeed -= 0.1f;
				}
				if (m_fallSpeed < 0.05f) {
					m_fallSpeed = 0.05f;
				}
				m_deleteFlag=false;
				m_flashTime = 0.0f;
				DrawBlack();
			}
		}
	}
	
	// gameover状態の更新関数.
	void UpdateGameover(){
		// enterキーでタイトルに切り替える.
		if(Input.GetKeyDown(KeyCode.Return))
		{
			Application.LoadLevel("Title");
		}
	}
	
	// ランダムにテトリミノをセットする関数.
	eTetriminoType SetTetriminoType(){
		int type = Random.Range(0,7);
		
		return (eTetriminoType)type;
	}
	
	// テトリミノのタイプを設定する関数.
	void SetTetrimino(int[,] tetrimino,eTetriminoType type,int state){
		for (int i=0; i<5; i++) {
			for(int j=0;j<5;j++){
				switch(type){
				case eTetriminoType.OTetrimino:
					tetrimino[i,j]=O_Tetrimino[state,i,j];
					break;
					
				case eTetriminoType.ITetrimino:
					tetrimino[i,j]=I_Tetrimino[state,i,j];
					break;
					
				case eTetriminoType.STetrimino:
					tetrimino[i,j]=S_Tetrimino[state,i,j];
					break;
					
				case eTetriminoType.ZTetrimino:
					tetrimino[i,j]=Z_Tetrimino[state,i,j];
					break;
					
				case eTetriminoType.JTetrimino:
					tetrimino[i,j]=J_Tetrimino[state,i,j];
					break;
					
				case eTetriminoType.LTetrimino:
					tetrimino[i,j]=L_Tetrimino[state,i,j];
					break;
					
				case eTetriminoType.TTetrimino:
					tetrimino[i,j]=T_Tetrimino[state,i,j];
					break;
					
				}
				
			}
		}
	}
	
	// いくつかのブロックの色をまとめて設定する関数.
	void SetColor(GameObject[,] block, int[,] tetrimino,eTetriminoType type){
		for (int i=0; i<5; i++) {
			for(int j=0;j<5;j++){
				Renderer renderer = block[i,j].GetComponent<Renderer>();
				renderer.material = m_black;
				switch(type){
				case eTetriminoType.OTetrimino:
					if(tetrimino[i,j]==1){
						renderer.material = m_yello;
					}
					break;
					
				case eTetriminoType.ITetrimino:
					if(tetrimino[i,j]==1){
						renderer.material = m_lightBlue;
					}
					break;
					
				case eTetriminoType.STetrimino:
					if(tetrimino[i,j]==1){
						renderer.material = m_yelloGreen;
					}
					break;
					
				case eTetriminoType.ZTetrimino:
					if(tetrimino[i,j]==1){
						renderer.material = m_red;
					}
					break;
					
				case eTetriminoType.JTetrimino:
					if(tetrimino[i,j]==1){
						renderer.material = m_blue;
					}
					break;
					
				case eTetriminoType.LTetrimino:
					if(tetrimino[i,j]==1){
						renderer.material = m_orange;
					}
					break;
					
				case eTetriminoType.TTetrimino:
					if(tetrimino[i,j]==1){
						renderer.material = m_purple;
					}
					break;		
				}
				
			}
		}
	}
	
	// ブロック1個の色を設定する関数.
	void SetColorSimple(GameObject block, int tetrimino,eTetriminoType type){
		Renderer renderer = block.GetComponent<Renderer>();
		switch(type){
		case eTetriminoType.OTetrimino:
			if(tetrimino==1){
				renderer.material = m_yello;
			}
			break;
			
		case eTetriminoType.ITetrimino:
			if(tetrimino==1){
				renderer.material = m_lightBlue;
			}
			break;
			
		case eTetriminoType.STetrimino:
			if(tetrimino==1){
				renderer.material = m_yelloGreen;
			}
			break;
			
		case eTetriminoType.ZTetrimino:
			if(tetrimino==1){
				renderer.material = m_red;
			}
			break;
			
		case eTetriminoType.JTetrimino:
			if(tetrimino==1){
				renderer.material = m_blue;
			}
			break;
			
		case eTetriminoType.LTetrimino:
			if(tetrimino==1){
				renderer.material = m_orange;
			}
			break;
			
		case eTetriminoType.TTetrimino:
			if(tetrimino==1){
				renderer.material = m_purple;
			}
			break;		
		}				
	}

	// 使用中のブロックの位置を設定する関数.
	void SetBlock(){
		for (int i=4; i>=0; i--) {
			for(int j=0;j<5;j++){
				if((int)m_myTetrimino.GetPosition().y+i >= 0 && (int)m_myTetrimino.GetPosition().y+i < Height
				   && ((int)m_myTetrimino.GetPosition().x+j >= 0 && (int)m_myTetrimino.GetPosition().x+j < Width) &&
				   m_blockState[(int)m_myTetrimino.GetPosition().y+i,(int)m_myTetrimino.GetPosition().x+j]!=eBlockState.Used){
					SetColorSimple(m_block[(int)m_myTetrimino.GetPosition().y+i,(int)m_myTetrimino.GetPosition().x+j],
					               m_myTetrimino.GetTetrimino()[i,j],
					               m_myTetrimino.GetType());
					if(m_myTetrimino.GetTetrimino()[i,j]==1)
						m_blockState[(int)m_myTetrimino.GetPosition().y+i,(int)m_myTetrimino.GetPosition().x+j]=eBlockState.Using;
				}
			}
		}
	}
	
	// 操作ブロックの使用中だったところを空にする関数.
	void ClearState(){
		for (int i=4; i>=0; i--) {
			for (int j=0; j<5; j++) {
				if((int)m_myTetrimino.GetPosition().y+i < Height && (int)m_myTetrimino.GetPosition().y+i >= 0 && 
				   (int)m_myTetrimino.GetPosition().x+j < Width && (int)m_myTetrimino.GetPosition().x+j >= 0 && 
				   m_blockState[(int)m_myTetrimino.GetPosition().y+i,(int)m_myTetrimino.GetPosition().x+j]==eBlockState.Using)
					m_blockState[(int)m_myTetrimino.GetPosition().y+i,(int)m_myTetrimino.GetPosition().x+j]=eBlockState.Empty;
			}
		}
	}
	
	// 移動先が移動可能か判定する関数.
	bool CheckHit(Vector2 movedPos){
		for (int i=4; i>=0; i--) {
			for(int j=0;j<5;j++){
				if(m_myTetrimino.GetTetrimino()[i,j]==1 && (int)movedPos.y+i >= 0 && (int)movedPos.x+j >= 0 && (int)movedPos.x+j < Width &&
				   (((int)movedPos.y+i >= Height) || m_blockState[(int)movedPos.y+i,(int)movedPos.x+j]==eBlockState.Used)){
					return true;
				}
			}
		}
		return false;
	}
	
	// ブロックを決定する関数.
	void DecisionBlock(){
		m_myExistUnderPositionY = 0;
		for (int i=4; i>=0; i--) {
			for (int j=0; j<5; j++) {
				if ((int)m_myTetrimino.GetPosition().y + i < Height && (int)m_myTetrimino.GetPosition().y + i >= 0 &&
				    (int)m_myTetrimino.GetPosition().x + j < Width && (int)m_myTetrimino.GetPosition().x + j >= 0 &&
				    m_blockState [(int)m_myTetrimino.GetPosition().y + i, (int)m_myTetrimino.GetPosition().x + j] == eBlockState.Using) {
					if ((int)m_myTetrimino.GetPosition().y + i > m_myExistUnderPositionY) {
						m_myExistUnderPositionY = (int)m_myTetrimino.GetPosition().y + i;
					}
					m_blockState [(int)m_myTetrimino.GetPosition().y + i, (int)m_myTetrimino.GetPosition().x + j] = eBlockState.Used;
				}
			}
		}
	}
	
	// ブロックの移動関数.
	void MoveBlock (eKeyCode keyCode = eKeyCode.None) {
		int moveX = 0;
		int moveY = 0;
		switch (keyCode) {
			// 左が押された場合.
		case eKeyCode.LeftArrow:
			moveX = -1;
			break;
			// 右が押された場合.
		case eKeyCode.RightArrow:
			moveX = 1;
			break;
			// 落下.
		case eKeyCode.DownArrow:
			moveY = 1;
			break;
		default:
			break;
		}
		
		// 移動先に移動できるか調べる関数.
		if (!CheckOverBlock (new Vector2 (m_myTetrimino.GetPosition().x + moveX, m_myTetrimino.GetPosition().y + moveY)) &&
		    !CheckHit (new Vector2 (m_myTetrimino.GetPosition().x + moveX, m_myTetrimino.GetPosition().y + moveY))) {
			ClearState ();
			DrawBlack();
			m_myTetrimino.SetPosition(new Vector2(m_myTetrimino.GetPosition().x+moveX,m_myTetrimino.GetPosition().y+moveY));
			SetBlock();
		}
	}
	
	// 移動先でブロックが左右の枠からはみ出さないかチェックする関数.
	bool CheckOverBlock(Vector2 movedPos){
		for (int i=4; i>=0; i--) {
			for(int j=0;j<5;j++){
				if(m_myTetrimino.GetTetrimino()[i,j]==1&&(((int)movedPos.x+j >= Width) || ((int)movedPos.x+j < 0))){
					return true;
				}
			}
		}
		return false;
	}
	
	// ステータスが空の場所を黒にする関数.
	void DrawBlack(){
		for (int i=0; i<Height; i++) {
			for (int j=0; j<Width; j++) {
				if(m_blockState[i,j] == eBlockState.Empty){
					// ブロックの色を設定.
					Renderer renderer = m_block[i,j].GetComponent<Renderer>();
					renderer.material = m_black;
				}
			}
		}
	}
	
	// 回転処理を行う関数.
	void RotateBlock(eKeyCode keyCode = eKeyCode.None){
		int moveStateNum = 0;
		switch (keyCode) {
			// Zが押された場合（左回転）.
		case eKeyCode.ZKeyCode:
			moveStateNum = -1;
			
			if (moveStateNum + m_myTetriminoState < 0) {
				moveStateNum=3;
			}
			else{
				moveStateNum = m_myTetriminoState + moveStateNum;
			}
			break;
			// Xが押された場合（右回転）.
		case eKeyCode.XKeyCode:
			moveStateNum = 1;
			
			if(moveStateNum + m_myTetriminoState > 3){
				moveStateNum=0;
			}
			else{
				moveStateNum = m_myTetriminoState + moveStateNum;
			}
			break;
		default:
			break;
		}
		
		int frontStateNum = m_myTetriminoState;
		m_myTetriminoState = moveStateNum;
		SetTetrimino(m_myTetrimino.GetTetrimino(),m_myTetrimino.GetType(),m_myTetriminoState);
		// 回転後ブロックにぶつからないか調べる.
		if (!CheckHit (m_myTetrimino.GetPosition())) {
			RotateCheck (m_myTetrimino.GetPosition());
			
			if (m_shiftNum == 0 || !CheckHit (new Vector2 (m_myTetrimino.GetPosition().x - m_shiftNum, m_myTetrimino.GetPosition().y))){
				m_myTetrimino.SetPosition(new Vector2(m_myTetrimino.GetPosition().x-m_shiftNum,m_myTetrimino.GetPosition().y));
				ClearState ();
				DrawBlack();
				SetBlock ();
			}
			// 回転不可能.
			else{
				m_myTetriminoState = frontStateNum;
				SetTetrimino(m_myTetrimino.GetTetrimino(),m_myTetrimino.GetType(),m_myTetriminoState);
			}
		}
		else {
			RotateCheck(m_myTetrimino.GetPosition());
			// 回転すると当たってしまうが、ずらした場合に回転できるか調べる.
			SetShiftNum();
			if(!CheckHit (new Vector2(m_myTetrimino.GetPosition().x-m_shiftNum,m_myTetrimino.GetPosition().y))){
				m_myTetrimino.SetPosition(new Vector2(m_myTetrimino.GetPosition().x-m_shiftNum,m_myTetrimino.GetPosition().y));
				ClearState ();
				DrawBlack();
				SetBlock ();
			}
			else if(!CheckHit (new Vector2(m_myTetrimino.GetPosition().x+m_shiftNum,m_myTetrimino.GetPosition().y))){
				m_myTetrimino.SetPosition(new Vector2(m_myTetrimino.GetPosition().x+m_shiftNum,m_myTetrimino.GetPosition().y));
				ClearState ();
				DrawBlack();
				SetBlock ();
			}
			// 回転不可能.
			else{
				m_myTetriminoState = frontStateNum;
				m_shiftNum=0;
				SetTetrimino(m_myTetrimino.GetTetrimino(),m_myTetrimino.GetType(),m_myTetriminoState);
			}
		}
	}
	
	// 回転時ブロック同士が衝突する時どれだけずらすか設定する関数.
	void SetShiftNum(){
		switch(m_myTetrimino.GetType()){
		case eTetriminoType.ITetrimino:
			if(m_myTetriminoState==1 || m_myTetriminoState==3)
				m_shiftNum=2;
			else
				m_shiftNum=1;
			break;
		default:
			m_shiftNum=1;
			break;
		}
	}

	// 回転できるかチェックする関数.
	bool RotateCheck(Vector2 movedPos){
		for (int i=4; i>=0; i--) {
			for(int j=0;j<5;j++){
				if(m_myTetrimino.GetType() == eTetriminoType.ITetrimino && m_myTetrimino.GetTetrimino()[i,j]==1){
					
					if((int)movedPos.x+j >= Width){
						if(m_myTetriminoState!=1)
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
				else if(m_myTetrimino.GetType() != eTetriminoType.ITetrimino && m_myTetrimino.GetTetrimino()[i,j]==1){
					if((int)movedPos.x+j >= Width){
						m_shiftNum=((int)movedPos.x+j)-(Width-1);
						return true;
					}
					else if((int)movedPos.x+j < 0){
						m_shiftNum=(int)movedPos.x+j;
						return true;
					}
				}
			}
		}
		m_shiftNum = 0;
		return false;
	}
	
	// Gameoverか判定する関数.
	bool CheckGameover(Vector2 movedPos){
		for (int i=4; i>=0; i--) {
			for(int j=0;j<5;j++){
				if(m_myTetrimino.GetTetrimino()[i,j]==1 && (int)movedPos.y+i < 0){
					return true;
				}
			}
		}
		return false;
	}
	
	// 一列そろっているか調べる関数.
	bool CheckDeleteLine(int nowPositionY){
		for (int i=0; i<Width; i++) {
			if(nowPositionY >= 0 && m_blockState[nowPositionY,i]!=eBlockState.Used){
				return false;
			}
		}
		return true;
	}

	// 消せるブロックの数を数える関数.
	int CountDeleteBlock(int nowPositionY){
		int lineCount = 0;
		
		for (int i=0; i<4; i++) {
			if(CheckDeleteLine(nowPositionY-i)){
				lineCount+=1;
			}
		}
		
		return lineCount;
	}

	// ブロックを光らせる関数.
	void FlashBlock(int nowPositionY){
		Renderer renderer;
		
		for (int i=0; i<4; i++) {
			if(CheckDeleteLine(nowPositionY-i)){
				for(int j=0;j<Width;j++){
					if(nowPositionY-i >= 0){
						renderer = m_block[nowPositionY-i,j].GetComponent<Renderer>();
						m_deleteAfterMaterial[3-i,j] = renderer.material;
						renderer.material = m_white;
					}
				}
			}
		}
		
		m_flashTime += Time.deltaTime;
		
		if (m_flashTime >= 0.5f)
			m_deleteFlag = false;
	}
	
	// そろっているブロックを消す関数.
	void DeleteBlock(int nowPositionY){	
		int lineCount = 0;
		Material[,] deleteAfterMaterial = new Material[4, Width];
		eBlockState[,] deleteAfterState = new eBlockState[4, Width];
		Renderer renderer;
		// 初期化.
		for(int i=0;i<4;i++){
			for(int j=0;j<Width;j++){
				deleteAfterState[i,j]=eBlockState.Empty;
				deleteAfterMaterial[i,j] = m_black;
			}
		}
		
		// 消した後のブロックを生成していく.
		for (int i=0; i<4; i++) {
			if(!CheckDeleteLine(nowPositionY-i)){
				for(int j=0;j<Width;j++){
					deleteAfterState[3-lineCount,j] = m_blockState[nowPositionY-i,j];
					renderer = m_block[nowPositionY-i,j].GetComponent<Renderer>();
					deleteAfterMaterial[3-lineCount,j] = renderer.material;
				}
				lineCount+=1;
			}
		}
		
		// そろっているブロックがある場合.
		if (lineCount != 4) {
			m_deleteFlag = true;
			deleteEndFlag = false;
			
			FlashBlock (nowPositionY);
			if (m_deleteFlag == false) {
				lineCount = 4 - lineCount;

				bool downFlag = true;
				
				m_deleteLineNumber = lineCount;
				for (int i=0; i<4; i++) {
					if ((nowPositionY - i) >= 0) {
						for (int j=0; j<Width; j++) {
							m_blockState [(nowPositionY - i), j] = deleteAfterState [3 - i, j];
							renderer = m_block [nowPositionY - i, j].GetComponent<Renderer> ();
							renderer.material = deleteAfterMaterial [3 - i, j];
						}
					} else {
						downFlag = false;
					}
				}
				
				for (int i=nowPositionY-(4-lineCount); i>lineCount; i--) {
					if (i >= 0) {
						for (int j=0; j<Width; j++) {
							m_blockState [i, j] = m_blockState [i - lineCount, j];
							renderer = m_block [i, j].GetComponent<Renderer> ();
							Renderer renderer2 = m_block [i - lineCount, j].GetComponent<Renderer> (); 
							renderer.material = renderer2.material;
						}
					} else {
						downFlag = false;
					}
				}
				
				if (downFlag) {
					for (int i=lineCount; i>=0; i--) {
						for (int j=0; j<Width; j++) {
							m_blockState [i, j] = eBlockState.Empty;
							renderer = m_block [i, j].GetComponent<Renderer> ();
							renderer.material = m_black;
						}
					}
				}		
				deleteEndFlag = true;
			}
		}
	}
	
	// ゴーストブロック更新時先に真っ黒にしておく関数.
	void BlackDrawGhost(){
		Renderer renderer;
		for (int i=0; i<Height; i++) {
			for (int j=0; j<Width; j++) {
				if (m_blockState [i, j] == eBlockState.Ghost){
					renderer = m_block[i,j].GetComponent<Renderer>();
					renderer.material = m_black;
				}
			}
		}
	}
	
	// ゴーストブロックを描画する関数.
	void DrawGhost(){
		int num = 1;
		while(!CheckHit (new Vector2(m_myTetrimino.GetPosition().x,m_myTetrimino.GetPosition().y+num))){
			num+=1;
		}
		
		num += 3;
		
		BlackDrawGhost ();
		Renderer renderer;
		for (int i=0; i<5; i++) {
			for(int j=0;j<5;j++){
				if(m_myTetrimino.GetTetrimino()[4-i,j]==1 && ((int)m_myTetrimino.GetPosition().y+num)-i >= 0 && ((int)m_myTetrimino.GetPosition().y+num)-i < Height&&
				   m_blockState[((int)m_myTetrimino.GetPosition().y+num)-i,(int)m_myTetrimino.GetPosition().x+j] != eBlockState.Used){
					m_blockState[((int)m_myTetrimino.GetPosition().y+num)-i,(int)m_myTetrimino.GetPosition().x+j] = eBlockState.Ghost;
					renderer = m_block[((int)m_myTetrimino.GetPosition().y+num)-i,(int)m_myTetrimino.GetPosition().x+j].GetComponent<Renderer>();
					renderer.material = m_ghost;
				}
			}
		}	
		SetBlock();
	}
	
	// スコアを計算 表示する関数.
	void CalculateScore(){
		if (m_downPoint == 0) {
			m_score += 1;
		}
		else if (m_downPoint < Height) {
			m_score += m_downPoint;
		}
		else {
			m_score += (Height-1);
		}
		
		switch (m_deleteLineNumber) {
		case 0:
			break;
		case 1:
			m_score += 40;
			break;
		case 2:
			m_score += 100;
			break;
		case 3:
			m_score += 300;
			break;
		case 4:
			m_score += 1200;
			break;
		}
		m_scoreText.text = "Score\n"+m_score.ToString();
	}
}
