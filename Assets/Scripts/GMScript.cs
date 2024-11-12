using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GMScript : MonoBehaviour
{
    public int playerHP;
    public bool hasGameEnded;

    public GameObject gameOverUI;

    //variable for player
    public GameObject playerObject;

    private bool isDead;

    public CollectionManager Cm;

    public GameObject collectionmanagerobject;

    // Start is called before the first frame update
    void Start()
    {
        playerHP = 1200;
        hasGameEnded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHP <= 0 && !isDead)
        {
            isDead = true;
            gameOver();
            Destroy(playerObject = GameObject.Find("Player"));
            hasGameEnded = true;
        }
    }

    public void gameOver()
    {
        gameOverUI.SetActive(true);

        if (collectionmanagerobject.GetComponent<CollectionManager>().Itemcount == 2) 
        {
            gameOverUI.SetActive(true);
            hasGameEnded = true;
        }
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
