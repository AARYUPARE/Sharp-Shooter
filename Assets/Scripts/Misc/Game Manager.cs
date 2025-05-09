using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text enemiesLeftText;
    [SerializeField] GameObject youWinText;

    int enemiesLeft;

    const string ENEMIES_LEFT_STRING = "Enemies Left: ";

    public void AdjustEnemiesLeft(int amount)
    {
        enemiesLeft += amount;
        enemiesLeftText.text = ENEMIES_LEFT_STRING + enemiesLeft.ToString();
       
        if(enemiesLeft < 4)
        {
            Debug.Log("Checking");
            EnemyHealth enemyHealth = FindAnyObjectByType<EnemyHealth>();
            if(!enemyHealth)
            {
                Debug.Log("Gliched");
                enemiesLeft = 0;
                enemiesLeftText.text = ENEMIES_LEFT_STRING + enemiesLeft.ToString();
                youWinText.SetActive(true);
            }
            else
            {
                Debug.Log(enemyHealth.gameObject.name);
                Debug.Log(enemyHealth.gameObject.transform.position);
            }
        }

        if(enemiesLeft <= 0)
        {
            youWinText.SetActive(true);
        }
    }

    public void RestartLevelButton()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    public void QuitButton()
    {
        Debug.LogWarning("Does not work in the unity editor! You silly goose!");
        Application.Quit();
    }
}
