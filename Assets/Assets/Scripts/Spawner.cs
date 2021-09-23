using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private float _spawnDelay;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            var prefabNumber = Random.Range(0, _prefabs.Length);
            var prefab = _prefabs[prefabNumber];
            Instantiate(prefab, transform.position, prefab.transform.rotation);

            yield return new WaitForSeconds(_spawnDelay);
        }
    }
}
