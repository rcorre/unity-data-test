using UnityEngine;
using System.Linq;

public class Equipment {
    const string toStringFmt = "{0} {1}"; // {model} {material}

    private EquipmentModel _model;
    private EquipmentMaterial _material;

    public ElementSet resistance { get; private set; }

    public DiceRoll damage {
        get { return _model.damage * _material.damage[_model.element]; }
    }

    public int weight {
        get { return Mathf.FloorToInt(_model.weight * _material.weight); }
    }

    public Element element { get { return _model.element; } }

    public int toHit { get { return _model.toHit; } }

    public int armorClass { get { return Mathf.FloorToInt(_model.armorClass * _material.armorClass); } }
    public int magicArmorClass { get { return Mathf.FloorToInt(_model.magicArmorClass * _material.magicArmorClass); } }

    public WeaponProperty[] properties { get { return _model.properties ; } }

    public bool HasProperty(WeaponProperty prop) {
        return properties.Contains(prop);
    }

    [SerializeField]
    public string modelKey {
        get { return _model.key; }
        set { 
            _model = DataManager.Fetch<EquipmentModel>(value);
            TryInit();
        }
    }

    [SerializeField]
    public string materialKey {
        get { return _material.key; }
        set { 
            _material = DataManager.Fetch<EquipmentMaterial>(value);
            TryInit();
        }
    }

    public override string ToString() {
        return string.Format(toStringFmt, _material.name, _model.name);
    }

    private void TryInit() {
        if (_material == null || _model == null) {
            return;
        }
        resistance = new ElementSet();
	foreach(var el in ElementSet.EnumKeys) {
	    resistance[el] = (int)(_model.resistance * _material.resist[el]);
	}
        resistance = new ElementSet();
	foreach(var el in ElementSet.EnumKeys) {
	    resistance[el] = (int)(_model.resistance * _material.resist[el]);
	}
    }
}
