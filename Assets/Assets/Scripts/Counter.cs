using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private int _score;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Food food))
        {
            _score++;
            Debug.Log($"score: {_score}");
        }
    }
}
