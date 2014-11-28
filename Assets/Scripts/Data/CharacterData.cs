using UnityEngine;
using System.Collections;

public enum CharacterRace {
    Human,
    Orc,
    Elf,
    Dwarf
}

public struct CharacterData {
    public readonly string name;
    public readonly CharacterRace race;
    public readonly int level;
    public readonly int xp;
    public readonly AttributeSet attributes;
    public Feat[] feats;
}
