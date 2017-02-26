using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RayTracing : MonoBehaviour {
    float scopeRadius = 10f;
    float scopeAngle = 30f;

    List<GameObject> findInRadius (List<GameObject> players)
    {
        List<GameObject> inRadius = new List<GameObject>();
        foreach (GameObject player in players)
        {
            float dist = Vector3.Distance(player.transform.position, this.transform.position);
            if (dist <= scopeRadius) {
                inRadius.Add(player);
            }
        }
        return inRadius;
    }

    List<GameObject> findInAngle(List<GameObject> players)
    {
        List<GameObject> inAngle = new List<GameObject>();
        foreach (GameObject player in players)
        {
            Vector3 vectorToPlayer = player.transform.position - this.transform.position;
            float angle = Vector3.Angle(vectorToPlayer, transform.forward);
            if (angle <= scopeAngle)
            {
                inAngle.Add(player);
            }
        }
        return inAngle;
    }

    List<GameObject> findWithRayCasting(List<GameObject> players)
    {
        List<GameObject> inRayCasting = new List<GameObject>();
        foreach (GameObject player in players)
        {
            RaycastHit[] hits;
            hits = Physics.RaycastAll(transform.position, transform.forward, 10.0F);
            if (hits.Length > 0) {
                RaycastHit hit = hits[0];
                if (hit.transform.tag == "Player")
                {
                    inRayCasting.Add(player);
                }
            }
        }
        return inRayCasting;
    }

    void ChangeColor(List<GameObject> players, Color col)
    {
        foreach (GameObject player in players)
        {
            player.GetComponent<Renderer>().material.color = col;
        }
    }

    GameObject findClosest ()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = this.transform.position;
        foreach (GameObject player in players)
        {
            Vector3 diff = player.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = player;
                distance = curDistance;
            }
        }
        closest.GetComponent<Renderer>().material.color = Color.green;    
        return closest;
    }

	// Use this for initialization
	void Start () {

    }

    // Update is called once per frame
    void Update () {
        //findClosest();
        List<GameObject> players = GameObject.FindGameObjectsWithTag("Player").ToList();
        ChangeColor(players, Color.yellow);
        List<GameObject> playersRadius = findInRadius(players);
        List<GameObject> playersAngle = findInAngle(playersRadius);
        List<GameObject> playersRayCasting = findWithRayCasting(playersAngle);
        ChangeColor(playersRayCasting, Color.blue);
    }
}
