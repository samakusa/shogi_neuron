using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class EngineConsole : MonoBehaviour {
    public GameObject InputField;
    public GameObject OutputText;
    public GameObject ScrollRect;
    private Engine _Engine;

    private int[] IDX_TT = {
        72, 63, 54, 45, 36, 27, 18,  9, 0,
        73, 64, 55, 46, 37, 28, 19, 10, 1,
        74, 65, 56, 47, 38, 29, 20, 11, 2,
        75, 66, 57, 48, 39, 30, 21, 12, 3,
        76, 67, 58, 49, 40, 31, 22, 13, 4,
        77, 68, 59, 50, 41, 32, 23, 14, 5,
        78, 69, 60, 51, 42, 33, 24, 15, 6,
        79, 70, 61, 52, 43, 34, 25, 16, 7,
        80, 71, 62, 53, 44, 35, 26, 17, 8,
    };

    // Start is called before the first frame update
    void Start() {
        this._Engine = new Engine();
        this._Engine.Initialize();
    }

    // Update is called once per frame
    void Update() {
        string output = this._Engine.Recieve();
        if (output != "") {
            Output(output);
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

    public string KifMove(int src, int dst, bool promote) {
        Exec("user kif " + IDX_TT[src].ToString() + " " + IDX_TT[dst].ToString() + (promote ? " +" : " -"));
        string output = this._Engine.Recieve();
        while (output == "") {
            Thread.Sleep(100);
            output = this._Engine.Recieve();
        }
        Output(output);
        return output.Replace("\n", "");
    }

    public string KifDrop(string piece, int dst) {
        Exec("user kif " + piece + " " + IDX_TT[dst].ToString());
        string output = this._Engine.Recieve();
        while (output == "") {
            Thread.Sleep(100);
            output = this._Engine.Recieve();
        }
        Output(output);
        return output.Replace("\n", "");
    }

    public string SfenMove(int src, int dst, bool promote) {
        Exec("user sfen " + IDX_TT[src].ToString() + " " + IDX_TT[dst].ToString() + (promote ? " +" : " -"));
        string output = this._Engine.Recieve();
        while (output == "") {
            Thread.Sleep(100);
            output = this._Engine.Recieve();
        }
        Output(output);
        return output.Replace("\n", "");
    }

    public string SfenDrop(string piece, int dst) {
        Exec("user sfen " + piece + " " + IDX_TT[dst].ToString());
        string output = this._Engine.Recieve();
        while (output == "") {
            Thread.Sleep(100);
            output = this._Engine.Recieve();
        }
        Output(output);
        return output.Replace("\n", "");
    }

    public bool IsLegalMove(int src, int dst, bool promote) {
        Exec("user islegal " + IDX_TT[src].ToString() + " " + IDX_TT[dst].ToString() + (promote ? " +" : " -"));
        string output = this._Engine.Recieve();
        while (output == "") {
            Thread.Sleep(100);
            output = this._Engine.Recieve();
        }
        Output(output);
        // Assert(output == "t" || output == "f")
        return output[0] == 't' ? true : false;
    }

    public bool IsLegalDrop(string piece, int dst) {
        Exec("user islegal " + piece + " " + IDX_TT[dst].ToString());
        string output = this._Engine.Recieve();
        while (output == "") {
            Thread.Sleep(100);
            output = this._Engine.Recieve();
        }
        Output(output);
        // Assert(output == "t" || output == "f")
        return output[0] == 't' ? true : false;
    }

    public void Position(List<BoardScene.KifElem> Kif) {
        string cmd = "position startpos moves ";
        foreach (var e in Kif) {
            cmd += e.GetSfen() + " ";
        }
        Exec(cmd);
    }

    public void OnDestroy() {
        this._Engine.Send("quit");
    }

    private void Output(string output) {
        this.OutputText.GetComponent<Text>().text += output;
        this.OutputText.GetComponent<ContentSizeFitter>().SetLayoutVertical();
        this.ScrollRect.GetComponent<ScrollRect>().verticalNormalizedPosition = 0;
    }
}
