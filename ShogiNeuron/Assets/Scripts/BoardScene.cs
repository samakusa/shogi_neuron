using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardScene : MonoBehaviour {
    public GameObject onBoard;
    public GameObject piecePrefab;

    private PieceRenderer PieceRenderer;
    private string begin_board_sfen = "lnsgkgsnl/1r5b1/ppppppppp/9/9/9/PPPPPPPPP/1B5R1/LNSGKGSNL b -";

    private const float M = 0.3525f;
    private const int COL = 0;  // index
    private const int ROW = 1;  // index
    private float[,] p = {
        {-4*M,-4*M},{-3*M,-4*M},{-2*M,-4*M},{-1*M,-4*M},{0*M,-4*M},{1*M,-4*M},{2*M,-4*M},{3*M,-4*M},{4*M,-4*M},
        {-4*M,-3*M},{-3*M,-3*M},{-2*M,-3*M},{-1*M,-3*M},{0*M,-3*M},{1*M,-3*M},{2*M,-3*M},{3*M,-3*M},{4*M,-3*M},
        {-4*M,-2*M},{-3*M,-2*M},{-2*M,-2*M},{-1*M,-2*M},{0*M,-2*M},{1*M,-2*M},{2*M,-2*M},{3*M,-2*M},{4*M,-2*M},
        {-4*M,-1*M},{-3*M,-1*M},{-2*M,-1*M},{-1*M,-1*M},{0*M,-1*M},{1*M,-1*M},{2*M,-1*M},{3*M,-1*M},{4*M,-1*M},
        {-4*M, 0*M},{-3*M, 0*M},{-2*M, 0*M},{-1*M, 0*M},{0*M, 0*M},{1*M, 0*M},{2*M, 0*M},{3*M, 0*M},{4*M, 0*M},
        {-4*M, 1*M},{-3*M, 1*M},{-2*M, 1*M},{-1*M, 1*M},{0*M, 1*M},{1*M, 1*M},{2*M, 1*M},{3*M, 1*M},{4*M, 1*M},
        {-4*M, 2*M},{-3*M, 2*M},{-2*M, 2*M},{-1*M, 2*M},{0*M, 2*M},{1*M, 2*M},{2*M, 2*M},{3*M, 2*M},{4*M, 2*M},
        {-4*M, 3*M},{-3*M, 3*M},{-2*M, 3*M},{-1*M, 3*M},{0*M, 3*M},{1*M, 3*M},{2*M, 3*M},{3*M, 3*M},{4*M, 3*M},
        {-4*M, 4*M},{-3*M, 4*M},{-2*M, 4*M},{-1*M, 4*M},{0*M, 4*M},{1*M, 4*M},{2*M, 4*M},{3*M, 4*M},{4*M, 4*M},
    };

    private enum piece_types {
        NONE, PORN, LANCE, KNIGHT, SILVER, BISHOP, ROOK, GOLD, KING,
        PORN_PROMOTED, LANCE_PROMOTED, KNIGHT_PROMOTED, SILVER_PROMOTED, BISHOP_PROMOTED, ROOK_PROMOTED,
    };

    // Start is called before the first frame update
    void Start() {
        this.PieceRenderer = new PieceRenderer();
        this.PieceRenderer.Render(this.onBoard, this.piecePrefab, 0, 0, (int)piece_types.LANCE);
    }

    // Update is called once per frame
    void Update() {
    }
}
