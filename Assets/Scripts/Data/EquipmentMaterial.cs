using System;
using System.Linq;
using System.Collections.Generic;
using FullSerializer;

[fsObject(Converter=typeof(MaterialConverter))]
public class EquipmentMaterial {
    public string key;
    public float durability;
    public float weight;
    public Dictionary<DamageType, float> damage;
}

public class MaterialConverter : fsConverter {
    public override bool CanProcess(Type type) {
        return type == typeof(AttributeSet);
    }

    public override fsFailure TrySerialize(object instance, out fsData serialized, Type storageType) {
        var mat = (EquipmentMaterial)instance;

	var dict = new Dictionary<string, fsData>();
	var dmgMap = mat.damage.ToDictionary(x => x.Key.ToString(), x => new fsData(x.Value));
	dict["key"]        = new fsData(mat.key);
	dict["durability"] = new fsData(mat.durability);
	dict["damage"]     = new fsData(dmgMap);
	serialized         = new fsData(dict);
        return fsFailure.Success;
    }

    public override fsFailure TryDeserialize(fsData storage, ref object instance, Type storageType) {
        // verify json contains expected type
        if (storage.Type != fsDataType.Object) {
            return fsFailure.Fail("Expected object fsData type but got " + storage.Type);
        }

        var mat = (EquipmentMaterial)instance;
        var dict = storage.AsDictionary;
        var dmgMap = dict["damage"].AsDictionary;

        mat.key        = dict["key"].AsString;
        mat.durability = (float)dict["durability"].AsDouble;
        mat.weight     = (float)dict["weight"].AsDouble;
        mat.damage = dmgMap.ToDictionary(
            x => (DamageType)Enum.Parse(typeof(DamageType), x.Key), 
            x => (float)x.Value.AsDouble);
        return fsFailure.Success;
    }

    public override object CreateInstance(fsData data, Type storageType) {
        return new EquipmentMaterial();
    }
}