using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour {

    public Transform target;
    NavMeshAgent agent;

    int enemyHP = 3;

    void Start () {
        GameObject player = GameObject.Find("FPSController");
        target = player.transform;
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        agent.SetDestination(target.position);
	}

    void Damage() {
        enemyHP -= 1;
        if (enemyHP == 0) {
			GameObject player = GameObject.Find("FPSController");
            player.SendMessage("DefeatEnemy");
			Destroy(this.gameObject);
        }
    }
	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "FPSController") {
            other.SendMessage("PlayerDamage");
            Destroy(this.gameObject);
        }
	}
}
