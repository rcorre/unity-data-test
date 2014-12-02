using UnityEngine;
using System.Linq;

public class Armor {
    const string toStringFmt = "{0} {1}"; // {model} {material}

    private ArmorModel _model;
    private EquipmentMaterial _material;

    public int weight {
        get { return Mathf.FloorToInt(_model.weight * _material.weight); }
    }

    public int resistanceTo(Element element) {
        return _model.resistance[element];
    }

    [SerializeField]
    public string modelKey {
        get { return _model.key; }
        set { _model = DataManager.Fetch<ArmorModel>(value); }
    }

    [SerializeField]
    public string materialKey {
        get { return _material.key; }
        set { _material = DataManager.Fetch<EquipmentMaterial>(value); }
    }

    public override string ToString() {
        return string.Format(toStringFmt, _material.name, _model.name);
    }
}
