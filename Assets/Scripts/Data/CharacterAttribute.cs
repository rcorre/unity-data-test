using FullSerializer;

public enum CharacterAttribute {
    Str,
    Dex,
    Con,
    Int,
    Wis,
    Cha
}

[fsObject(Converter = typeof(AttributeSetConverter))]
public class AttributeSet : Enumap<CharacterAttribute, int> { }
public class AttributeSetConverter : DictConverter<AttributeSet> { }