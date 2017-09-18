using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    public Camera mainCamera;
    public AudioSource gunSound;
    int playerHP = 3;
	public Text score;
    public Text playerHPText;
	private int count;

	// Use this for initialization
	void Start () {
        
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)){
			Shot();
            gunSound.Play();
		}
            
    }
    void PlayerDamage() {
        playerHP -= 1;
        playerHPText.text = playerHP.ToString();
        if (playerHP == 0) {
            SceneManager.LoadScene("GameOver");
        }

    }
    void Shot() {
        int distance = 50;
        Vector3 center = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = mainCamera.ScreenPointToRay(center);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, distance))
        {

            if (hitInfo.collider.tag == "Enemy")
            {

                //Renderer _renderer = hitInfo.collider.GetComponent<Renderer>();
                //_renderer.material.color = new Color(1f, 0, 0, 1f);
                hitInfo.collider.SendMessage("Damage");

            }
        }
    }

    void DefeatEnemy() {
		count += 1;
		score.text = count.ToString();
    }
}
