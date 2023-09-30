using System.Collections.Generic;
using UnityEngine;

namespace Moving
{
    public class MoveController : MonoBehaviour
    {

        [SerializeField] private Transform[] _points;

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            var movables = GetComponentsInChildren<IMovable>();

            foreach (var movable in movables)
            {
                movable.onComplete -= SetTarget;
                movable.onComplete += SetTarget;
                SetTarget(movable);
            }
        }

        private void OnTransformChildrenChanged()
        {
            Init();
        }

        private void SetTarget(IMovable movable)
        {
            movable.MoveTo(_points[Random.Range(0, _points.Length)].position);
        }
    }
}
