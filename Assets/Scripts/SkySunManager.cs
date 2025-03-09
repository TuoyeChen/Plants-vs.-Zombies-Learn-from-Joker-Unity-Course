using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkySunManager : MonoBehaviour
{
    /// <summary>
    /// 创建阳光时候的坐标Y
    /// </summary>
    private float _createSunPosY = 6;

    /// <summary>
    /// 创建阳光时候的坐标X范围
    /// </summary>
    private float _createSunMaxPosX = 3;

    /// <summary>
    /// 创建阳光时候的坐标X范围
    /// </summary>
    private float _createSunMinPosX = -7.5f;

    /// <summary>
    /// 阳光掉落后的最大高度
    /// </summary>
    private float _sunDownMaxPosY = 2.5f;

    /// <summary>
    /// 阳光掉落后的最小高度
    /// </summary>
    private float _sumDownMinPosY = -3.7f;

    private GameObject _SunPrefab;

    // Start is called before the first frame update
    void Start()
    {
        _SunPrefab = Resources.Load<GameObject>("Sun");
        InvokeRepeating(nameof(CreateSun), 3, 3);
    }

    // Update is called once per frame
    void Update() { }

    void CreateSun()
    {
        // 生成阳光
        Sun sun = Instantiate(_SunPrefab, Vector3.zero, Quaternion.identity, transform)
            .GetComponent<Sun>();
        float sunDownY = Random.Range(_sumDownMinPosY, _sunDownMaxPosY);
        float createX = Random.Range(_createSunMinPosX, _createSunMaxPosX);
        sun.InitForSky(sunDownY, createX, _createSunPosY);
    }

}
