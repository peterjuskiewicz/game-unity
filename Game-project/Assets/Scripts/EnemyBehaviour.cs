using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour
{
    GameObject player;               // Reference to the player's position.
    NavMeshAgent nav;               // Reference to the nav mesh agent.


    void Awake ()
    {
        // Set up the references.
        player = GameObject.FindGameObjectWithTag("Player");
        nav = GetComponent <NavMeshAgent> ();
        Debug.Log(GameObject.FindGameObjectWithTag("Player"));
    }


    void Update ()
    {

            // ... set the destination of the nav mesh agent to the player.
            nav.SetDestination (player.transform.position);

    }
}