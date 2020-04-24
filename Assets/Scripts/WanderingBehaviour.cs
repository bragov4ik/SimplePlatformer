using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingBehaviour : MonoBehaviour
{
    [SerializeField] private Vector2 _pointB = Vector2.zero;
    private Vector2 _pointA;
    private float _trackPercentage;
    private int _direction;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        _pointA = this.transform.position;
        _trackPercentage = 0f;
        _direction = 1;
    }

    // Update is called once per frame
    void Update()
    {
        _trackPercentage += Time.deltaTime * speed * _direction;
        if (_trackPercentage > 1 || _trackPercentage < 0)
        {
            _direction *= -1;
            _trackPercentage += Time.deltaTime * speed * _direction;
        }
        Vector2 path = _pointB - _pointA;
        transform.position = _pointA + path * _trackPercentage;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, _pointB);
    }
}
