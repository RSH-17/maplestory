using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField]
    private int current;

    [SerializeField]
    private int max;

    public int Current => current;
    public int Max => max;

    public Stat(int maxValue)
    {
        max = maxValue;
        current = maxValue;
    }

    public void Set(int value)
    {
        current = Mathf.Clamp(value, 0, max);
    }

    public void Increase(int amount)
    {
        current = Mathf.Min(current + amount, max);
    }

    public void Decrease(int amount)
    {
        current = Mathf.Max(current - amount, 0);
    }

    public void RestoreFull()
    {
        current = max;
    }

    public void IncreaseMax(int amount, bool restore = true)
    {
        max += amount;
        if (restore)
            current = max;
    }

    public void Reset(int newMax)
    {
        max = newMax;
        current = max;
    }

    // UI 표시용 문자열 (예: "50 / 100")
    public string GetDisplayString()
    {
        return $"{current} / {max}";
    }

    // 퍼센트 (0 ~ 1) 값 → Slider에 사용
    public float GetRatio()
    {
        return (float)current / max;
    }
}
