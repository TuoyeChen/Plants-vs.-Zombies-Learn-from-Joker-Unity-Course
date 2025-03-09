using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    private float _downTargetPosY;
    private bool _destroyInvoked = false;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= _downTargetPosY)
        {
            if (!_destroyInvoked)
            {
                Invoke(nameof(DestroySun), 5f);
                _destroyInvoked = true;
            }
            return;
        }
        transform.Translate(Vector3.down * Time.deltaTime);
    }

    public void InitForSky(float downTargetPosY, float createPosX, float createPosY)
    {
        // 设置阳光的坐标
        Vector3 pos = new Vector3(createPosX, createPosY, 0);
        transform.position = pos;

        // 设置阳光掉落后的目标高度
        _downTargetPosY = downTargetPosY;
    }

    private void DestroySun()
    {
        Destroy(gameObject);
    }
}
