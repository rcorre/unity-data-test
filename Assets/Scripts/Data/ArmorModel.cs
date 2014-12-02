public enum ArmorSlot {
    Head,
    Hands,
    Torso,
    Legs
}

public class ArmorModel : ItemModel {
    public ArmorSlot slot;
    public ElementSet resistance;
}