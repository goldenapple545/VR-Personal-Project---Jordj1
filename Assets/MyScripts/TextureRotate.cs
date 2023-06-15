using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureRotate : MonoBehaviour
{
    [SerializeField] private Material material;
    public float rotationSpeed = 0.1f;

    private Vector2 offset = new Vector2(0 ,0);
    
    // Update is called once per frame
    void Update()
    {
        // if (offset.x >= 0.98)
        // {
        //     offset.x = 0;
        // }


        offset.x += rotationSpeed * Time.deltaTime;
        material.mainTextureOffset = offset;
    }
}
