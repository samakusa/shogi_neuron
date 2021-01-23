using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EngineConsole : MonoBehaviour {
    public GameObject InputField;
    public GameObject OutputText;
    public GameObject ScrollRect;
    private Engine _Engine;

    // Start is called before the first frame update
    void Start() {
        this._Engine = new Engine();
        this._Engine.Initialize();
    }

    // Update is called once per frame
    void Update() {
        string output = this._Engine.Recieve();
        if (output != "") {
            this.OutputText.GetComponent<Text>().text += output;
            this.OutputText.GetComponent<ContentSizeFitter>().SetLayoutVertical();
            this.ScrollRect.GetComponent<ScrollRect>().verticalNormalizedPosition = 0;
        }
    }

    public void Enter() {
        string input = this.InputField.GetComponent<InputField>().text;
        Exec(input);
        this.InputField.GetComponent<InputField>().text = "";
        this.InputField.GetComponent<InputField>().ActivateInputField();
    }

    public void Exec(string input) {
        this.OutputText.GetComponent<Text>().text += "> " + input + "\n";
        this._Engine.Send(input);
    }

    public void OnDestroy() {
        this._Engine.Send("quit");
    }
}
