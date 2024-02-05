
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventGeneration : MonoBehaviour
{
    [SerializeField] List<GameObject> _events;
    [SerializeField] List<int> _eventsChanse;
    private void OnTriggerEnter(Collider other)
    {
        if (_events.Count == _eventsChanse.Count)
        {

            int index = 0;
            int roll = Random.Range(0, 100);
            for (int x = 0; x < _eventsChanse.Count; x++)
            {
                if (roll < _eventsChanse[x]) index = x;
            }
            Instantiate(_events[index], gameObject.transform);
        }
    }
}
