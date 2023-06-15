using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderMoveToCamera : MonoBehaviour
{
    [SerializeField] private CharacterController charController;
    [SerializeField] private Transform cameraTransform;

    private float posX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        posX = charController.transform.position.x;
        posX = cameraTransform.position.x;
    }
}
