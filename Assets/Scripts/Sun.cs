using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sun : MonoBehaviour
{
    private float _downTargetPosY;
    private bool _destroyInvoked = false;

    public bool isFormSky;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        if (!isFormSky)
            return;
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
        isFormSky = true;
    }

    private void DestroySun()
    {
        Destroy(gameObject);
    }

    void OnMouseDown()
    {
        GameManager.Instance.SunNum += 50;
        var tempPos = Camera.main.ScreenToWorldPoint(UIManager.Instance.GetSunIconPos());
        tempPos.z = 0;
        FlyAnimation(tempPos);
    }

    private void FlyAnimation(Vector3 pos)
    {
        // 启动协程
        StartCoroutine(DoFly(pos));
    }

    private IEnumerator DoFly(Vector3 pos)
    {
        Vector3 direction = (pos - transform.position).normalized;
        while (Vector3.Distance(transform.position, pos) > 0.5f)
        {
            yield return new WaitForSeconds(0.01f);
            transform.Translate(direction);
        }
        DestroySun();
    }

    public void JumpAnimation()
    {
        isFormSky = false;
        // 启动协程
        StartCoroutine(DoJump());
    }

    private IEnumerator DoJump()
    {
        bool isLeft = Random.Range(0, 2) == 0;
        Vector3 startPos = transform.position;
        float x;
        if (isLeft)
        {
            x = -0.01f;
        }
        else
        {
            x = 0.01f;
        }
        while (transform.position.y <= startPos.y + 1)
        {
            yield return new WaitForSeconds(0.005f);
            transform.Translate(new Vector3(x, 0.05f, 0));
        }
        while (transform.position.y >= startPos.y)
        {
            yield return new WaitForSeconds(0.005f);
            transform.Translate(new Vector3(x, -0.05f, 0));
        }
    }
}
