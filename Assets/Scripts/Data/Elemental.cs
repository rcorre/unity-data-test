using System;
using System.Linq;
using System.Collections.Generic;
using FullSerializer;
using UnityEngine;

public enum Element {
    Slash,
    Crush,
    Pierce,
    Fire,
    Ice,
    Electric,
    Earth,
    Dark,
    Light,
    Mind,
    Force
}

[fsObject(Converter=typeof(ElementConverter))]
public struct ElementSet {
    public static int NumValues { get { return Enum.GetValues(typeof(Element)).Length; } } 
    private int[] _values;

    public static ElementSet Empty() {
        var set = new ElementSet();
        set.Initialize();
        return set;
    }

    public void Initialize() {
        _values = new int[NumValues];
    }

    public int this[Element attr] {
        get { return _values[(int)attr]; }
        set { _values[(int)attr] = value; }
    }
}

public class ElementConverter : fsConverter {
    public override bool CanProcess(Type type) {
        return type == typeof(ElementSet);
    }

    public override fsFailure TrySerialize(object instance, out fsData serialized, Type storageType) {
        var elementSet = (ElementSet)instance;

        var dict = new Dictionary<string, fsData>();
	foreach (var attr in Enum.GetValues(typeof(Element)).Cast<Element>()) {
	    dict[attr.ToString()] = new fsData(elementSet[attr]);
	}
        serialized = new fsData(dict);
        return fsFailure.Success;
    }

    public override fsFailure TryDeserialize(fsData storage, ref object instance, Type storageType) {
        // verify json contains expected type
        if (storage.Type != fsDataType.Object) {
            return fsFailure.Fail("Expected object fsData type but got " + storage.Type);
        }

        var elementSet = (ElementSet)instance;
        var dict = storage.AsDictionary;
        foreach (var kvp in dict) {
            var attr = (Element)Enum.Parse(typeof(Element), kvp.Key, true);
            elementSet[attr] = (int)kvp.Value.AsInt64;
        }
        return fsFailure.Success;
    }

    public override object CreateInstance(fsData data, Type storageType) {
        return ElementSet.Empty();
    }
}
