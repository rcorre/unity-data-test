using System;
using System.Linq;
using System.Collections.Generic;
using FullSerializer;

public abstract class Enumap<K,V> : SerializeableDict {
    public readonly int size;
    private V[] _store;

    public Enumap() {
        Util.Assert(typeof(K).IsEnum, "Enumap expects T : enum, got " + typeof(K));
	size = Enum.GetValues(typeof(K)).Length;
	_store = new V[size];
    }

    public V this[K key] {
        get { return _store[Convert.ToInt32(key)]; }
        set { _store[Convert.ToInt32(key)] = value; }
    }

    public void SetValue(string key, fsData val) {
        int idx = (int)Enum.Parse(typeof(K), key, true);
        V entry = default(V);
        if (val.Type == fsDataType.Int64) {
            entry = (V)Convert.ChangeType(val.AsInt64, typeof(V));
        }
        else if (val.Type == fsDataType.Double) {
            entry = (V)Convert.ChangeType(val.AsDouble, typeof(V));
        }
        else {
            Util.Assert(false, "Enumap value can only be assigned from int64 or double");
        }
        _store[(int)idx] = entry;
    }

    public fsData GetValue(string key) {
        return new fsData();
    }

    public string[] Keys { get { return Enum.GetNames(typeof(K)); } }
}

public interface SerializeableDict {
    void SetValue(string key, fsData val);
    fsData GetValue(string key);
    string[] Keys { get; }
}

public abstract class DictConverter : fsConverter {
    public override bool CanProcess(Type type) {
        return type.GetInterfaces().Contains(typeof(SerializeableDict));
    }

    public override fsFailure TrySerialize(object instance, out fsData serialized, Type storageType) {
        var input = (SerializeableDict)instance;
        var output = new Dictionary<string, fsData>();

        foreach (var key in input.Keys) {
            output[key] = input.GetValue(key);
        }

        serialized = new fsData(output);
        return fsFailure.Success;
    }

    public override fsFailure TryDeserialize(fsData storage, ref object instance, Type storageType) {
        // verify json contains expected type
        if (storage.Type != fsDataType.Object) {
            return fsFailure.Fail("Expected object fsData type but got " + storage.Type);
        }

        var output = (SerializeableDict)instance;
        var input = storage.AsDictionary;
        foreach (var kvp in input) {
            output.SetValue(kvp.Key, kvp.Value);
        }
        return fsFailure.Success;
    }

    public override object CreateInstance(fsData data, Type storageType) {
        return Init();
    }

    protected abstract object Init();
}