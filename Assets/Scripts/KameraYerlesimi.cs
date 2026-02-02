using UnityEngine;

public class KameraYerlesimi : MonoBehaviour
{
	void Start()
	{
		// Sahnedeki "Main Camera"yý bul
		Camera anaKamera = Camera.main;

		if (anaKamera != null)
		{
			// Kamerayý bu objenin (KameraPozisyonu) olduðu yere ve açýya ýþýnla
			anaKamera.transform.position = transform.position;
			anaKamera.transform.rotation = transform.rotation;
		}
	}
}