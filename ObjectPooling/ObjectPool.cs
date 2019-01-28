using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
	[SerializeField]
	private PoolableObject poolObj;
	[SerializeField]
	private int allocateCount;
	private Stack<PoolableObject> stack = new Stack<PoolableObject>();

	void Start() {
		Allocate ();
	}

	public void Allocate () {
		for (int i = 0; i < allocateCount; i++) {
			PoolableObject tObj = Instantiate (poolObj);
			tObj.Create (this);
			stack.Push(tObj);
		}
	}

	public GameObject PopObject () {
		PoolableObject obj = stack.Pop();
		obj.gameObject.SetActive(true);
		return obj.gameObject;
	}

	public void PushObject (PoolableObject obj) {
		obj.gameObject.SetActive(false);
		stack.Push(obj);
	}
}