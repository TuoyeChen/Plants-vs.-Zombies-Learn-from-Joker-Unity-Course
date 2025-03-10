using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField]
    private List<Vector2> _pointList = new List<Vector2>();

    [SerializeField]
    private List<Grid> _gridList = new List<Grid>();

    void Start()
    {
        CreateGridsBaseGird();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 point = GetGridPointByMouse();
            Debug.Log(point);
        }
    }

    private void CreateGridsBaseColl()
    {
        GameObject girdPrefab = new GameObject("Grid");
        girdPrefab.AddComponent<BoxCollider2D>().size = new Vector2(1, 1.5f);
        girdPrefab.transform.SetParent(transform);
        girdPrefab.transform.position = transform.position;

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                var grid = GameObject.Instantiate<GameObject>(
                    girdPrefab,
                    transform.position + new Vector3(1.33f * i, 1.63f * j, 0),
                    Quaternion.identity,
                    transform
                );
                grid.name = $"Grid_{i}_{j}";
            }
        }
    }

    private void CreateGridsBasePointList()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                _pointList.Add(transform.position + new Vector3(1.33f * i, 1.63f * j, 0));
            }
        }
    }

    public Vector2 GetGridPointByMouse()
    {
        float dis = 1000000;

        Vector2 point = new Vector2();
        for (int i = 0; i < _gridList.Count; i++)
        {
            float tempDis = Vector2.Distance(
                _gridList[i].Position,
                Camera.main.ScreenToWorldPoint(Input.mousePosition)
            );
            if (tempDis < dis)
            {
                dis = tempDis;
                point = _gridList[i].Position;
            }
        }

        return point;
    }

    private void CreateGridsBaseGird()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                _gridList.Add(
                    new Grid(
                        new Vector2(i, j),
                        transform.position + new Vector3(1.33f * i, 1.63f * j, 0),
                        false
                    )
                );
            }
        }
    }
}
