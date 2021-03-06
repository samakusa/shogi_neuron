using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FurigomaScene : MonoBehaviour {

    public GameObject[] Pawns;
    private const int PAWNS_LEN = 5;

    private const string PIECE_IMG_DIR = "Images/";

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
    }

    public void Furigoma() {
        for (int i = 0; i < PAWNS_LEN; i++)
            Furu(this.Pawns[i]);
    }

    private void Furu(GameObject pawn) {
        const int FRONT = 0;
        const int BACK  = 1;
        int side = Random.Range(FRONT, BACK + 1);

        if (side == FRONT)
            pawn.GetComponent<Image>().sprite = Resources.Load<Sprite>(PIECE_IMG_DIR + "pawn");
        else if (side == BACK)
            pawn.GetComponent<Image>().sprite = Resources.Load<Sprite>(PIECE_IMG_DIR + "pawn_promoted");
        else {
            // Assert(true);
        }
    }
}
