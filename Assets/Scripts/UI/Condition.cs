using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Condition : MonoBehaviour
{
    public float curValue;
    public float startValue;
    public float maxValue;
    public float passiveValue;
    public Image uiBar;

    private void Awake()
    {
        curValue = startValue;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.player.condition.health = this;
    }

    void Update()
    {
        uiBar.fillAmount = GetPercentange();
    }

    float GetPercentange()
    {
        return curValue / maxValue;
    }

    public void Add(float value)
    {
        curValue = Mathf.Min(curValue + value, maxValue);
    }

    public void Subtract(float value)
    {
        curValue = Mathf.Max(curValue - value, 0);
    }
}
