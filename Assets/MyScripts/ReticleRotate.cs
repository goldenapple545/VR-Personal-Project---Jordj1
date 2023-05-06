using UnityEngine;

public class ReticleRotate : MonoBehaviour
{
    [SerializeField] public float _speed = 1;

    void Update()
    {
        Quaternion rotationY = Quaternion.AngleAxis(_speed, Vector3.up);
        transform.rotation *= rotationY;
    }
}
