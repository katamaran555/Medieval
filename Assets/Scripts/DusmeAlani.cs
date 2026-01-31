using UnityEngine;
using UnityEngine.SceneManagement;

public class DusmeAlani : MonoBehaviour
{
	void OnTriggerEnter(Collider girenSey)
	{
		// Giren þey "Top" ise
		// (Topunun isminin tam olarak "Top" olduðundan emin ol, yoksa çalýþmaz)
		if (girenSey.gameObject.name == "Top" || girenSey.CompareTag("Player"))
		{
			Debug.Log("YANDIN! Top boþluða düþtü.");

			// Sahneyi anýnda yeniden baþlat
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}