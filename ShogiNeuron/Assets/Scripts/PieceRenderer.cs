using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PieceRenderer {
    public enum piece_types {
        NONE, PORN, LANCE, KNIGHT, SILVER, BISHOP, ROOK, GOLD, KING,
        PORN_PROMOTED, LANCE_PROMOTED, KNIGHT_PROMOTED, SILVER_PROMOTED, BISHOP_PROMOTED, ROOK_PROMOTED,
    };

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

    public enum turn {
        BLACK,
        WHITE,
    }

    private const float SCALE_X = 0.2f;
    private const float SCALE_Y = 0.2f;
    private const float M = 63.0f;  // margin
    private const int COL = 0;  // index
    private const int ROW = 1;  // index
    private const int MAX_IDX = 80;
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
    };  // OnBoard base

    public void Render(GameObject base_obj, GameObject piecePrefab, int idx, piece_types type, turn turn) {
        float x = POSITIONS[idx, COL];
        float y = POSITIONS[idx, ROW];
        float scale_x = SCALE_X;
        float scale_y = SCALE_Y;
        Render(base_obj, piecePrefab, x, y, scale_x, scale_y, type, turn);
    }

    public void Render(GameObject base_obj, GameObject piecePrefab, float x, float y, float scale_x, float scale_y, piece_types type, turn turn) {
        GameObject piece = Object.Instantiate(piecePrefab);
        piece.transform.SetParent(base_obj.transform, false);
        piece.transform.localPosition = new Vector3(x, y);
        piece.transform.localScale = new Vector3(scale_x, scale_y);

        piece.GetComponent<Piece>().SetPieceType(type);
        piece.GetComponent<Piece>().SetTurn(turn);
        piece.GetComponent<Image>().sprite = Resources.Load<Sprite>(PIECE_IMG_DIR + piece_names[(int)type]);
        if (turn == turn.WHITE)
            piece.transform.Rotate(new Vector3(180.0f, 180.0f, 0.0f));
    }

    public void Move(GameObject src, Vector3 dst) {
        if (dst.x < POSITIONS[0, COL] - M / 2 || dst.x > POSITIONS[MAX_IDX, COL] + M / 2 ||
            dst.y > POSITIONS[0, ROW] + M / 2 || dst.y < POSITIONS[MAX_IDX, ROW] - M / 2)
            return;

        for (int i = 0; i <= MAX_IDX; i++) {
            if (dst.x >= POSITIONS[i, COL] - M / 2 && dst.x <= POSITIONS[i, COL] + M / 2 &&
                dst.y >= POSITIONS[i, ROW] - M / 2 && dst.y <= POSITIONS[i, ROW] + M / 2) {
                src.transform.localPosition = new Vector3(POSITIONS[i, COL], POSITIONS[i, ROW], 0.0f);
                break;
            }
        }
    }

    public void Capture(GameObject cap, GameObject[] hand_pieces, piece_types type) {
        GameObject.Destroy(cap);
        AddHand(hand_pieces, type);
    }

    public void AddHand(GameObject[] pieces, piece_types type) {
        GameObject piece = pieces[(int)type];
        Text text = piece.GetComponentInChildren<Text>();
        int c = -1; int.TryParse(text.text, out c); // Assert(c != -1)
        if (c == 0)
            piece.SetActive(true);
        text.text = (c + 1).ToString();
    }

    public void SubHand(GameObject[] pieces, piece_types type) {    // substitute
        GameObject piece = pieces[(int)type];
        Text text = piece.GetComponentInChildren<Text>();
        int c = -1; int.TryParse(text.text, out c); // Assert(c != -1)
        text.text = (c - 1).ToString(); // Assert(c - 1 >= 0)
        if (c - 1 == 0)
            piece.SetActive(false);
    }

    public void RenderSfen(GameObject board, GameObject piecePrefab, string sfen) {
        int idx = 0;
        string p = "";
        foreach (var c in sfen) {
            turn t;
            piece_types type = piece_types.NONE;
            int i;
            p += c;

            if (int.TryParse(p, out i)) {
                idx += i;
                p = "";
                continue;
            }
            else if (p == "/") {
                // Assert(idx % 9 == 8)
                p = "";
                continue;
            }
            else if (p == "+") {
                continue;
            }
            else if (p == " ") {
                break;
            }
            else if (p == "P") {
                type = piece_types.PORN;
                t = turn.BLACK;
            }
            else if (p == "L") {
                type = piece_types.LANCE;
                t = turn.BLACK;
            }
            else if (p == "N") {
                type = piece_types.KNIGHT;
                t = turn.BLACK;
            }
            else if (p == "S") {
                type = piece_types.SILVER;
                t = turn.BLACK;
            }
            else if (p == "B") {
                type = piece_types.BISHOP;
                t = turn.BLACK;
            }
            else if (p == "R") {
                type = piece_types.ROOK;
                t = turn.BLACK;
            }
            else if (p == "G") {
                type = piece_types.GOLD;
                t = turn.BLACK;
            }
            else if (p == "K") {
                type = piece_types.KING;
                t = turn.BLACK;
            }
            else if (p == "+P") {
                type = piece_types.PORN_PROMOTED;
                t = turn.BLACK;
            }
            else if (p == "+L") {
                type = piece_types.LANCE_PROMOTED;
                t = turn.BLACK;
            }
            else if (p == "+N") {
                type = piece_types.KNIGHT_PROMOTED;
                t = turn.BLACK;
            }
            else if (p == "+S") {
                type = piece_types.SILVER_PROMOTED;
                t = turn.BLACK;
            }
            else if (p == "+B") {
                type = piece_types.BISHOP_PROMOTED;
                t = turn.BLACK;
            }
            else if (p == "+R") {
                type = piece_types.ROOK_PROMOTED;
                t = turn.BLACK;
            }
            else if (p == "p") {
                type = piece_types.PORN;
                t = turn.WHITE;
            }
            else if (p == "l") {
                type = piece_types.LANCE;
                t = turn.WHITE;
            }
            else if (p == "n") {
                type = piece_types.KNIGHT;
                t = turn.WHITE;
            }
            else if (p == "s") {
                type = piece_types.SILVER;
                t = turn.WHITE;
            }
            else if (p == "b") {
                type = piece_types.BISHOP;
                t = turn.WHITE;
            }
            else if (p == "r") {
                type = piece_types.ROOK;
                t = turn.WHITE;
            }
            else if (p == "g") {
                type = piece_types.GOLD;
                t = turn.WHITE;
            }
            else if (p == "k") {
                type = piece_types.KING;
                t = turn.WHITE;
            }
            else if (p == "+p") {
                type = piece_types.PORN_PROMOTED;
                t = turn.WHITE;
            }
            else if (p == "+l") {
                type = piece_types.LANCE_PROMOTED;
                t = turn.WHITE;
            }
            else if (p == "+n") {
                type = piece_types.KNIGHT_PROMOTED;
                t = turn.WHITE;
            }
            else if (p == "+s") {
                type = piece_types.SILVER_PROMOTED;
                t = turn.WHITE;
            }
            else if (p == "+b") {
                type = piece_types.BISHOP_PROMOTED;
                t = turn.WHITE;
            }
            else if (p == "+r") {
                type = piece_types.ROOK_PROMOTED;
                t = turn.WHITE;
            }
            else {
                // Assert(true);
                p = "";
                continue;
            }

            Render(board, piecePrefab, idx, type, t);
            p = ""; idx++;
        }
    }
}
