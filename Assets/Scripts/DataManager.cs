using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;
using FullSerializer;

using TalentStore = System.Collections.Generic.Dictionary<string,TalentData>;

public class DataManager : MonoBehaviour {
    void Start() {
        var talentData = Resources.Load<TextAsset>("talents");
        var characterData = Resources.Load<TextAsset>("characters");
        _talents = JsonApi.Deserialize<TalentData[]>(talentData.text).ToDictionary(x => x.key);
        _characters = JsonApi.Deserialize<CharacterData[]>(characterData.text);
    }

    static TalentData GetTalent(string key) {
        if (_talents == null) { Debug.LogError("tried to access talent store before it loaded"); }
        return _talents[key];
    }

    private static CharacterData[] _characters;
    private static TalentStore _talents;
}