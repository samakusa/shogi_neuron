using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardScene : MonoBehaviour {
    public GameObject Canvas;
    public GameObject onBoard;
    public GameObject piecePrefab;
    public GameObject promotePrefab;
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

    private Engine _Engine;
    private bool b;

    // Start is called before the first frame update
    void Start() {
        for (int i = 1; i <= (int)PieceRenderer.piece_types.GOLD; i++) {
            this.BlackHandPieces[i].GetComponent<Hand>().SetPieceType((PieceRenderer.piece_types)i);
            this.BlackHandPieces[i].GetComponent<Hand>().SetTurn(PieceRenderer.turn.BLACK);
            this.WhiteHandPieces[i].GetComponent<Hand>().SetPieceType((PieceRenderer.piece_types)i);
            this.WhiteHandPieces[i].GetComponent<Hand>().SetTurn(PieceRenderer.turn.WHITE);
        }
        PieceRenderer.RenderSfen(this.onBoard, this.piecePrefab, this.begin_board_sfen);

        this._Engine = new Engine();
        this._Engine.Initialize();
    }

    // Update is called once per frame
    void Update() {
        if (!this.b) {
            this._Engine.Send("user echo test0");
            this._Engine.Send("user echo test1");
            this._Engine.Send("user echo test2");
            this._Engine.Send("user echo test3");
            this.b = true;
        }
        string output = this._Engine.Recieve();
        if (output != "") Debug.Log(output);
    }

    public void Move(Vector3 dst) {
        if (ENABLE_PROMOTE(dst, this.PieceSelected)) {
            var handler = Promote.ShowDialog(this.Canvas, dst,
                this.PieceSelected.GetComponent<Piece>().GetPieceType(),
                () => Move(dst, true),
                () => Move(dst, false)
                );
        }
        else {
            Move(dst, false);
        }
    }
    public void OnDestroy() {
        this._Engine.Send("quit");
    }

    private void Move(Vector3 dst, bool promote) {
        this.PieceRenderer.Move(this.PieceSelected, dst, promote);
        SetStatus(STATUS.NORMAL);
    }

    public void Move(Vector3 dst, GameObject cap_piece, PieceRenderer.piece_types type, PieceRenderer.turn turn) {
        if (ENABLE_PROMOTE(dst, this.PieceSelected)) {
            var handler = Promote.ShowDialog(this.Canvas, dst,
                this.PieceSelected.GetComponent<Piece>().GetPieceType(),
                () => Move(dst, cap_piece, type, turn, true),
                () => Move(dst, cap_piece, type, turn, false)
                );
        }
        else {
            Move(dst, cap_piece, type, turn, false);
        }
    }

    private void Move(Vector3 dst, GameObject cap_piece, PieceRenderer.piece_types type, PieceRenderer.turn turn, bool promote) {
        this.PieceRenderer.Capture(cap_piece, turn == PieceRenderer.turn.BLACK ? this.WhiteHandPieces : this.BlackHandPieces, type);
        this.PieceRenderer.Move(this.PieceSelected, dst, promote);
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

    private bool ENABLE_PROMOTE_BLACK(Vector3 v, GameObject piece) {
        Vector3 src = piece.transform.localPosition;
        PieceRenderer.turn turn = piece.GetComponent<Piece>().GetTurn();
        PieceRenderer.piece_types type = piece.GetComponent<Piece>().GetPieceType();
        return turn == PieceRenderer.turn.BLACK && (PieceRenderer.Row(src) <= 3 || PieceRenderer.Row(v) <= 3) && type <= PieceRenderer.piece_types.ROOK;
    }

    private bool ENABLE_PROMOTE_WHITE(Vector3 v, GameObject piece) {
        Vector3 src = piece.transform.localPosition;
        PieceRenderer.turn turn = piece.GetComponent<Piece>().GetTurn();
        PieceRenderer.piece_types type = piece.GetComponent<Piece>().GetPieceType();
        return turn == PieceRenderer.turn.WHITE && (PieceRenderer.Row(src) >= 7 || PieceRenderer.Row(v) >= 7) && type <= PieceRenderer.piece_types.ROOK;
    }

    private bool ENABLE_PROMOTE(Vector3 v, GameObject piece) {
        return ENABLE_PROMOTE_BLACK(v, piece) || ENABLE_PROMOTE_WHITE(v, piece);
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
