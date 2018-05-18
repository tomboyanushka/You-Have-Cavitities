using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : MonoBehaviour
{
    bool playerIsDead;
    
    public int candyCounter = 0;
    public Text score;
    Transform target;
    NavMeshAgent agent;
    public float currentHealth = 100f;
    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        DisplayScore();
    }


    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }

    void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
            FaceTarget();

           
        }
    }

    public void FollowTarget(Interact currentTarget)
    {

        agent.stoppingDistance = currentTarget.radius * 0.5f;
        agent.updateRotation = false;
        target = currentTarget.transform;

    }

    public void StopFollowingTarget()
    {
        agent.stoppingDistance = 0f;
        agent.updateRotation = true;
        target = null;

    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion look = Quaternion.LookRotation(new Vector3(direction.x, 0.0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, look, Time.deltaTime * 5f);

    }

    void OnTriggerEnter(Collider collider)
    {
        //if (collider.transform.tag == "Candy")
        //{
        //    candyCounter++;
        //}
        if (collider.gameObject.tag == "Enemy")
        {
            gameObject.SetActive(false);
            playerIsDead = true;
            score.text = "GAME OVER, MAN";
        }
        else if (collider.gameObject.tag == "Candy")
        {
            collider.gameObject.SetActive(false);
            candyCounter++;
            DisplayScore();
            if (candyCounter >= 5)
                DisplayWin();

        }
    }

    void DisplayScore()
    {
        score.text = "Score: " + candyCounter.ToString();
    }

    void DisplayWin()
    {
        
     score.text = "CONGRATS YOU HAVE CAVITIES";
        
    }
}


