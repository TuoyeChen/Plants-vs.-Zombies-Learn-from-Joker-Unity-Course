using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

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
    }

    void Start()
    {
        SunNum = 100;
    }

    // Update is called once per frame
    void Update() { }
}
