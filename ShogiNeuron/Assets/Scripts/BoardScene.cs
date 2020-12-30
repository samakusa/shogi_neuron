using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardScene : MonoBehaviour {
    public GameObject onBoard;
    public GameObject piecePrefab;

    private PieceRenderer PieceRenderer = new PieceRenderer();
    private string begin_board_sfen = "lnsgkgsnl/1r5b1/ppppppppp/9/9/9/PPPPPPPPP/1B5R1/LNSGKGSNL b -";

    private enum piece_types {
        NONE, PORN, LANCE, KNIGHT, SILVER, BISHOP, ROOK, GOLD, KING,
        PORN_PROMOTED, LANCE_PROMOTED, KNIGHT_PROMOTED, SILVER_PROMOTED, BISHOP_PROMOTED, ROOK_PROMOTED,
    };

    // Start is called before the first frame update
    void Start() {
        GameObject piece1 = (GameObject)Instantiate(this.piecePrefab);
        this.PieceRenderer.Render(this.onBoard, piece1, 9, 9, (int)piece_types.LANCE);
        GameObject piece2 = (GameObject)Instantiate(this.piecePrefab);
        this.PieceRenderer.Render(this.onBoard, piece2, 8, 9, (int)piece_types.KNIGHT);
        GameObject piece3 = (GameObject)Instantiate(this.piecePrefab);
        this.PieceRenderer.Render(this.onBoard, piece3, 7, 9, (int)piece_types.SILVER);
        GameObject piece4 = (GameObject)Instantiate(this.piecePrefab);
        this.PieceRenderer.Render(this.onBoard, piece4, 6, 9, (int)piece_types.GOLD);
        GameObject piece5 = (GameObject)Instantiate(this.piecePrefab);
        this.PieceRenderer.Render(this.onBoard, piece5, 5, 9, (int)piece_types.KING);
        GameObject piece6 = (GameObject)Instantiate(this.piecePrefab);
        this.PieceRenderer.Render(this.onBoard, piece6, 4, 9, (int)piece_types.GOLD);
        GameObject piece7 = (GameObject)Instantiate(this.piecePrefab);
        this.PieceRenderer.Render(this.onBoard, piece7, 3, 9, (int)piece_types.SILVER);
        GameObject piece8 = (GameObject)Instantiate(this.piecePrefab);
        this.PieceRenderer.Render(this.onBoard, piece8, 2, 9, (int)piece_types.KNIGHT);
        GameObject piece9 = (GameObject)Instantiate(this.piecePrefab);
        this.PieceRenderer.Render(this.onBoard, piece9, 1, 9, (int)piece_types.LANCE);
        GameObject piece10 = (GameObject)Instantiate(this.piecePrefab);
        this.PieceRenderer.Render(this.onBoard, piece10, 8, 8, (int)piece_types.BISHOP);
        GameObject piece11 = (GameObject)Instantiate(this.piecePrefab);
        this.PieceRenderer.Render(this.onBoard, piece11, 2, 8, (int)piece_types.ROOK);
    }

    // Update is called once per frame
    void Update() {
    }
}
