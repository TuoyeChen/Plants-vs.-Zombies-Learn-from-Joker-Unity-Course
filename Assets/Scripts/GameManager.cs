using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject SunPrefab { get; private set; }

    private int _sunNum;

    public int SunNum
    {
        get => _sunNum;
        set
        {
            _sunNum = value;
            UIManager.Instance.UpdateSunNum(_sunNum);
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        SunPrefab = Resources.Load<GameObject>("Sun");
    }

    void Start()
    {
        SunNum = 100;
    }

    // Update is called once per frame
    void Update() { }
}
