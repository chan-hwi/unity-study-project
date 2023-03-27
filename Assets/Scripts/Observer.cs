using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;
    public GameEnding gameEnding;

    bool m_IsPlayerInRange = false;

    void Update()
    {
        if (!m_IsPlayerInRange) return;

        // To adjust direction towards center of mass of the player
        Vector3 dir = player.position - transform.position + Vector3.up;

        Ray ray = new Ray(transform.position, dir);
        RaycastHit raycastHit;
        if (Physics.Raycast(ray, out raycastHit)) { 
            if (raycastHit.collider.transform == player)
            {
                gameEnding.CaughtPlayer();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            m_IsPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        m_IsPlayerInRange = false;    
    }
}
