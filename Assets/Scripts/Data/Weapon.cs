public struct Weapon {
    public WeaponModel model;
    public EquipmentMaterial material;

    public string modelKey {
        get { return model.key; }
        set { model = DataManager.GetWeapon(value); }
    }

    public string materialKey {
        get { return material.key; }
        set { material = DataManager.GetMaterial(value); }
    }
}
