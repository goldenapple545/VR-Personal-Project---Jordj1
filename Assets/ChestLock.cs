using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestLock : MonoBehaviour
{
    [SerializeField] private GameObject key;
    [SerializeField] private Collider keyCollider;
    [SerializeField] private FixedJoint fixedJoint;
 
    private void OnTriggerEnter(Collider other)
    {
        if (other == keyCollider)
        {   
            Destroy(fixedJoint);
            Destroy(key);
        }
    }
}
