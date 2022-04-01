using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinMesh : MonoBehaviour
{
    [SerializeField] private MeshFilter _meshFilter;
    private Mesh _mesh;
    [SerializeField] private float _perlinNoise;
    private List<Vector3> _verticeList = new List<Vector3>();
    [SerializeField] private float _magnitude; 
    
    private void Awake()
    {
        _mesh = _meshFilter.mesh;
        _verticeList.AddRange(_mesh.vertices);
    }

    private void Update()
    {
        for(int i = 0; i < _verticeList.Count; i++)
        {
            _perlinNoise = Mathf.PerlinNoise(_verticeList[i].x, Time.time);
            
            _verticeList[i] = new Vector3(_verticeList[i].x, (_perlinNoise)*_magnitude, _verticeList[i].z);
            _mesh.SetVertices(_verticeList);
            _meshFilter.sharedMesh = _mesh;
        }
    }
    
}
