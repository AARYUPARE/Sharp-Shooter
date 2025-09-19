using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [System.Serializable]
    public class EnemyMulList
    {
        public int count;
        public float mul;
    }

    [SerializeField] TMP_Text enemiesLeftText;
    [SerializeField] GameObject youWinText;

    [SerializeField] EnemyMulList[] enemyMulList;

    Dictionary<int, float> enemyMulStat = new Dictionary<int, float>(); 

    int enemiesLeft;

    const string ENEMIES_LEFT_STRING = "Enemies Left: ";

    private void Awake()
    {
        foreach(var mulStat in enemyMulList)
        {
            enemyMulStat.Add(mulStat.count, mulStat.mul);
        }
    }

    public void AdjustEnemiesLeft(int amount)
    {
        enemiesLeft += amount;
        enemiesLeftText.text = ENEMIES_LEFT_STRING + enemiesLeft.ToString();

        if(enemyMulStat.ContainsKey(enemiesLeft))
        {
            EnemyHealth.AdjustMultiplier(enemyMulStat[enemiesLeft]);
        }
       
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
