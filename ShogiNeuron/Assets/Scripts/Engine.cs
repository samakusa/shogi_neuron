using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Engine {
    public delegate void OutputHander(object sender, DataReceivedEventArgs e);
    private Process _Engine;
    private string _Output = "";

    // Start is called before the first frame update
    public void Initialize() {
        this._Engine = new Process();
        this._Engine.StartInfo.FileName = System.IO.Directory.GetCurrentDirectory() + "\\Assets\\Resources\\Engine\\shogi_neuron.exe";
        this._Engine.StartInfo.RedirectStandardInput = true;
        this._Engine.StartInfo.RedirectStandardOutput = true;
        this._Engine.StartInfo.UseShellExecute = false;
        this._Engine.StartInfo.CreateNoWindow = true;
        this._Engine.OutputDataReceived += new DataReceivedEventHandler(Output);
        this._Engine.Start();
        this._Engine.BeginOutputReadLine();
    }

    public void Send(string input) {
        this._Engine.StandardInput.WriteLine(input);
    }

    public string Recieve() {
        string output = (string)this._Output.Clone();
        this._Output = "";
        return output;
    }

    private void Output(object sender, DataReceivedEventArgs e) {
        this._Output += e.Data.ToString() + "\n";
    }

    public void Quit() {
    }
}
