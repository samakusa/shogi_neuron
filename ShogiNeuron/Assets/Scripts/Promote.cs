using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Promote : MonoBehaviour {
    public Button Yes;
    public Button No;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
    }

    public static Promote ShowDialog(GameObject base_obj, Vector3 v, PieceRenderer.piece_types type, UnityAction yes_action, UnityAction no_action) {
        var obj = GameObject.Instantiate((GameObject)Resources.Load("Prefab/Promote"));
        obj.transform.SetParent(base_obj.transform, false);
        obj.transform.localPosition = v;
        var dialog = obj.GetComponent<Promote>();
        dialog.Yes.onClick.AddListener(() => OnClick(dialog, yes_action));
        dialog.Yes.GetComponent<Image>().sprite = Resources.Load<Sprite>(PieceRenderer.PIECE_IMG_DIR + PieceRenderer.piece_names[(int)type + PieceRenderer.PROMOTE]);
        dialog.No.onClick.AddListener(() => OnClick(dialog, no_action));
        dialog.No.GetComponent<Image>().sprite = Resources.Load<Sprite>(PieceRenderer.PIECE_IMG_DIR + PieceRenderer.piece_names[(int)type]);
        return dialog;
    }

    private static void OnClick(Promote dialog, UnityAction action) {
        action();
        Destroy(dialog.gameObject);
    }
}
