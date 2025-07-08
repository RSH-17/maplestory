using UnityEngine;

public class FadeOutAnimation : MonoBehaviour
{
    public testmob testmob;
    public float fadeDuration = 1f;
    private float fadeTimer = 0f;
    private SpriteRenderer sr;
    void Start()
    {
        testmob = GetComponent<testmob>();
        sr = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if (testmob != null && testmob.getIsDead())
        {
            fadeTimer += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, fadeTimer / fadeDuration);

            if (sr != null)
            {
                Color c = sr.color;
                sr.color = new Color(c.r, c.g, c.b, alpha);
            }
        }
    }
}
