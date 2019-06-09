using UnityEngine;
using System.Collections;
 
public static class SpriteHelper {
 
    public static IEnumerator FadeOut (SpriteRenderer spriteRenderer, float FadeTime) {
        Color startColor = spriteRenderer.color;
 
        while (spriteRenderer.color.a > 0) {
            float a = spriteRenderer.color.a - startColor.a * Time.deltaTime / FadeTime;
            spriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, a);
            // Debug.Log("out color a " + a);
            yield return null;
        }
    }

    public static IEnumerator FadeIn (SpriteRenderer spriteRenderer, float FadeTime) {
        Color startColor = spriteRenderer.color;
 
        while (spriteRenderer.color.a < 1.0f) {
            float a = spriteRenderer.color.a + Time.deltaTime / FadeTime;
            spriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, a);
            // Debug.Log("in color a " + a);
            yield return null;
        }
    }
}
 