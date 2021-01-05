using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardScene : MonoBehaviour {
    public GameObject onBoard;
    public GameObject piecePrefab;
    public GameObject[] BlackHandPieces;
    public GameObject[] WhiteHandPieces;
    public enum STATUS {
        NORMAL,
        MOVING,
    };

    private PieceRenderer PieceRenderer = new PieceRenderer();
    private string begin_board_sfen = "lnsgkgsnl/1r5b1/ppppppppp/9/9/9/PPPPPPPPP/1B5R1/LNSGKGSNL b -";

    private STATUS Status = STATUS.NORMAL;
    private bool IsPieceSelected = false;
    private GameObject PieceSelected;

    // Start is called before the first frame update
    void Start() {
        PieceRenderer.RenderSfen(this.onBoard, this.piecePrefab, this.begin_board_sfen);
    }

    // Update is called once per frame
    void Update() {
    }

    public void Move(Vector3 dst) {
        this.PieceRenderer.Move(this.PieceSelected, dst);
        this.IsPieceSelected = false;
    }

    public void Move(Vector3 dst, GameObject cap_piece, PieceRenderer.piece_types type, PieceRenderer.turn turn) {
        this.PieceRenderer.Capture(cap_piece, turn == PieceRenderer.turn.BLACK ? this.WhiteHandPieces : this.BlackHandPieces, type);
        this.PieceRenderer.Move(this.PieceSelected, dst);
        this.IsPieceSelected = false;
    }

    public STATUS GetStatus() {
        return this.Status;
    }

    public void SetStatus(STATUS status) {
        this.Status = status;
    }

    public void SetIsPieceSelected(bool b) {
        this.IsPieceSelected = b;
    }

    public bool GetIsPieceSelected() {
        return this.IsPieceSelected;
    }

    public void SetPieceSelected(GameObject piece) {
        this.PieceSelected = piece;
    }
}
