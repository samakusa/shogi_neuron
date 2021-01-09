using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Promote : MonoBehaviour {
    public Button Yes;
    public Button No;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
    }

    public static Promote ShowDialog(GameObject base_obj, Vector3 v/*, string promote_img, string no_promote_img*/) {
        var obj = GameObject.Instantiate((GameObject)Resources.Load("Prefab/Promote"));
        obj.transform.SetParent(base_obj.transform, false);
        obj.transform.localPosition = v;
        var dialog = obj.GetComponent<Promote>();
        dialog.Yes.onClick.AddListener(() => Destroy(dialog.gameObject));
        //handler.Yes.GetComponent<Image>().sprite = Resources.Load<Sprite>(promote_img);
        dialog.No.onClick.AddListener(() => Destroy(dialog.gameObject));
        //handler.No.GetComponent<Image>().sprite = Resources.Load<Sprite>(no_promote_img);
        return dialog;
    }
}
