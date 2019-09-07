using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	//stores the timer and score
	//displays the score and timer bar and the game over text

	public Text scoreText;
	public Text timerText;
	public Text gameOverText;

	public Text finalScoreText;
	public Text finalTimeText;
	public Text finalPointsText;

	public static int score;
	private float timer;
	private float startTime;

	private float finalTime;
	public static bool gameOver;
	private bool timerStopped;

	public void Start (){
		score = 0;
		startTime = Time.time * 100;
		gameOver = false;
	}
		
	public void Update(){
		scoreText.text = "Score: " + score.ToString ();
		timer = (Time.time * 100) - startTime ;

		timerText.text = "TIME: " + ((int) timer).ToString ();

		if (gameOver && !timerStopped) {
			stopTimer ();
			gameOverText.text = "GAME OVER";
			timerText.text = "TIME: " + ((int) finalTime).ToString ();
		}

		if (gameOver && timerStopped) {
			gameOverText.text = "GAME OVER";
			timerText.text = "TIME: " + ((int) finalTime).ToString ();

			//game over screen points
			finalPointsText.text = "SCORE\t\t\t\t" + ((int) score).ToString ();
			finalTimeText.text = "TIME\t\t\t\t" + ((int) finalTime).ToString ();
			finalScoreText.text = "TOTAL\t\t\t" + ((int) (score + finalTime)).ToString ();
		}
	}

	public void stopTimer(){
		finalTime = timer;
		timerStopped = true;
	}
}
