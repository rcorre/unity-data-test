using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class DataManager : MonoBehaviour {

    void Start() {
        var talentData = Resources.Load<TextAsset>("talents");
        var characterData = Resources.Load<TextAsset>("characters");
        //_talents = JsonApi.Deserialize<Dictionary<string, TalentData>>(talentData.text);
        _characters = JsonApi.Deserialize<CharacterData[]>(characterData.text);
        var reSerialize = JsonApi.Serialize(_characters);
        Debug.Log(reSerialize);
    }

    private CharacterData[] _characters;
    private Dictionary<string, TalentData> _talents;
}