using UnityEngine;
using System.Collections;

public enum eTextType{
	ScoreText,
	//GameoverText,
	//TitleText,
};

public class ChangeFontSize : MonoBehaviour {
	public static readonly int m_width = Screen.width;		// 画面のサイズを取得
	public static readonly int m_height = Screen.height;	// 画面のサイズを取得

	public static readonly int parameterFontSize = 20;


	public GUIText m_text;
	public eTextType m_textType;

	Vector2 m_nowScreenSize;

	// Use this for initialization
	void Start () {
		m_nowScreenSize = new Vector2 (Screen.width, Screen.height);
		ChengeSize ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// フォントサイズ変更
	public void ChengeSize () {
		int fontSize = parameterFontSize;
		
		switch (m_textType) {
		case eTextType.ScoreText:
			fontSize = parameterFontSize;
			break;
		}
		
		// スクリーンの大きさによりフォントサイズ変更.
		m_nowScreenSize = new Vector2 (Screen.width, Screen.height);
		float fontSizeWidth = fontSize * (m_nowScreenSize.x / m_width);
		float fontSizeHeight = fontSize * (m_nowScreenSize.y / m_height);
		if (fontSizeWidth > fontSizeHeight) {
			m_text.fontSize = (int)fontSizeHeight;
		}
		else {
			m_text.fontSize = (int)fontSizeWidth;
		}
	}
}