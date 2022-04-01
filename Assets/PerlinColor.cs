using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerlinColor : MonoBehaviour
{
    private List<Image> _imageList = new List<Image>();
    [SerializeField]private float _perlinNoiseY, _perlinNoiseX, _magnitude;

    private void Awake()
    {
        _imageList.AddRange(GetComponentsInChildren<Image>());
    }


    private void Update()
    {
        for(int i = 0; i < _imageList.Count; i++)
        {
            _perlinNoiseY = Mathf.PerlinNoise(_imageList[i].gameObject.transform.position.y*Mathf.PingPong(Time.deltaTime, 1) ,Time.time);
            _perlinNoiseX = Mathf.PerlinNoise(_imageList[i].gameObject.transform.position.x*Mathf.PingPong(Time.deltaTime, 1) ,Time.time);
            _imageList[i].color = new Color(_perlinNoiseX * _perlinNoiseY * _magnitude, Mathf.PingPong(10, 1),
                _perlinNoiseX * _perlinNoiseY * _magnitude);
        }
    }
}
