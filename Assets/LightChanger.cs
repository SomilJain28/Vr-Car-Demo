using UnityEngine;

public class LightChanger : MonoBehaviour
{
    public Light directionalLight;
    public Color[] lightColors;
    public Material[] skyboxes;
    public float changeInterval = 5f;
    public float transitionSpeed = 2f;

    private int currentColorIndex = 0;
    private int nextColorIndex = 1;
    private float timer = 0f;
    private bool isTransitioning = false;

    void Start()
    {
        if (directionalLight == null)
        {
            Debug.LogError("No directional light assigned!");
        }
        else
        {
            directionalLight.color = lightColors[currentColorIndex];
            RenderSettings.skybox = skyboxes[currentColorIndex];
        }
    }

    void Update()
    {
        if (directionalLight == null) return;

        if (isTransitioning)
        {
            directionalLight.color = Color.Lerp(directionalLight.color, lightColors[nextColorIndex], transitionSpeed * Time.deltaTime);

            // Transition between skyboxes
            RenderSettings.skybox.Lerp(skyboxes[currentColorIndex], skyboxes[nextColorIndex], transitionSpeed * Time.deltaTime);

            if (directionalLight.color == lightColors[nextColorIndex])
            {
                isTransitioning = false;

                currentColorIndex = nextColorIndex;
                nextColorIndex = (currentColorIndex + 1) % lightColors.Length;

                // Set the skybox to the next one after transition is complete
                RenderSettings.skybox = skyboxes[currentColorIndex];

                timer = 0f;
            }
        }
        else
        {
            timer += Time.deltaTime;

            if (timer >= changeInterval)
            {
                isTransitioning = true;
            }
        }
    }
}
