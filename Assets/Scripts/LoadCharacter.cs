using UnityEngine;
using System;

public class LoadCharacter : MonoBehaviour {
    public TextAsset dataFile;

    void Start() {
        string data = dataFile.text;
        Debug.Log(data);

        var character = JsonApi.Deserialize<CharacterData>(data);
        Debug.Log(character.name);
        Debug.Log(character.hp);
        var reSerialize = JsonApi.Serialize(character);
        Debug.Log(reSerialize);
    }
}