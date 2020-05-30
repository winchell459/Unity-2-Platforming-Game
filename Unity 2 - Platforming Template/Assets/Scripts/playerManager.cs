using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerManager : MonoBehaviour
{
    //day-3 remove --------------------------------------------------
    //private List<Collectable> inventory = new List<Collectable>();

    public Text inventoryText;
    public Text descriptionText;
    private int currentIndex;

    //day 3 remove -----------------------------------------------------
    // Player specific variables
    //private int health;
    //private int score;

    //day 3 add ------------------------------------------------------
    public PlayerInfo info;
    //must now add info. in front of every reference to inventory, health an score to remove errors

    // Boolean values
    private bool isGamePaused = false;

    // UI stuff
    public Text healthText;
    public Text scoreText;
    public GameObject pauseMenu;
    public GameObject winMenu;
    public GameObject loseMenu;

    // Start is called before the first frame update
    void Start()
    {
        // Makes sure game is "unpaused"
        isGamePaused = false;
        Time.timeScale = 1.0f;

        // Make sure all menus are filled in
        FindAllMenus();

        //day 3 added ----------------------------------------------
        info = FindObjectOfType<PlayerInfo>();


        //Start player with initial health and score
        info.health = 100;
        info.score = 0;

        
    }

    // Update is called once per frame
    void Update()
    {

        //Day-2 Added --------------------------------------------------
        if(info.inventory.Count == 0) //if inventory is empty
        {
            inventoryText.text = "Current Selection: None";
            descriptionText.text = "";
        }
        else
        {
            inventoryText.text = "Current Selection: " + info.inventory[currentIndex].collectableName + " " + currentIndex.ToString();
            descriptionText.text = "Press [E] to " + info.inventory[currentIndex].description;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            //Using
            if(info.inventory.Count > 0)
            {
                info.inventory[currentIndex].Use();
                info.inventory.RemoveAt(currentIndex); // A, B, C  
                if (info.inventory.Count > 0) currentIndex = currentIndex % info.inventory.Count; //A, B currentIndex = 1
                else currentIndex = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (info.inventory.Count > 0) currentIndex = (currentIndex + 1) % info.inventory.Count;
        }



        healthText.text = "Health: " + info.health.ToString();
        scoreText.text  = "Score:  " + info.score.ToString();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
        if (info.health <= 0)
        {
            LoseGame();
        }
    }

   void FindAllMenus()
    {
        if (healthText == null)
        {
            healthText = GameObject.Find("HealthText").GetComponent<Text>();
        }
        if (scoreText == null)
        {
            Debug.Log(GameObject.Find("ScoreText"));
            scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        }
        if (winMenu == null)
        {
            winMenu = GameObject.Find("WinGameMenu");
            winMenu.SetActive(false);
        }
        if (loseMenu == null)
        {
            loseMenu = GameObject.Find("LoseGameMenu");
            loseMenu.SetActive(false);
        }
        if (pauseMenu == null)
        {
            pauseMenu = GameObject.Find("PauseGameMenu");
            pauseMenu.SetActive(false);
        }

        //Day 3 ------------------------------------------------------------
        if (!inventoryText)
        {
            inventoryText = GameObject.Find("InventoryText").GetComponent<Text>();
        }

        if (!descriptionText)
        {
            descriptionText = GameObject.Find("DescriptionText").GetComponent<Text>();
        }
    }

    public void WinGame()
    {
        Time.timeScale = 0.0f;
        winMenu.SetActive(true);
    }

    public void LoseGame()
    {
        Time.timeScale = 0.0f;
        loseMenu.SetActive(true);
    }

    public void PauseGame()
    {
        if (isGamePaused)
        {
            // Unpause game
            Time.timeScale = 1.0f;
            pauseMenu.SetActive(false);
            isGamePaused = false;
        }
        else
        {
            // Pause game
            Time.timeScale = 0.0f;
            pauseMenu.SetActive(true);
            isGamePaused = true;
        }
    }

    public void ChangeHealth(int value)
    {
        info.health += value;
    }

    public void ChangeScore(int value)
    {
        info.score += value;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Collectable>() != null)
        {
            collision.GetComponent<Collectable>().player = this.gameObject;
            info.inventory.Add(collision.GetComponent<Collectable>());
            //Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
        }

    }

}
