using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.XR.Interaction.Toolkit;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class DoorHandle : XRGrabInteractable
{
    [SerializeField] private Transform door;
    [SerializeField] private Transform doorHandle;
    [SerializeField] private Transform minPosition;
    [SerializeField] private Transform maxPosition;
    [SerializeField] private AudioSource mAudioSource;
    
    public float doorMass = 2;
    private float distCenterhandle = 0;

    // Ручка возвращается на место при отпускании 
    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);

        transform.position = doorHandle.position;
        transform.rotation = doorHandle.rotation;
        mAudioSource.Pause();
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        mAudioSource.Play();
    }

    private void Start()
    {
        distCenterhandle = transform.localPosition.x - door.localPosition.x; // Расстояние между ручкой и центром двери
    }

    void Update()
    {
        // Проекция вектора ручки на направление начальной точки
        Vector3 projection = Vector3.Project(transform.position, -door.right);
        
        // Смещение проекции 
        projection += new Vector3(-distCenterhandle, door.position.y, door.position.z); // -distCenterhandle здесь смещение на расстояние от ручки до центра двери
    
        // Считаем насколько быстро нужно двигать дверь за ручкой
        Vector3 dist = transform.localPosition - door.localPosition;
        float volume = Vector3.Dot(dist, transform.position);
        float speed = Math.Abs(volume) * Time.deltaTime;
        mAudioSource.volume = speed*100; // Громкость звука
        
        // Ограничения движения двери
        if (transform.position.x > minPosition.position.x)
        {
            //  new Vector3(-distCenterhandle, 0, 0) смещение на расстояние от ручки до центра двери
            door.position = Vector3.MoveTowards(door.position, minPosition.position + new Vector3(-distCenterhandle, 0, 0), speed/doorMass);
            mAudioSource.volume = 0;
        }
        else if (transform.position.x < maxPosition.position.x)
        {
            door.position = Vector3.MoveTowards(door.position, maxPosition.position + new Vector3(-distCenterhandle, 0, 0), speed/doorMass);
            mAudioSource.volume = 0;
        }
        else
        {
            door.position = Vector3.MoveTowards(door.position, projection, speed/doorMass); // Если не вышли за ограничение, двигаем дверь
        }

    }

}
