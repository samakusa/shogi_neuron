using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour {
    private PieceRenderer.piece_types PieceType;
    private PieceRenderer.turn Turn;
    private GameObject BoardScene;
    private PieceRenderer Render = new PieceRenderer();

    // Start is called before the first frame update
    void Start() {
        this.BoardScene = GameObject.Find("BoardScene");
    }

    // Update is called once per frame
    void Update() {
    }

    public void Tap() {
        Debug.Log(this.transform.gameObject.name);
        Render.Move(this.transform.gameObject, new Vector3(0.0f, 0.0f, 0.0f));
        //BoardScene boardScene = this.BoardScene.GetComponent<BoardScene>();
        //if (!boardScene.GetIsPieceSelected()) {
        //    boardScene.SetIsPieceSelected(true);
        //    boardScene.SetPieceSelected(this.transform.gameObject);
        //}
        //else {
        //    boardScene.Move(this.transform.localPosition, this.PieceType);
        //    boardScene.SetIsPieceSelected(false);
        //}
    }

    public void SetPieceType(PieceRenderer.piece_types type) {
        this.PieceType = type;
    }

    public void SetTurn(PieceRenderer.turn turn) {
        this.Turn = turn;
    }

    public PieceRenderer.turn GetTurn() {
        return this.Turn;
    }
}
