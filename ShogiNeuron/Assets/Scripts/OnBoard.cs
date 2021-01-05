using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBoard : MonoBehaviour {
    private GameObject Canvas;
    private GameObject BoardScene;

    // Start is called before the first frame update
    void Start() {
        this.Canvas = GameObject.Find("Canvas");
        this.BoardScene = GameObject.Find("BoardScene");
    }

    // Update is called once per frame
    void Update() {
    }

    public void Tap() {
        BoardScene boardScene = this.BoardScene.GetComponent<BoardScene>();
        if (!this.BoardScene.GetComponent<BoardScene>().GetIsPieceSelected())
            return;
        Vector3 m = Input.mousePosition;
        Vector2 c = this.Canvas.GetComponent<RectTransform>().sizeDelta;
        Vector3 v = new Vector3(m.x - c.x/2, m.y - c.y/2, 0.0f);
        boardScene.Move(v);
        boardScene.SetIsPieceSelected(false);
    }
}
