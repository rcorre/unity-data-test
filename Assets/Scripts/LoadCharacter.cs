using UnityEngine;
using System;

public class LoadCharacter : MonoBehaviour {
    public TextAsset dataFile;

    void Start() {
        JsonApi.AddConverter(new AttributeSetConverter());
        string data = dataFile.text;

        var character = JsonApi.Deserialize<CharacterData>(data);
        Debug.Log(character.name);
        Debug.Log("str = " + character.attributes[CharacterAttribute.Str]);
        Debug.Log("dex = " + character.attributes[CharacterAttribute.Dex]);
        Debug.Log("con = " + character.attributes[CharacterAttribute.Con]);
        Debug.Log("int = " + character.attributes[CharacterAttribute.Int]);
        Debug.Log("wis = " + character.attributes[CharacterAttribute.Wis]);
        Debug.Log("cha = " + character.attributes[CharacterAttribute.Cha]);
        var reSerialize = JsonApi.Serialize(character);
        Debug.Log(reSerialize);
    }
}