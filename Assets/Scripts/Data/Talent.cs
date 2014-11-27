using FullSerializer;

public struct Talent {
    public int rank;
    [fsIgnore]
    public TalentData data;
}