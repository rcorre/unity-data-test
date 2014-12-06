using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public class ChooseWeapon : MonoBehaviour {
    public int width, height;
    public string selection { get { return _options[_index]; } }
    private int _index;
    private string[] _options;

    void OnGUI() {
        var area = new Rect(transform.position.x, transform.position.y, width, height);
        _index = GUI.SelectionGrid(area, _index, _options, 1);
    }

    // Use this for initialization
    void Start() {
        _options = DataManager.FetchAll<WeaponData>().Select(x => x.name).ToArray();
    }
}
