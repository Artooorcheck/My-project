using System;
using UnityEngine;


namespace Moving
{
    public interface IMovable
    {
        public event Action<IMovable> onComplete;
        public void MoveTo(Vector3 target);
    }
}
