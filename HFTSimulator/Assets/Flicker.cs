using UnityEngine;
using System.Collections;

public class Flicker : MonoBehaviour
{
    public float MaxOnTime = 10.0f;
    public float MinOnTime = 1.0f;

    public float MaxOffTime = 0.5f;
    public float MinOffTime = 0.001f;

    public float BrightenSpeed = 0.1f;
    public float DimSpeed = 0.5f;

    public float MinBrightness = 1;

    private Light light;
    private AudioSource flickerSound;

    float startIntensitiy;

    void Start() 
    {
        light = GetComponent<Light>();
        flickerSound = GetComponent<AudioSource>();

        startIntensitiy = light.intensity;

        StartCoroutine(FlickerLight());
    }

    IEnumerator FlickerLight() 
    {
        yield return StartCoroutine(BrightenLight());

        float OnTime = Random.Range(MinOnTime, MaxOnTime);
        float OffTime = Random.Range(MinOffTime, MaxOffTime);

        yield return new WaitForSeconds(OnTime);

        flickerSound.Play();
        yield return StartCoroutine(DimLight());

        yield return new WaitForSeconds(OffTime);

        StartCoroutine(FlickerLight());
    }

    IEnumerator BrightenLight()
    {
        while (light.intensity < startIntensitiy)
        {
            light.intensity += BrightenSpeed;
            yield return null;
        }

        if (light.intensity > startIntensitiy)
            light.intensity = startIntensitiy;

        yield return null;
    }

    IEnumerator DimLight() 
    {
        while (light.intensity > MinBrightness)
        {
            light.intensity -= DimSpeed;
            yield return null;
        }

        if (light.intensity < MinBrightness)
            light.intensity = MinBrightness;

        yield return null;
    }
}
