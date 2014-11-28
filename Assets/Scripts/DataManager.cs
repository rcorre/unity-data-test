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
        Debug.Log(_characters[0].name);
        Debug.Log(_characters[0].feats.Length);
        Debug.Log(_characters[0].feats[0].name);
        Debug.Log(_characters[0].feats[0].talents[0].rank);
        Debug.Log(_characters[0].feats[2].talents[1].data.statusEffect);
        Debug.Log(_characters[0].archetypes[1].feats[1]);
    }

    public static TalentData GetTalent(string key) {
        if (_talents == null) { Debug.LogError("tried to access talent store before it loaded"); }
        return _talents[key];
    }

    private static CharacterData[] _characters;
    private static TalentStore _talents;
}