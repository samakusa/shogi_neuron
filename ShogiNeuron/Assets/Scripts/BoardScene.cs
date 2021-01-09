using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardScene : MonoBehaviour {
    public GameObject Canvas;
    public GameObject onBoard;
    public GameObject piecePrefab;
    public GameObject[] BlackHandPieces;
    public GameObject[] WhiteHandPieces;
    public enum STATUS {
        NORMAL,
        MOVE,
        DROP,
        PROMOTE,
    };

    private PieceRenderer PieceRenderer = new PieceRenderer();
    private string begin_board_sfen = "lnsgkgsnl/1r5b1/ppppppppp/9/9/9/PPPPPPPPP/1B5R1/LNSGKGSNL b -";

    private STATUS Status = STATUS.NORMAL;
    private GameObject PieceSelected;
    private PieceRenderer.piece_types DropPieceType;
    private PieceRenderer.turn DropTurn;

    // Start is called before the first frame update
    void Start() {
        for (int i = 1; i <= (int)PieceRenderer.piece_types.GOLD; i++) {
            this.BlackHandPieces[i].GetComponent<Hand>().SetPieceType((PieceRenderer.piece_types)i);
            this.BlackHandPieces[i].GetComponent<Hand>().SetTurn(PieceRenderer.turn.BLACK);
            this.WhiteHandPieces[i].GetComponent<Hand>().SetPieceType((PieceRenderer.piece_types)i);
            this.WhiteHandPieces[i].GetComponent<Hand>().SetTurn(PieceRenderer.turn.WHITE);
        }
        PieceRenderer.RenderSfen(this.onBoard, this.piecePrefab, this.begin_board_sfen);
        var handler = Promote.ShowDialog(this.Canvas, new Vector3(0.0f, 0.0f, 0.0f));
    }

    // Update is called once per frame
    void Update() {
    }

    public void Move(Vector3 dst) {
        this.PieceRenderer.Move(this.PieceSelected, dst);
        SetStatus(STATUS.NORMAL);
    }

    public void Move(Vector3 dst, GameObject cap_piece, PieceRenderer.piece_types type, PieceRenderer.turn turn) {
        this.PieceRenderer.Capture(cap_piece, turn == PieceRenderer.turn.BLACK ? this.WhiteHandPieces : this.BlackHandPieces, type);
        this.PieceRenderer.Move(this.PieceSelected, dst);
        SetStatus(STATUS.NORMAL);
    }

    public void Drop(Vector3 dst) {
        PieceRenderer.Drop(this.onBoard,
                           this.piecePrefab,
                           this.DropTurn == PieceRenderer.turn.BLACK ? this.BlackHandPieces : this.WhiteHandPieces,
                           dst,
                           this.DropPieceType,
                           this.DropTurn);
        SetStatus(STATUS.NORMAL);
    }

    public STATUS GetStatus() {
        return this.Status;
    }

    public void SetStatus(STATUS status) {
        this.Status = status;
    }

    public PieceRenderer.piece_types GetDropPieceType() {
        return this.DropPieceType;
    }

    public void SetDropPieceType(PieceRenderer.piece_types type) {
        this.DropPieceType = type;
    }

    public PieceRenderer.turn GetDropTurn() {
        return this.DropTurn;
    }

    public void SetDropTurn(PieceRenderer.turn turn) {
        this.DropTurn = turn;
    }

    public void SetPieceSelected(GameObject piece) {
        this.PieceSelected = piece;
    }
}
