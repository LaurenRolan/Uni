using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	#region Singleton
	private static GameManager instance;
	public static GameManager Instance {
		get { return instance; }
	}
	#endregion

	#region Fields
	[Header("Settings")]
	[SerializeField] private int livesQuantity = 3;
	[SerializeField] private int bricksQuantity = 20;
	[SerializeField] private float resetDelay = 1f;

	[Space]
	[Header("UI")]
	[SerializeField] private Text lives;
	[SerializeField] private GameObject gameOver;
	[SerializeField] private GameObject won;

	[Space]
	[Header("Prefabs")]
	[SerializeField] private GameObject bricks;
	[SerializeField] private GameObject deathParticules;
	[SerializeField] private GameObject paddle;
	#endregion

	#region Private members
	private GameObject clonePaddle;
	#endregion

	#region Monobehaviour messages
	void Start () {
		if(instance != null) {
			Destroy(gameObject); //go sur lequel monob est appliqué
		}
		instance = this;

		Setup();
	}
	#endregion

	void Setup() {
		SetupPaddle();
		Instantiate
			(
				bricks,
				transform.position, //Par rapport au GameManager
				Quaternion.identity
			);

	}

	public void Reset(float delay) {
		Time.timeScale *= 4;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	private void SetupPaddle() {
		clonePaddle = Instantiate<GameObject>
			(
				paddle,
				paddle.transform.position,
				Quaternion.identity
			);
	}

	private void CheckGameOver() {
		if(livesQuantity < 1) {
			gameOver.SetActive(true);
			Time.timeScale /= 4;
			Invoke("Reset", resetDelay);
		}
		
		if (bricksQuantity == 0) {
			won.SetActive(true);
			Time.timeScale /= 4;
			Invoke("Reset", resetDelay);
		}
	}

	private void LoseLife() {
		livesQuantity--;
		lives.text = string.Format("Lives : {0}", livesQuantity);
		deathParticules = Instantiate<GameObject>
			(
				deathParticules,
				clonePaddle.transform.position,
				Quaternion.identity
			);
		Destroy(clonePaddle);
		Invoke("SetupPaddle", resetDelay);
		CheckGameOver();
	}

	public void DestroyBrick() {
		bricksQuantity--;
		CheckGameOver();
	}
	
	// Update is called once per frame
	public void Update () {
		
	}
}
