using UnityEngine;

public class Weapon {
    const string toStringFmt = "{0} {1} ({2}%)"; // {model} {material} ({condition%})

    public WeaponModel model;
    public EquipmentMaterial material;

    private float _condition;
    /// <summary>
    /// condition between 0 (broken) and 1 (perfect)
    /// </summary>
    [SerializeField]
    public float condition {
        get { return _condition; }
        set { _condition = Mathf.Clamp01(value); }
    }

    [SerializeField]
    public string modelKey {
        get { return model.key; }
        set { model = DataManager.Fetch<WeaponModel>(value); }
    }

    [SerializeField]
    public string materialKey {
        get { return material.key; }
        set { material = DataManager.Fetch<EquipmentMaterial>(value); }
    }

    public override string ToString() {
        return string.Format(toStringFmt, material.name, model.name, condition * 100);
    }
}
