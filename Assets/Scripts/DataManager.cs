using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;
using FullSerializer;

using TalentStore = System.Collections.Generic.Dictionary<string,TalentData>;

public class DataManager : MonoBehaviour {
    void Awake() {
        var talentData = Resources.Load<TextAsset>("talents");
        var characterData = Resources.Load<TextAsset>("characters");
        _talents = JsonApi.Deserialize<TalentData[]>(talentData.text).ToDictionary(x => x.key);
        _characters = JsonApi.Deserialize<CharacterData[]>(characterData.text);
    }

    // right now doing linear search for name
    // probably wont need to do this for actual game uses
    public static CharacterData GetCharacter(string name) {
        return _characters.First(x => x.name == name);
    }

    public static TalentData GetTalent(string key) {
        if (_talents == null) { Debug.LogError("tried to access talent store before it loaded"); }
        return _talents[key];
    }

    private static CharacterData[] _characters;
    private static TalentStore _talents;
}