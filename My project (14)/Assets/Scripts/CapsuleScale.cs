using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class CapsuleScale : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _scale;
    [SerializeField] private Transform _newScale;
    [SerializeField] private Transform _startScale;
    [SerializeField] private float _pathTime;
    private float _pathRunningTime;


    private void Update()
    {
        _pathRunningTime += Time.deltaTime * _speed;
        float currentTime = _pathRunningTime / _pathTime;
        float timeOfIncreasingScale = 0.2f;
        float maxTime = 1f;

        if (currentTime < timeOfIncreasingScale)
        {
            transform.localScale = Vector3.Lerp(_scale.localScale, _newScale.localScale, currentTime);
        }
        else if (currentTime >= timeOfIncreasingScale && currentTime < maxTime)
        {
            transform.localScale = Vector3.Lerp(_newScale.localScale, _startScale.localScale, currentTime);
        }
        else if (currentTime >= maxTime)
        {
            _pathRunningTime = 0;
        }
    }       
}
