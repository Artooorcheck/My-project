using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovable
{
    public event Action<IMovable> onComplete;



    public void MoveTo(Vector3 target);
}
