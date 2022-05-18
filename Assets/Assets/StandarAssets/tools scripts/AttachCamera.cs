using UnityEngine;
using System.Collections;

public class AttachCamera : MonoBehaviour
{
	Transform myTransform;//默认private
	public Transform target;//相机跟随的对象
	public Vector3 offset = new Vector3(0, 5, -5);//与对象的偏移量
	
	void Start()
	{
		myTransform = this.transform;
	}
	
	void FixedUpdate()
	{
		if (target != null)
		{
			myTransform.position = target.position + offset ;
			myTransform.LookAt(target.position, Vector3.up);
		}
	}
}
