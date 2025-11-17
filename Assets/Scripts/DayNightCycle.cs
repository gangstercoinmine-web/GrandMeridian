using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Light sun;
    public float dayDurationMinutes = 1f; // full day length in minutes (for testing)
    float currentTime = 0f;

    void Update()
    {
        if (sun == null) return;

        currentTime += Time.deltaTime;
        float t = (currentTime / (dayDurationMinutes * 60f)) % 1f;
        float angle = t * 360f;
        sun.transform.rotation = Quaternion.Euler(new Vector3(angle - 90f, 170f, 0f));
        // optional: change ambient intensity
        RenderSettings.ambientIntensity = Mathf.Lerp(0.2f, 1f, Mathf.Clamp01(Mathf.Cos((t - 0.5f) * Mathf.PI) * -1f));
    }
}
