using UnityEngine;
using System.Collections;

public enum CharacterRace {
    Human,
    Orc,
    Elf,
    Dwarf
}

public struct CharacterData {
    public string name;
    public CharacterRace race;
    public int level;
    public int xp;
    public AttributeSet attributes;
    public Feat[] feats;
}
