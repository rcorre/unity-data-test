using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public class ChooseMaterial : MonoBehaviour {
    public int width, height;
    public string selection { get; private set; }
    private string[] _options;

    void OnGUI() {
        var area = new Rect(transform.position.x, transform.position.y, width, height);
        int idx = GUI.SelectionGrid(area, 0, _options, 1);
        selection = _options[idx];
    }

    // Use this for initialization
    void Start() {
        _options = DataManager.FetchAll<EquipmentMaterial>().Select(x => x.name).ToArray();
    }
}
