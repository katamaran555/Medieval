using UnityEngine;
using UnityEngine.SceneManagement;

public class BitisNoktasi : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Level Tamamlandı!");
            
            if (LevelManager.Instance != null)
            {
                LevelManager.Instance.NextLevel();
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}