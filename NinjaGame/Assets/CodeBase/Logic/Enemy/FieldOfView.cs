using System;
using System.Collections;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float Radius;
    [Range(0,360)]
    public float Angle;

    public GameObject PlayerPref;

    public LayerMask TargetMask;
    public LayerMask ObstructionMask;

    public bool CanSeePlayer;

    private void Start()
    {
        PlayerPref = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRouitine());
    }

    private IEnumerator FOVRouitine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, Radius, TargetMask);
        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward,directionToTarget)< Angle / 2)
            {
                float distanceToTaget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position,directionToTarget,distanceToTaget,ObstructionMask))
                {
                    CanSeePlayer = true;
                }
                else
                {
                    CanSeePlayer = false;
                }
            }
            else
            {
                CanSeePlayer = false;
            }
        }
        else if (CanSeePlayer)
        {
            CanSeePlayer = false;
        }
    }
}