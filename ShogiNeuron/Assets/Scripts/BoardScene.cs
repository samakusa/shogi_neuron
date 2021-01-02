﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardScene : MonoBehaviour {
    public GameObject onBoard;
    public GameObject[] BlackHandPieces;
    public GameObject[] WhiteHandPieces;
    public GameObject piecePrefab;

    private PieceRenderer PieceRenderer = new PieceRenderer();
    private List<GameObject> Pieces = new List<GameObject>();
    private string begin_board_sfen = "lnsgkgsnl/1r5b1/ppppppppp/9/9/9/PPPPPPPPP/1B5R1/LNSGKGSNL b -";

    private bool IsPieceSelected = false;

    // Start is called before the first frame update
    void Start() {
        PieceRenderer.RenderSfen(this.onBoard, this.piecePrefab, this.begin_board_sfen, this.Pieces);
        PieceRenderer.AddHand(BlackHandPieces, PieceRenderer.piece_types.PORN);
        PieceRenderer.AddHand(WhiteHandPieces, PieceRenderer.piece_types.LANCE);
        PieceRenderer.AddHand(WhiteHandPieces, PieceRenderer.piece_types.LANCE);
        PieceRenderer.SubHand(BlackHandPieces, PieceRenderer.piece_types.PORN);
        PieceRenderer.SubHand(WhiteHandPieces, PieceRenderer.piece_types.LANCE);
    }

    // Update is called once per frame
    void Update() {
    }
}
