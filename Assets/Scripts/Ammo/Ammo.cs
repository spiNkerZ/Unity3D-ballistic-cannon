using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] protected Rigidbody rigidBody;
    [SerializeField] ParticleSystem expolosionEffect;
    [SerializeField] [Range(1,5)] private float explosionRadius;
    [SerializeField] LayerMask layerMask;
    protected Transform target;

    protected virtual void Update()
    {
        if (Physics.CheckSphere(transform.position, transform.localScale.x / 2, layerMask))
        {
            OverlapExlosion();
            Explosion();
        }
    }
    private void OverlapExlosion()
    {
        Collider[] collidersArray = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (var item in collidersArray)
        {
            item.TryGetComponent<IDamaged>(out var Damag);
            Damag?.Damage();
        }
    }
    protected virtual void Explosion()
    {
        rigidBody.isKinematic = true;
        this.enabled = false;
        expolosionEffect.Play();
        Destroy(gameObject, 20);
    }
    public Rigidbody GetRigidBody()
    {
        return rigidBody;
    }
    public void TransferTargetForAmmo(Transform _target)
    {
        target = _target;
    }
}
