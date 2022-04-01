using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinCube : MonoBehaviour
{
    [SerializeField][Range(0,10)] private float _magnitude;
    [SerializeField] [Range(0, 1)] private float _perlinNoise;
    
    private void Update()
    {
        _perlinNoise = Mathf.PerlinNoise(Time.time, Time.time);
        transform.localScale = new Vector3(transform.localScale.x, _magnitude * _perlinNoise,
            transform.localScale.z);
    }
}
