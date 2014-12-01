using FullSerializer;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Weapon {
    const string toStringFmt = "{0} {1}"; // {model} {material}
    public WeaponModel model;
    public EquipmentMaterial material;

    [SerializeField]
    public string modelKey {
        get { return model.key; }
        set { model = DataManager.GetWeapon(value); }
    }

    [SerializeField]
    public string materialKey {
        get { return material.key; }
        set { material = DataManager.GetMaterial(value); }
    }

    public override string ToString() {
        return string.Format(toStringFmt, material.name, model.name);
    }
}
