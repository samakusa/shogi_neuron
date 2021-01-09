using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour {
    private GameObject BoardSceneObj;
    private BoardScene BoardScene_;
    private PieceRenderer.piece_types PieceType;
    private PieceRenderer.turn Turn;
    private Text Num;

    // Start is called before the first frame update
    void Start() {
        this.Num = this.transform.gameObject.GetComponentInChildren<Text>();
        this.BoardSceneObj = GameObject.Find("BoardScene");
        this.BoardScene_ = this.BoardSceneObj.GetComponent<BoardScene>();
    }

    // Update is called once per frame
    void Update() {
    }

    public void Tap() {
        if (this.BoardScene_.GetStatus() == BoardScene.STATUS.NORMAL) {
            this.BoardScene_.SetDropPieceType(this.PieceType);
            this.BoardScene_.SetDropTurn(this.Turn);
            this.BoardScene_.SetStatus(BoardScene.STATUS.DROP);
        }
        else if (this.BoardScene_.GetStatus() == BoardScene.STATUS.MOVE) {
            this.BoardScene_.SetStatus(BoardScene.STATUS.NORMAL);
        }
        else if (this.BoardScene_.GetStatus() == BoardScene.STATUS.DROP) {
            this.BoardScene_.SetStatus(BoardScene.STATUS.NORMAL);
        }
        else if (this.BoardScene_.GetStatus() == BoardScene.STATUS.PROMOTE) {
        }
    }

    public PieceRenderer.piece_types GetPieceType() {
        return this.PieceType;
    }

    public void SetPieceType(PieceRenderer.piece_types type) {
        this.PieceType = type;
    }

    public PieceRenderer.turn GetTurn() {
        return this.Turn;
    }

    public void SetTurn(PieceRenderer.turn turn) {
        this.Turn = turn;
    }

    public int GetNumber() {
        int n; int.TryParse(this.Num.text, out n);
        return n;
    }

    public void SetNumber(int n) {
        this.Num.text = n.ToString();
    }
}
