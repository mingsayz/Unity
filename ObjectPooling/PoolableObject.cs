using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PoolableObject : MonoBehaviour 
{
	protected ObjectPool Pool;

	public virtual void Create (ObjectPool pool)
	{
		Pool = pool;

		gameObject.SetActive(false);
	}

	public virtual void Push ()
	{
		Pool.PushObject(this);
	}

} 