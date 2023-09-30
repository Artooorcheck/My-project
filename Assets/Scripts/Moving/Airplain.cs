using System;
using System.Collections;
using UnityEngine;


namespace Moving
{
    public class Airplain : MonoBehaviour, IMovable
    {
        public event Action<IMovable> onComplete;

        private Coroutine _moveCoroutine;

        public void MoveTo(Vector3 target)
        {
            if (_moveCoroutine != null)
            {
                StopCoroutine(_moveCoroutine);
                _moveCoroutine = null;
            }

            _moveCoroutine = StartCoroutine(MoveAsync(target));
        }

        private IEnumerator MoveAsync(Vector3 point)
        {
            var transform = this.transform;
            var startPos = transform.position;
            for (float t = 0; t < 1; t += Time.deltaTime)
            {
                transform.position = Vector3.Lerp(startPos, point, t) + Mathf.Sin(t * Mathf.PI) * Vector3.up * 3;
                yield return null;
            }
            onComplete?.Invoke(this);
            _moveCoroutine = null;
        }
    }
}
