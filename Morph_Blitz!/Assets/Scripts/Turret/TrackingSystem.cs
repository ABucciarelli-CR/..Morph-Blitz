using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingSystem : MonoBehaviour 
{
	public float speed = 3.0f;
	public GameObject m_target;
	public float lookingRange = 0.5f;
	Vector3 m_lastKnownPosition = Vector3.zero;
	Quaternion m_lookAtRotation;


	void Start () 
	{
		m_target = GameObject.Find ("HitTarget");
	}

	// Update is called once per frame
	void Update () 
	{
		if(m_target)
		{
			if(m_lastKnownPosition != m_target.transform.position)
			{
				m_lastKnownPosition = new Vector3(Random.Range(m_target.transform.position.x-lookingRange, m_target.transform.position.x+lookingRange), Random.Range(m_target.transform.position.y-lookingRange, m_target.transform.position.y+lookingRange), Random.Range(m_target.transform.position.z-lookingRange, m_target.transform.position.z+lookingRange));
				m_lookAtRotation = Quaternion.LookRotation(m_lastKnownPosition - transform.position);
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