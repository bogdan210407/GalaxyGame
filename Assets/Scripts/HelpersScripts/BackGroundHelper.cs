using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundHelper : MonoBehaviour
{
    public Renderer backRanderer;
    void Update()
    {
        if(backRanderer != null)
        {
            backRanderer.material.mainTextureOffset = new Vector2(0.0f, 0.2f * Time.time);
        }
    }
}
