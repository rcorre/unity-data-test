public enum DamageType {
    Slash,
    Crush,
    Pierce,
    Fire,
    Ice,
    Electric,
    Earth,
    Dark,
    Light,
    Mind,
    Force
}

public enum WeaponProperty {
    Reach,
    Finesse,
    Versatile,
    TwoHanded
}

public class WeaponModel : EquipmentModel {
    public readonly DamageType damageType;
    public readonly DiceRoll damage;
    public readonly int toHit;
    public readonly int block;
    public readonly WeaponProperty[] properties;
}