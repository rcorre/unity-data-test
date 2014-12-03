using System;
using System.Linq;
using System.Collections.Generic;
using FullSerializer;

public class EquipmentMaterial {
    public string key;
    public string name;
    public float weight;
    public float armorClass;
    public float magicArmorClass;
    /// <summary>
    /// multiplies damage for the corresponding element
    /// </summary>
    public ElementMultiplier damage;
    /// <summary>
    /// multiplies resistance for the corresponding element
    /// </summary>
    public ElementMultiplier resist;
}
