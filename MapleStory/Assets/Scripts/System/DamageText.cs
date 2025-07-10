using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour
{

    public float fadeSpeed = 1f;
    public float fadeDuration = 1f;

    private TextMeshProUGUI text;
    private Color originalColor;
    private float Timer;

    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void setDamageText(int damage)
    {
        if (text == null) text = GetComponent<TextMeshProUGUI>();
        text.text = damage.ToString();
        originalColor = text.color;
        originalColor.a = 1f;
        text.color = originalColor;
    }

    void Update()
    {
        transform.Translate(Vector3.up * fadeSpeed * Time.deltaTime);
        Timer += Time.deltaTime;
        float alpha = Mathf.Lerp(1f, 0f, Timer / fadeDuration);
        text.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

        if (Timer >= fadeDuration)
        {
            Destroy(gameObject);
        }
    }

    
}
