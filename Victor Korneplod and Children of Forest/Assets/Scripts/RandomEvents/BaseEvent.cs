using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEvent : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private GameObject _sound;
    [SerializeField] private float _lifeTime;

    protected virtual void Awake()
    {
        Instantiate(_prefab);
        // и тута пусть звук проигрывает
    }

    private void FixedUpdate()
    {
        _lifeTime -= Time.deltaTime;
        if (_lifeTime < 0 ) Destroy( gameObject );
    }
}
