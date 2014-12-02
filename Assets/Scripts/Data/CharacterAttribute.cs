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
public class AttributeSet : Enumap<CharacterAttribute, int> {
}

public class AttributeSetConverter : DictConverter {
    protected override object Init() {
        return new AttributeSet();
    }
}
