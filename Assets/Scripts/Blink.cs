using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public Renderer[] Renderers;
    public float Frequency = 30;
    public IEnumerator BlinkEffect()
    {
        for (float t = 0; t < 1; t += Time.deltaTime)
        {
            for (int i = 0; i < Renderers.Length; i++)
            {
                for (int k = 0; k < Renderers[i].materials.Length; k++)
                {
                    Renderers[i].materials[k].SetColor("_EmissionColor", new Color(Mathf.Sin(t * Frequency) * 0.5f + 0.5f, 0, 0, 0));
                }
                
            }
            yield return null;
        }
        for (int i = 0; i < Renderers.Length; i++)
        {
            for (int k = 0; k < Renderers[i].materials.Length; k++)
            {
                Renderers[i].materials[k].SetColor("_EmissionColor", new Color(0, 0, 0, 0));
            }

        }

    }

    public void StartBlinking()
    {
        if(gameObject.activeSelf)
         StartCoroutine(BlinkEffect());
    }
}
