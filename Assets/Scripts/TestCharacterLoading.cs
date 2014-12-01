using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class TestCharacterLoading : MonoBehaviour {
    const string fmt = "{0}: {1}\n"; // how to format printed data
    public Font font;

    void OnGui() {
        GUI.skin.font = font;
    }

    // Use this for initialization
    void Start() {
        var character = DataManager.Fetch<CharacterData>("Myron");
        string output =
            string.Format(fmt, "name", character.name) +
            string.Format(fmt, "race", character.race) +
            string.Format(fmt, "dex", character.attributes[CharacterAttribute.Dex]) +
            string.Format(fmt, "archetypes[0]", character.archetypes[0].name) +
            string.Format(fmt, "archetypes[0].feats[0]", character.archetypes[0].feats[0]) +
            string.Format(fmt, "feats[0]", character.feats[0].name) +
            string.Format(fmt, "feats[0].talents[0]", character.feats[0].talents[0].data.name) +
            string.Format(fmt, "feats[0].talents[0].apCost", character.feats[0].talents[0].data.apCost) +
            string.Format(fmt, "mainHand", character.mainHand.ToString()) +
            string.Format(fmt, "offHand", character.offHand.ToString());
        Debug.Log(output);
        var textBox = GetComponent<Text>();
        textBox.text = "Character Test:\n" + output;
    }
}
