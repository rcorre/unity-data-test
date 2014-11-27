using FullSerializer;
using System.Collections.Generic;

public enum TalentRequirement {
    Melee, // any melee weapon
    Unarmed,
    Blade,
    Blunt,
    Piercing,
    Shield,
    Ranged, // any ranged weapon
    Bow,
    Gun,
    Thrown,
    Magic, // any magic weapon
    Force,
    Mind,
    Shout
}

public enum StatusEffect {
    Bleeding,
    Burning,
    Poison,
    Cripple,
    Blind,
    Slow,
    Fatigue
}

public enum AOEType {
    Single,
    Burst,
    Cone,
    Line,
    Blast
}

public class TalentData {
    public string name; /// <summary> name shown in ui </summary>
    TalentRequirement requirement;
    //costs
    CharacterAttribute attribute;
    public int apCost;
    public int cooldown;
    public int stamina;
    // trajectory
    AOEType aoe;
    public int minRange;
    public int maxRange;
    // modifiers
    int toHitMod;
    // effects
    int damage;
    int healing;
    StatusEffect effect;
}