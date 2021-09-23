using UnityEngine;
using BzKovSoft.ObjectSlicer;
using System.Diagnostics;
using System;
using System.Collections;
using DG.Tweening;

namespace BzKovSoft.ObjectSlicerSamples
{
    /// <summary>
    /// Test class for demonstration purpose
    /// </summary>
    public class SampleKnifeSlicer : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField] private GameObject _blade;
        [SerializeField] private float _speed;
#pragma warning restore 0649

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                var knife = _blade.GetComponentInChildren<BzKnife>();
                knife.BeginNewSlice();

                var transformB = _blade.transform;
                Sequence sequence = DOTween.Sequence();
                sequence.Append(transformB.DORotate(new Vector3(0, -75, transformB.rotation.z), _speed));
                sequence.Append(transformB.DORotate(new Vector3(-30, -75, transformB.rotation.z), _speed));
            }
        }
    }
}