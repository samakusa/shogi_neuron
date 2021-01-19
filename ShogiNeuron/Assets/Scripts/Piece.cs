using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour {
    private PieceRenderer.piece_types PieceType;
    private PieceRenderer.turn Turn;
    public GameObject Canvas;
    private GameObject BoardSceneObj;
    private BoardScene BoardScene_;
    private PieceRenderer Render = new PieceRenderer();

    // Start is called before the first frame update
    void Start() {
        this.Canvas = GameObject.Find("BoardCanvas");
        this.BoardSceneObj = GameObject.Find("BoardScene");
        this.BoardScene_ = this.BoardSceneObj.GetComponent<BoardScene>();
    }

    // Update is called once per frame
    void Update() {
    }

    public void Tap() {
        BoardScene boardScene = this.BoardSceneObj.GetComponent<BoardScene>();
        if (this.BoardScene_.GetStatus() == BoardScene.STATUS.NORMAL) {
            this.BoardScene_.SetStatus(BoardScene.STATUS.MOVE);
            this.BoardScene_.SetPieceSelected(this.transform.gameObject);
        }
        else if (this.BoardScene_.GetStatus() == BoardScene.STATUS.MOVE) {
            Vector3 m = Input.mousePosition;
            Vector2 c = this.Canvas.GetComponent<RectTransform>().sizeDelta;
            Vector3 v = new Vector3(m.x - c.x / 2, m.y - c.y / 2, 0.0f);
            Piece piece = this.transform.gameObject.GetComponent<Piece>();
            PieceRenderer.piece_types type = piece.GetPieceType();
            PieceRenderer.turn turn = piece.GetTurn();
            boardScene.Move(v, this.transform.gameObject, type, turn);
        }
        else if (this.BoardScene_.GetStatus() == BoardScene.STATUS.DROP) {
            // Asser(this.BoardScene.GetStatus() == BoardScene.STATUS.DROP);
            this.BoardScene_.SetStatus(BoardScene.STATUS.NORMAL);
        }
        else if (this.BoardScene_.GetStatus() == BoardScene.STATUS.PROMOTE) {
        }
        else {
            // Assert(true);
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
