using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyAI : MonoBehaviour, IDamaged
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Collider zombieCollider;
    [SerializeField] Transform visualTarget;
    public float speed;
    Vector3 target;

    public virtual void OnActiveZombieMove(bool _active)
    {
        this.enabled = _active;
    }
    protected virtual void Start()
    {
        SetNewRandomTarget();
    }
    protected virtual void Update()
    {
        AIWork();
    }

    void AIWork()
    {
        if (target != null)
        {
            agent.destination = target;
        }

        if (agent.remainingDistance < agent.stoppingDistance)
        {
            SetNewRandomTarget();
        }
        visualTarget.position = target;
        speed = agent.velocity.magnitude;
    }

    protected virtual void SetNewRandomTarget()
    {
        target = TerrainUtilits.GetRandomPointOnTerrain();
        agent.SetDestination(target);
    }

    public abstract void Damage();

}
