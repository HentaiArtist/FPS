using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum PatrolState
{
	Idle,
    Patrol,
    Persuit,
    Fight
}

public class Patrol : MonoBehaviour {
	public List<Transform> wayPoint;
	public int curWayPoint;

    public Transform Player;
    public int dist;
    public float speedRotation;
    public float speedMove;
    public float MobFOV = 60;

	[Space(10)]
	public string AnimatorKey = "ZElupa";

	NavMeshAgent agent;
	PatrolState curerntState;
	Animator anim;



    void Update()
    {
		if (DoesSeePlayer ()) {
			Pursuit ();
		} else
			anim.SetInteger (AnimatorKey, 0);
    }

      void Start()
    {
       
        agent = GetComponent<NavMeshAgent>();

        anim = GetComponent<Animator> ();
    }

    bool DoesSeePlayer()
    {
        if (agent == null)
            return false;

		Vector3 directionToPlayer = Player.transform.position - transform.position;
		//Debug.Log (directionToPlayer.magnitude);
		//Debug.Log (Vector3.SqrMagnitude(directionToPlayer));
		//Debug.Log(Vector3.Dot(transform.forward, directionToPlayer.normalized));
        return Vector3.SqrMagnitude(directionToPlayer) < dist * dist
			&& Vector3.Dot(transform.forward, directionToPlayer.normalized) > Mathf.Cos(MobFOV);
    }

    void Pursuit()
	{
		anim.SetInteger (AnimatorKey, 1);

        Vector3 Rotation = Player.position - transform.position;
        Quaternion q = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Rotation), speedRotation * Time.deltaTime);

        Vector3 angles = q.eulerAngles;
        angles.x = 0;
        angles.z = 0;
        transform.rotation = Quaternion.Euler(angles);

        //transform.Translate(transform.forward * speedMove * Time.deltaTime);
        Vector3 PointA = transform.position + transform.forward * speedMove * Time.deltaTime;
        Vector3 finalDestination = (PointA + Player.transform.position) * 0.5f;
        agent.SetDestination(finalDestination);
    }

    void Patrol_()
	{
		if (wayPoint.Count > 1) 
		{
			if (wayPoint.Count > curWayPoint)
			{
				agent.SetDestination (wayPoint [curWayPoint].position);
				float distance = Vector3.Distance(transform.position, wayPoint [curWayPoint].position);

				if (distance > 2.5f) 
				{
					
				}
				else if (distance <= 2.5f && distance >= 1f)
				{
					Vector3 direction = (wayPoint [curWayPoint].position).normalized;
					Quaternion lookRotation = Quaternion.LookRotation (new Vector3 (direction.x, 0, direction.z));
					transform.rotation = Quaternion.Slerp (transform.rotation, lookRotation, Time.deltaTime * 10);
				}
			}
	        else if (wayPoint.Count == curWayPoint)
		    {
				
		    }
		} 
	    else if (wayPoint.Count == 1)
		{
			
		} 
		else 
		{
			
		}
	}
}
