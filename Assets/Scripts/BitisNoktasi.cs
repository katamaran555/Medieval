using UnityEngine;
using UnityEngine.SceneManagement; // Sahne yönetimi için þart

public class BitisNoktasi : MonoBehaviour
{
	void OnTriggerEnter(Collider girenSey)
	{
		// Giren þeyin etiketi "Top" mu? (Topuna Tag vermeyi unutma!)
		// Veya direkt ismine bakabiliriz:
		if (girenSey.gameObject.name == "Top" || girenSey.CompareTag("Player"))
		{
			Debug.Log("TEBRÝKLER! BÖLÜM BÝTTÝ.");

			// 1 saniye bekle sonra yeniden baþlat (Hemen kesilmesin)
			Invoke("YenidenBaslat", 1f);
		}
	}

	void YenidenBaslat()
	{
		// Þu anki sahneyi baþtan yükle
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}