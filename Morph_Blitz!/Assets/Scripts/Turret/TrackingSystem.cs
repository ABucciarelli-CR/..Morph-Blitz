using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingSystem : MonoBehaviour 
{
	public float speed = 3.0f;
	public GameObject m_target;
	Vector3 m_lastKnownPosition = Vector3.zero;
	Quaternion m_lookAtRotation;

	void Start () 
	{
		m_target = GameObject.Find ("Body");
	}

	// Update is called once per frame
	void Update () 
	{
		if(m_target)
		{
			print (m_target.transform.position);
			if(m_lastKnownPosition != m_target.transform.position)
			{
				
				m_lastKnownPosition = m_target.transform.position;
				m_lookAtRotation = Quaternion.LookRotation(m_lastKnownPosition - transform.position, transform.forward);
			}

			if(transform.rotation != m_lookAtRotation)
			{
				transform.rotation = Quaternion.RotateTowards(transform.rotation, m_lookAtRotation, speed * Time.deltaTime);
			}
		}
	}

	bool SetTarget(GameObject target)
	{
		if(!target)
		{
			return false;
		}

		m_target = target;

		return true;
	}
}