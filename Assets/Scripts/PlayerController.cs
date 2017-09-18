using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public Camera mainCamera;
    public Text score;
    private int count;

	// Use this for initialization
	void Start () {
        
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)){
			Shot();
		}
            
    }

    void Shot() {
        int distance = 50;
        Vector3 center = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = mainCamera.ScreenPointToRay(center);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray,out hitInfo, distance)) {

            if (hitInfo.collider.tag == "Enemy") {
                count += 1;
                score.text = count.ToString();
                Renderer _renderer = hitInfo.collider.GetComponent<Renderer>();
                _renderer.material.color = new Color(1f, 0, 0, 1f);

            }
        }
    }
}
