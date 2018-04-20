using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

    public CountDownTimer gameTimer;
    public GameObject playerCube;
    public float restartDelay = 5f;

    Animator anim;
    float restartTimer;

	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameTimer.timer == 200)
        {
            anim.SetTrigger("GameOver");
            restartTimer += Time.deltaTime;
            Destroy(playerCube);

            if (restartTimer >= restartDelay)
            {
                SceneManager.LoadScene("MainMenu");
            }
        }

        if (playerCube.GetComponent<sCollisionScript>().hitCount >= 3)
        {
            anim.SetTrigger("GameOverDeath");
            restartTimer += Time.deltaTime;

            if (restartTimer >= restartDelay)
            {
                Destroy(playerCube);
                SceneManager.LoadScene("MainMenu");
            }
        }
	}
}
