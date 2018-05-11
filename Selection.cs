using UnityEngine;
using UnityEngine.SceneManagement;

public class Selection : MonoBehaviour {

    //the level to load
    public string levelToLoad = "Start_Menu";

    //creates objects for the nextMenu on the same scene
    public GameObject[] theObjects;

    //option that exits the game
    public bool exiting = false;

    //option that creates objects for the nextMenu on the same scene
    public bool nextMenu = false;

    //option that loads a new scene
    public bool newScene = true;

    //on mouse click down exicute an option
    private void OnMouseDown()
    {

        //option that creates objects for the nextMenu on the same scene
        if (nextMenu)
        {
            foreach (GameObject item in theObjects)
            {
                Instantiate(item);
            }
            Destroy(gameObject);
        }

        //option that loads a new scene
        if (newScene)
        {
            SceneManager.LoadScene(levelToLoad);
        }

        //option that exits the game
        if (exiting)
        {
            Application.Quit();
        }

    }

    // Update is called once per frame
    void Update () {

        //if a key is pressed then go to the nextMenu on this scene
        if (nextMenu)
        {
            if (Input.anyKey)
            {
                foreach (GameObject item in theObjects)
                {
                    Instantiate(item);
                }
                Destroy(gameObject);
            }
        }

        //option that exits the game auto on esc press
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

    }

    //change the scene
    public void ChangeScene()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
