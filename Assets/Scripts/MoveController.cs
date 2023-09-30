using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private IEnumerable<IMovable> _movable;

    [SerializeField] private Transform[] _points;

    private void Awake()
    {
        _movable = GetComponentsInChildren<IMovable>();

        foreach(var mov in _movable)
        {
            mov.onComplete += (mov) =>
             {
                 mov.MoveTo(_points[Random.Range(0, _points.Length)].position);
             };

            mov.MoveTo(_points[Random.Range(0, _points.Length)].position);
        }
    }
}
