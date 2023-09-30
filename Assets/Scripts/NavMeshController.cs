using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshController : MonoBehaviour, IMovable, IAttack
{
    public event Action<IMovable> onComplete;

    private NavMeshAgent _navMeshAgentDef;

    private NavMeshAgent _navMeshAgent
    {
        get
        {
            if (_navMeshAgentDef == null)
                _navMeshAgentDef = GetComponent<NavMeshAgent>();
            return _navMeshAgentDef;
        }
    }

    public void MoveTo(Vector3 target)
    {
        _navMeshAgent.SetDestination(target);
        StartCoroutine(CompleteChecker());
    }

    private IEnumerator CompleteChecker()
    {
        yield return new WaitWhile(() => Vector3.Distance(_navMeshAgent.destination, transform.position) > 1.0f);
        onComplete?.Invoke(this);
    }
}
