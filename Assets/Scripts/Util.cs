using UnityEngine;

public static class Util {
    public static void Assert(bool cond, string message) {
        if (!cond) { Debug.LogError(message); }
    }
}
