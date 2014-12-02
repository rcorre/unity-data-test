public enum WeaponProperty {
    Reach,
    Finesse,
    Versatile,
    TwoHanded
}

public class WeaponModel : ItemModel {
    public readonly Element damageType;
    public readonly DiceRoll damage;
    public readonly int toHit;
    public readonly int block;
    public readonly WeaponProperty[] properties;
}