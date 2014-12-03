using FullSerializer;

public enum WeaponProperty {
    Reach,
    Finesse,
    Versatile,
    TwoHanded
}

public class EquipmentModel : ItemModel {
    public readonly string slot;
    public readonly int toHit;
    public readonly int armorClass;
    public readonly int magicArmorClass;
    public readonly int resistance;
    public readonly Element element;
    public readonly DiceRoll damage;
    public readonly WeaponProperty[] properties;
}