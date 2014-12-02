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

[fsObject(Converter = typeof(ElementSetConverter))]
public class ElementSet : Enumap<Element, int> { }
public class ElementSetConverter : DictConverter<ElementSet> { }