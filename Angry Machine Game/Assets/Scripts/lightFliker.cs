using UnityEngine;

public class LightFlickerToggle : MonoBehaviour
{
    public Light flickerLight;
    public AudioSource flickerSound; // Add this line
    private float timer;

    void Start()
    {
        if (flickerLight == null)
            flickerLight = GetComponent<Light>();

        timer = Random.Range(0.5f, 2f);
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            flickerLight.enabled = !flickerLight.enabled;  // Toggle light on/off

            if (flickerSound != null)
                flickerSound.Play(); // Play sound

            timer = Random.Range(0.5f, 2f);

            if (flickerLight.enabled)
            {
                flickerLight.intensity = Random.Range(0.1f, 2f);  // Random intensity when light is turned on
            }
        }
    }
}