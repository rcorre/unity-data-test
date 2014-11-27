using System;
using System.Linq;
using System.Collections.Generic;
using FullSerializer;
using UnityEngine;

public enum CharacterAttribute {
    Str,
    Dex,
    Con,
    Int,
    Wis,
    Cha
}

[fsObject(Converter=typeof(AttributeSetConverter))]
public struct AttributeSet {
    public static int NumValues { get { return Enum.GetValues(typeof(CharacterAttribute)).Length; } } 
    private int[] _values;

    public static AttributeSet Empty() {
        var set = new AttributeSet();
        set.Initialize();
        return set;
    }

    public void Initialize() {
        _values = new int[NumValues];
    }

    public int this[CharacterAttribute attr] {
        get { return _values[(int)attr]; }
        set { _values[(int)attr] = value; }
    }
}

public class AttributeSetConverter : fsConverter {
    public override bool CanProcess(Type type) {
        return type == typeof(AttributeSet);
    }

    public override fsFailure TrySerialize(object instance, out fsData serialized, Type storageType) {
        var attrSet = (AttributeSet)instance;

        var dict = new Dictionary<string, fsData>();
	foreach (var attr in Enum.GetValues(typeof(CharacterAttribute)).Cast<CharacterAttribute>()) {
	    dict[attr.ToString()] = new fsData(attrSet[attr]);
	}
        serialized = new fsData(dict);
        return fsFailure.Success;
    }

    public override fsFailure TryDeserialize(fsData storage, ref object instance, Type storageType) {
        // verify json contains expected type
        if (storage.Type != fsDataType.Object) {
            return fsFailure.Fail("Expected object fsData type but got " + storage.Type);
        }

        var attrSet = (AttributeSet)instance;
        var dict = storage.AsDictionary;
        foreach (var kvp in dict) {
            var attr = (CharacterAttribute)Enum.Parse(typeof(CharacterAttribute), kvp.Key, true);
            attrSet[attr] = (int)kvp.Value.AsInt64;
        }
        return fsFailure.Success;
    }

    public override object CreateInstance(fsData data, Type storageType) {
        return AttributeSet.Empty();
    }
}
