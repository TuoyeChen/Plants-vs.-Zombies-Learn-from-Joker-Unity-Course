using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIPlantCard
    : MonoBehaviour,
        IPointerEnterHandler,
        IPointerExitHandler,
        IPointerClickHandler
{
    private Image _maskImg;
    public float CoolDownTime;
    private float _currentTimeForCoolDown;

    private bool _canPlace;
    public bool CanPlace
    {
        get => _canPlace;
        set
        {
            _canPlace = value;
            if (CanPlace)
            {
                _maskImg.fillAmount = 0;
            }
            else
            {
                _maskImg.fillAmount = 1;
                CoolDownEnter();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _maskImg = transform.Find("Mask").GetComponent<Image>();
        CanPlace = false;
    }

    // Update is called once per frame
    void Update() { }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!CanPlace)
        {
            return;
        }
        transform.localScale = new Vector2(1.05f, 1.05f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!CanPlace)
        {
            return;
        }
        transform.localScale = new Vector2(1f, 1f);
    }

    private void CoolDownEnter()
    {
        StartCoroutine(CalCoolDown());
    }

    IEnumerator CalCoolDown()
    {
        float calCoolDown = (1 / CoolDownTime) * 0.1f;
        _currentTimeForCoolDown = CoolDownTime;
        while (_currentTimeForCoolDown >= 0)
        {
            yield return new WaitForSeconds(0.1f);
            _maskImg.fillAmount -= calCoolDown;
            _currentTimeForCoolDown -= 0.1f;
        }

        CanPlace = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!CanPlace)
        {
            return;
        }
        Debug.Log("Click");
    }
}
