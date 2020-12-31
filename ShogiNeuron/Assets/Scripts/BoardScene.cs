using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardScene : MonoBehaviour {
    public GameObject onBoard;
    public GameObject handR;
    public GameObject handL;
    public GameObject piecePrefab;

    private PieceRenderer PieceRenderer = new PieceRenderer();
    private List<GameObject> Pieces = new List<GameObject>();
    private string begin_board_sfen = "lnsgkgsnl/1r5b1/ppppppppp/9/9/9/PPPPPPPPP/1B5R1/LNSGKGSNL b -";

    // Start is called before the first frame update
    void Start() {
        PieceRenderer.RenderSfen(this.onBoard, this.piecePrefab, this.begin_board_sfen, this.Pieces);
        PieceRenderer.Render(this.handR, piecePrefab, -1, PieceRenderer.piece_types.PORN, PieceRenderer.turn.BLACK);
        PieceRenderer.Render(this.handR, piecePrefab, -1, PieceRenderer.piece_types.LANCE, PieceRenderer.turn.BLACK);
        PieceRenderer.Render(this.handR, piecePrefab, -1, PieceRenderer.piece_types.KNIGHT, PieceRenderer.turn.BLACK);
        PieceRenderer.Render(this.handR, piecePrefab, -1, PieceRenderer.piece_types.SILVER, PieceRenderer.turn.BLACK);
        PieceRenderer.Render(this.handR, piecePrefab, -1, PieceRenderer.piece_types.GOLD, PieceRenderer.turn.BLACK);
        PieceRenderer.Render(this.handR, piecePrefab, -1, PieceRenderer.piece_types.BISHOP, PieceRenderer.turn.BLACK);
        PieceRenderer.Render(this.handR, piecePrefab, -1, PieceRenderer.piece_types.ROOK, PieceRenderer.turn.BLACK);
        PieceRenderer.Render(this.handL, piecePrefab, -1, PieceRenderer.piece_types.PORN, PieceRenderer.turn.WHITE);
        PieceRenderer.Render(this.handL, piecePrefab, -1, PieceRenderer.piece_types.LANCE, PieceRenderer.turn.WHITE);
        PieceRenderer.Render(this.handL, piecePrefab, -1, PieceRenderer.piece_types.KNIGHT, PieceRenderer.turn.WHITE);
        PieceRenderer.Render(this.handL, piecePrefab, -1, PieceRenderer.piece_types.SILVER, PieceRenderer.turn.WHITE);
        PieceRenderer.Render(this.handL, piecePrefab, -1, PieceRenderer.piece_types.GOLD, PieceRenderer.turn.WHITE);
        PieceRenderer.Render(this.handL, piecePrefab, -1, PieceRenderer.piece_types.BISHOP, PieceRenderer.turn.WHITE);
        PieceRenderer.Render(this.handL, piecePrefab, -1, PieceRenderer.piece_types.ROOK, PieceRenderer.turn.WHITE);
    }

    // Update is called once per frame
    void Update() {
    }
}
