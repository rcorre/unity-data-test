using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PrintSomeData : MonoBehaviour {

    // Use this for initialization
    void Start() {
        var character = DataManager.GetCharacter("Myron");
        var textBox = GetComponent<Text>();
        textBox.text = "";
        textBox.text += character.name + "\n";
        textBox.text += character.feats[0].name + "\n";
        textBox.text += character.feats[0].talents[0].rank + "\n";
        textBox.text += character.feats[2].talents[1].data.statusEffect + "\n";
        textBox.text += character.archetypes[1].feats[1];
    }
}
