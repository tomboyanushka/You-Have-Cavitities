using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAi : MonoBehaviour
{
    public Transform candy;
    public Transform player;
    private NavMeshAgent agent;
    Ray rayCast;
    RaycastHit hitRay;
    bool follow = false;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(candy.position, Vector3.up, 30 * Time.deltaTime);


        if (Physics.Raycast(transform.position, transform.forward, out hitRay, 30))
        {
            Debug.DrawRay(transform.position, Vector3.up, Color.red);

            if (hitRay.transform.tag == "Player")
            {
                follow = true;

            }
            if (follow == true)
            {

                agent.SetDestination(player.transform.position);
            }
        }

    }


}
