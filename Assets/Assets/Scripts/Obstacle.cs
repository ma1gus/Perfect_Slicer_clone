using BzKovSoft.ObjectSlicerSamples;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float _stunTime;
    private Slicer _slicer;

    private void Start()
    {
        _slicer = FindObjectOfType<Slicer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out BzKnife knife))
        {
            _slicer.Stun(_stunTime);
        }
    }
}
