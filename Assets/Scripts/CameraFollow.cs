using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed;
    private void Update()
    {
        transform.position = (Vector2.Lerp(transform.position, target.position, speed * Time.deltaTime));
    }
}
