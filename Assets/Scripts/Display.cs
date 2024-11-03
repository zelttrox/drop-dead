using UnityEngine;
using UnityEngine.UI;

public class DebugCanvas : MonoBehaviour {

    public Text textElement;
    public Text textElement2;
    public Text textElement3;

    // Function used to print text to UI
    void PrintText(string pretext, string text, Text textObject) {
        textObject.text = (pretext + ": " + text);
    }

    void Update() {
    }
}
