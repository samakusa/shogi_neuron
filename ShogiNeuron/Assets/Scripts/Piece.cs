using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour {
    private PieceRenderer.piece_types PieceType;
    private PieceRenderer.turn Turn;
    private GameObject Canvas;
    private GameObject BoardScene;
    private PieceRenderer Render = new PieceRenderer();

    // Start is called before the first frame update
    void Start() {
        this.Canvas = GameObject.Find("Canvas");
        this.BoardScene = GameObject.Find("BoardScene");
    }

    // Update is called once per frame
    void Update() {
    }

    public void Tap() {
        Debug.Log("Start");
        BoardScene boardScene = this.BoardScene.GetComponent<BoardScene>();
        if (!boardScene.GetIsPieceSelected()) {
            Debug.Log("Set");
            boardScene.SetIsPieceSelected(true);
            boardScene.SetPieceSelected(this.transform.gameObject);
        }
        else {
            Vector3 m = Input.mousePosition;
            Vector2 c = this.Canvas.GetComponent<RectTransform>().sizeDelta;
            Vector3 v = new Vector3(m.x - c.x/2, m.y - c.y/2, 0.0f);
            Piece piece = this.transform.gameObject.GetComponent<Piece>();
            PieceRenderer.piece_types type = piece.GetPieceType();
            PieceRenderer.turn turn = piece.GetTurn();
            boardScene.Move(v, this.transform.gameObject, type, turn);
        }
    }

    public void SetPieceType(PieceRenderer.piece_types type) {
        this.PieceType = type;
    }

    public PieceRenderer.piece_types GetPieceType() {
        return this.PieceType;
    }

    public void SetTurn(PieceRenderer.turn turn) {
        this.Turn = turn;
    }

    public PieceRenderer.turn GetTurn() {
        return this.Turn;
    }
}
