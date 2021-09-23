using BzKovSoft.ObjectSlicerSamples;

using DG.Tweening;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slicer : MonoBehaviour
{
    [SerializeField] private GameObject _knife;
    [SerializeField] private float _duration;
    [SerializeField] private float _offsetY;

    private BzKnife _razor;
    private Coroutine _cutting;
    private bool _isWorking = false;
    private float _stunDuration;

    private void Awake()
    {
        _razor = _knife.GetComponentInChildren<BzKnife>();
    }

    private void Update()
    {
        if (_stunDuration > 0)
            _stunDuration -= Time.deltaTime;

        if (Input.GetMouseButton(0) && !_isWorking && _stunDuration <= 0)
        {
            _razor.BeginNewSlice();

            if (_cutting != null)
                StopCoroutine(_cutting);

            _cutting = StartCoroutine(Cut());
        }
    }

    public void Stun(float time)
    {
        _stunDuration = time;
    }

    private IEnumerator Cut()
    {
        _isWorking = true;

        yield return _knife.transform
                .DOMoveY(_knife.transform.position.y - _offsetY, _duration)
                .SetLoops(2, LoopType.Yoyo)
                .WaitForCompletion();

        _isWorking = false;
    }


}
