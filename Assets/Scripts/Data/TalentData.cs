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
    public string key; /// <summary> unique id, unchanged even if name changes </summary>
    public string name; /// <summary> name shown in ui </summary>
    public TalentRequirement requirement;
    //costs
    public CharacterAttribute attribute;
    public int apCost;
    public int cooldown;
    public int stamina;
    // trajectory
    public AOEType aoe;
    public int minRange;
    public int maxRange;
    // modifiers
    public int toHitMod;
    // effects
    public int damage;
    public int healing;
    public StatusEffect effect;
}