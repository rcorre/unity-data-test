using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public class ChooseMaterial : MonoBehaviour {
    public int width, height;
    public EquipmentMaterial selection { get { return _options[_index]; } }
    private int _index;
    private EquipmentMaterial[] _options;

    void OnGUI() {
        var area = new Rect(transform.position.x, transform.position.y, width, height);
        var names = _options.Select(x => x.name).ToArray();
        _index = GUI.SelectionGrid(area, _index, names, 1);
    }

    // Use this for initialization
    void Start() {
        _options = DataManager.FetchAll<EquipmentMaterial>().ToArray();
    }
}
