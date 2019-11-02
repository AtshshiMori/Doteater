using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxController : MonoBehaviour
{

    [Range(0.01f, 0.1f)]
    public float rotateSpeed;
    float rotValue = 0.0f;

    void Update()
    {

        rotValue += rotateSpeed;
        rotValue = Mathf.Repeat(rotValue, 360f);
        RenderSettings.skybox.SetFloat("_Rotation", rotValue);
    }
}
