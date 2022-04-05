using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Cannon : MonoBehaviour
{
	[SerializeField] protected Ammo ammoPrefab;
	[SerializeField] protected Transform shotPoint;
	[SerializeField] protected Transform shotPointEffects;
	[SerializeField] protected Transform shotEffect;
	[SerializeField] public bool isReloading;
	[SerializeField] [Range(0, 5)] float reloadDelay;
	protected Transform target;

	protected abstract void Fire();
	protected virtual void Reloading() 
	{
		isReloading = true;

		StartCoroutine(ReloadCorutine());
		IEnumerator ReloadCorutine()
		{
			yield return new WaitForSeconds(reloadDelay);

			isReloading = false;
		}
	}
}
