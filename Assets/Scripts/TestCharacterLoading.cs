using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TestCharacterLoading : MonoBehaviour {
    public Font font;

    void OnGui() {
        GUI.skin.font = font;
    }

    // Use this for initialization
    void Start() {
        var character = DataManager.GetCharacter("Myron");
        Debug.Log(character.name);
        Debug.Log(character.feats[0].name);
        Debug.Log(character.feats[0].talents[0].rank);
        Debug.Log(character.feats[2].talents[1].data.statusEffect);
        Debug.Log(character.archetypes[1].feats[1]);
        var textBox = GetComponent<Text>();
        textBox.text = "Character Test:\n";
        textBox.text += character.name + "\n";
        textBox.text += character.feats[0].name + "\n";
        textBox.text += character.feats[0].talents[0].rank + "\n";
        textBox.text += character.feats[2].talents[1].data.statusEffect + "\n";
        textBox.text += character.archetypes[1].feats[1];
    }
}
