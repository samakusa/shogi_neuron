using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBoard : MonoBehaviour {
    private GameObject Canvas;
    private GameObject BoardSceneObj;
    private BoardScene BoardScene_;

    // Start is called before the first frame update
    void Start() {
        this.Canvas = GameObject.Find("Canvas");
        this.BoardSceneObj = GameObject.Find("BoardScene");
        this.BoardScene_ = this.BoardSceneObj.GetComponent<BoardScene>();
    }

    // Update is called once per frame
    void Update() {
    }

    public void Tap() {
        if (this.BoardScene_.GetStatus() == BoardScene.STATUS.NORMAL)
            return;
        else if (this.BoardScene_.GetStatus() == BoardScene.STATUS.MOVE) {
            Vector3 m = Input.mousePosition;
            Vector2 c = this.Canvas.GetComponent<RectTransform>().sizeDelta;
            Vector3 v = new Vector3(m.x - c.x / 2, m.y - c.y / 2, 0.0f);
            this.BoardScene_.Move(v);
        }
        else if (this.BoardScene_.GetStatus() == BoardScene.STATUS.DROP) {
            Vector3 m = Input.mousePosition;
            Vector2 c = this.Canvas.GetComponent<RectTransform>().sizeDelta;
            Vector3 v = new Vector3(m.x - c.x / 2, m.y - c.y / 2, 0.0f);
            this.BoardScene_.Drop(v);
        }
        else if (this.BoardScene_.GetStatus() == BoardScene.STATUS.PROMOTE) {
        }
        else {
            // Assert(true);
        }
    }
}
