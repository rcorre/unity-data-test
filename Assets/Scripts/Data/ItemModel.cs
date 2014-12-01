public abstract class ItemModel {
    public readonly string key; /// <summary> unique id, unchanged even if name changes </summary>
    public readonly string name; /// <summary> name shown in ui </summary>

    public readonly int weight;
    public readonly int value;
}