using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO borrar execute always cuando ya funcione la herramienta
[ExecuteInEditMode]

public class SpotlightBehavior : MonoBehaviour
{
    //Class variables
    private Light spotlightComponent;
    private Material defaultMaterial;
    [SerializeField] private Material spotlightMaterial;

    [Header("Spotlight Attributes")]
    [SerializeField] private float lightIntesity = 1.0f;
    [SerializeField] private float emissionIntesity = 1.0f;
    [SerializeField] private Color lightColor = new Color();
    [SerializeField] private float spotlightRange = 100f;
    [SerializeField] private float innerConeAngle = 25.0f;
    [SerializeField] private float outerConeAngle = 85.0f;

    private int spotlightColorID;
    private int emissionIntensityID;

    private void OnValidate()
    {

        SpotlightSetup();
    }

    private void SpotlightSetup()
    {
        // convert shader references  to ID
        spotlightColorID = Shader.PropertyToID("_SPOTLIGHT_COLOR");
        emissionIntensityID = Shader.PropertyToID("_EMISSION_INTENSITY");

        defaultMaterial = GetComponentInChildren<Renderer>().material;
        defaultMaterial = spotlightMaterial;
        spotlightComponent = GetComponentInChildren<Light>();
        spotlightComponent.type = LightType.Spot;
        spotlightMaterial.hideFlags = HideFlags.HideAndDontSave;
        spotlightComponent.hideFlags = HideFlags.HideAndDontSave; //bloquea los componentes
        spotlightComponent.intensity = lightIntesity;
        spotlightComponent.innerSpotAngle = innerConeAngle;
        spotlightComponent.spotAngle = outerConeAngle;
        spotlightComponent.range = spotlightRange;

        spotlightComponent.color = lightColor;
        spotlightMaterial.SetColor(spotlightColorID, lightColor);
        spotlightMaterial.SetFloat(emissionIntensityID, emissionIntesity);
    }

}