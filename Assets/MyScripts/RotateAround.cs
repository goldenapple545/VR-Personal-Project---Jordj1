using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public Transform target; // Целевой объект, вокруг которого будет производиться вращение
    public float rotationSpeed = 10f;

    void Update()
    {
        transform.RotateAround(target.position, Vector3.up, rotationSpeed * Time.deltaTime);
    }
}