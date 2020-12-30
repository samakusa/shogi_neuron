using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceRenderer : MonoBehaviour
{
    private const string PIECE_IMG_DIR = "Images/";
    private string[] piece_names = {
        "",
        "porn",
        "lance",
        "knight",
        "silver",
        "bishop",
        "rook",
        "porn_promoted",
        "lance_promoted",
        "knight_promoted",
        "silver_promoted",
        "bishop_promoted",
        "rook_promoted",
        "gold",
        "king",
    };

    public void Render(GameObject board, GameObject basePiece, int col, int row, int type) {
        GameObject piece = (GameObject)Instantiate(basePiece);
        piece.transform.SetParent(board.transform, false);
        piece.transform.localPosition = new Vector3(
            0f,
            0f,
            0f);

        piece.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(PIECE_IMG_DIR + piece_names[type]);
    }

    public void RenderSfen() {
    }
}
