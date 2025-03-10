using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFlower : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(CreateSun), 3, 3);
    }

    // Update is called once per frame
    void Update() { }

    private void CreateSun()
    {
        // 生成阳光
        Sun sun = Instantiate(
                GameManager.Instance.SunPrefab,
                transform.position,
                Quaternion.identity,
                transform
            )
            .GetComponent<Sun>();
        sun.JumpAnimation();
    }
}
