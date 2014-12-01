using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;
using FullSerializer;

using TalentStore = System.Collections.Generic.Dictionary<string,TalentData>;
using WeaponStore = System.Collections.Generic.Dictionary<string,WeaponModel>;

public class DataManager : MonoBehaviour {
    void Awake() {
        var talentData = Resources.Load<TextAsset>("talents");
        var characterData = Resources.Load<TextAsset>("characters");
        var weaponData = Resources.Load<TextAsset>("weapons");
        _talents = JsonApi.Deserialize<TalentData[]>(talentData.text).ToDictionary(x => x.key);
        _characters = JsonApi.Deserialize<CharacterData[]>(characterData.text);
        _weapons = JsonApi.Deserialize<WeaponModel[]>(weaponData.text).ToDictionary(x => x.key);
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

    public static WeaponModel GetWeapon(string key) {
        if (_weapons == null) { Debug.LogError("tried to access weapon store before it loaded"); }
        return _weapons[key];
    }

    private static CharacterData[] _characters;
    private static TalentStore _talents;
    private static WeaponStore _weapons;
}