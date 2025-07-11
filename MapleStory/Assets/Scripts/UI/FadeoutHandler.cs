using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections;

public class FadeoutHandler : MonoBehaviour
{
    [Header("설정")]
    public float fadeDuration = 1f;
    public float delayBeforeFade = 0f;
    public bool autoStart = false;

    public Action onFadeComplete;

    private float fadeTimer = 0f;
    private bool isFading = false;

    //대상 렌더링 요소들
    private SpriteRenderer spriteRenderer;
    private TextMeshProUGUI tmpText;
    private Graphic uiGraphic;
    private CanvasGroup canvasGroup;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        tmpText = GetComponent<TextMeshProUGUI>();
        uiGraphic = GetComponent<Graphic>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    void Start()
    {
        if (autoStart) StartFadeOut();
    }

    void Update()
    {
        if (!isFading) return;

        fadeTimer += Time.deltaTime;
        float t = Mathf.Clamp01(fadeTimer / fadeDuration);
        float alpha = Mathf.Lerp(1f, 0f, t);

        ApplyAlpha(alpha);

        if (t >= 1f)
        {
            isFading = false;
            onFadeComplete?.Invoke();
            Destroy(gameObject);
        }
    }

    public void StartFadeOut()
    {
        StartCoroutine(FadeRoutine());
    }

    private IEnumerator FadeRoutine()
    {
        if (delayBeforeFade > 0f)
            yield return new WaitForSeconds(delayBeforeFade);

        fadeTimer = 0f;
        isFading = true;
    }

    private void ApplyAlpha(float alpha)
    {
        if (spriteRenderer != null)
        {
            var c = spriteRenderer.color;
            spriteRenderer.color = new Color(c.r, c.g, c.b, alpha);
        }
        if (tmpText != null)
        {
            var c = tmpText.color;
            tmpText.color = new Color(c.r, c.g, c.b, alpha);
        }
        if (uiGraphic != null)
        {
            var c = uiGraphic.color;
            uiGraphic.color = new Color(c.r, c.g, c.b, alpha);
        }
        if (canvasGroup != null)
        {
            canvasGroup.alpha = alpha;
        }
    }




}