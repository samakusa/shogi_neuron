using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardScene : MonoBehaviour {
    public GameObject piecePrefab;
    public GameObject onBoard;

    // Start is called before the first frame update
    void Start() {
        GameObject piece = (GameObject)Instantiate(piecePrefab);
        piece.transform.SetParent(this.onBoard.transform, false);
        piece.transform.localPosition = new Vector3(
            0f,
            0f,
            0f);
    }

    // Update is called once per frame
    void Update() {
    }
}
