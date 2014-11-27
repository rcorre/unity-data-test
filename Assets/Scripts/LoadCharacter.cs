using UnityEngine;
using System;

public class LoadCharacter : MonoBehaviour {
    public TextAsset dataFile;

    void Start() {
        JsonApi.AddConverter(new AttributeSetConverter());
        string data = dataFile.text;

        var character = JsonApi.Deserialize<CharacterData>(data);
        Debug.Log(character.name);
        var reSerialize = JsonApi.Serialize(character);
        Debug.Log(reSerialize);
    }
}