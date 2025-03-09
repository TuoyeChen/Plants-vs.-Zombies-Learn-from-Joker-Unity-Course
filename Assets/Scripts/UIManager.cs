using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField]
    private Text _sunNumText;

    [SerializeField]
    private GameObject _sunIcon;

    void Awake()
    {
        Instance = this;
    }

    void Start() { }

    // Update is called once per frame
    void Update() { }

    public void UpdateSunNum(int num)
    {
        _sunNumText.text = num.ToString();
    }

    public Vector3 GetSunIconPos()
    {
        return _sunIcon.transform.position;
    }
}
