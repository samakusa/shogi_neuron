using UnityEngine;

public class PieceRenderer {
    private const string PIECE_IMG_DIR = "Images/";
    private string[] piece_names = {
        "",
        "porn",
        "lance",
        "knight",
        "silver",
        "bishop",
        "rook",
        "gold",
        "king",
        "porn_promoted",
        "lance_promoted",
        "knight_promoted",
        "silver_promoted",
        "bishop_promoted",
        "rook_promoted",
    };

    private const float M = 0.39f;
    private const int COL = 0;  // index
    private const int ROW = 1;  // index
    private float[,] POSITIONS = {
        {-4*M, 4*M},{-3*M, 4*M},{-2*M, 4*M},{-1*M, 4*M},{0*M, 4*M},{1*M, 4*M},{2*M, 4*M},{3*M, 4*M},{4*M, 4*M},
        {-4*M, 3*M},{-3*M, 3*M},{-2*M, 3*M},{-1*M, 3*M},{0*M, 3*M},{1*M, 3*M},{2*M, 3*M},{3*M, 3*M},{4*M, 3*M},
        {-4*M, 2*M},{-3*M, 2*M},{-2*M, 2*M},{-1*M, 2*M},{0*M, 2*M},{1*M, 2*M},{2*M, 2*M},{3*M, 2*M},{4*M, 2*M},
        {-4*M, 1*M},{-3*M, 1*M},{-2*M, 1*M},{-1*M, 1*M},{0*M, 1*M},{1*M, 1*M},{2*M, 1*M},{3*M, 1*M},{4*M, 1*M},
        {-4*M, 0*M},{-3*M, 0*M},{-2*M, 0*M},{-1*M, 0*M},{0*M, 0*M},{1*M, 0*M},{2*M, 0*M},{3*M, 0*M},{4*M, 0*M},
        {-4*M,-1*M},{-3*M,-1*M},{-2*M,-1*M},{-1*M,-1*M},{0*M,-1*M},{1*M,-1*M},{2*M,-1*M},{3*M,-1*M},{4*M,-1*M},
        {-4*M,-2*M},{-3*M,-2*M},{-2*M,-2*M},{-1*M,-2*M},{0*M,-2*M},{1*M,-2*M},{2*M,-2*M},{3*M,-2*M},{4*M,-2*M},
        {-4*M,-3*M},{-3*M,-3*M},{-2*M,-3*M},{-1*M,-3*M},{0*M,-3*M},{1*M,-3*M},{2*M,-3*M},{3*M,-3*M},{4*M,-3*M},
        {-4*M,-4*M},{-3*M,-4*M},{-2*M,-4*M},{-1*M,-4*M},{0*M,-4*M},{1*M,-4*M},{2*M,-4*M},{3*M,-4*M},{4*M,-4*M},
    };

    public void Render(GameObject board, GameObject piece, int col, int row, int type, bool is_white=false) {
        int idx = (row - 1) * 9 + (9 - col);
        float x = POSITIONS[idx, COL];
        float y = POSITIONS[idx, ROW];
        piece.transform.SetParent(board.transform, false);
        piece.transform.localPosition = new Vector3(
            x,
            y,
            0f);
        Debug.Log(idx);
        Debug.Log(x);
        Debug.Log(y);

        piece.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(PIECE_IMG_DIR + piece_names[type]);
        if (is_white)
            piece.transform.Rotate(new Vector3(180.0f, 180.0f, 0.0f));
    }

    public void RenderSfen() {
    }
}
