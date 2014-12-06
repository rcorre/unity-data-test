using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public class ChooseWeapon : MonoBehaviour {
    public int width, height;
    public WeaponData selection { get { return _options[_index]; } }
    private int _index;
    private WeaponData[] _options;

    void OnGUI() {
        var area = new Rect(transform.position.x, transform.position.y, width, height);
	var names = _options.Select(x => x.name).ToArray();
        _index = GUI.SelectionGrid(area, _index, names, 1);
    }

    // Use this for initialization
    void Start() {
        _options = DataManager.FetchAll<WeaponData>().ToArray();
    }
}
