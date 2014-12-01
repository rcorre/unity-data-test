using UnityEngine;
using System.Linq;

public class Weapon {
    const string toStringFmt = "{0} {1} ({2}%)"; // {model} {material} ({condition%})

    private float _condition;
    private WeaponModel _model;
    private EquipmentMaterial _material;

    public DiceRoll damage {
        get { return _model.damage * _material.damage[_model.damageType]; }
    }

    public int weight {
        get { return Mathf.FloorToInt(_model.weight * _material.weight); }
    }

    public DamageType damageType { get { return _model.damageType; } }
    public int toHit { get { return _model.toHit; } }
    public int block { get { return _model.block; } }
    public WeaponProperty[] properties { get { return _model.properties ; } }

    public bool HasProperty(WeaponProperty prop) {
        return properties.Contains(prop);
    }

    [SerializeField]
    public string modelKey {
        get { return _model.key; }
        set { _model = DataManager.Fetch<WeaponModel>(value); }
    }

    [SerializeField]
    public string materialKey {
        get { return _material.key; }
        set { _material = DataManager.Fetch<EquipmentMaterial>(value); }
    }

    /// <summary>
    /// condition between 0 (broken) and 1 (perfect)
    /// </summary>
    [SerializeField]
    public float condition {
        get { return _condition; }
        set { _condition = Mathf.Clamp01(value); }
    }

    public override string ToString() {
        return string.Format(toStringFmt, _material.name, _model.name, condition * 100);
    }
}
