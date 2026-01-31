using UnityEngine;

public class TopBaslatici : MonoBehaviour
{
	private Rigidbody rb;
	private bool oyunBasladi = false;

	void Start()
	{
		// Topun fizik motorunu al
		rb = GetComponent<Rigidbody>();

		// BAÞLANGIÇTA DONDUR!
		// IsKinematic = true demek "Fizikten etkilenme, havada asýlý kal" demektir.
		rb.isKinematic = true;
	}

	// Topun üzerine týklanýnca çalýþýr
	void OnMouseDown()
	{
		if (!oyunBasladi)
		{
			Baslat();
		}
	}

	void Baslat()
	{
		oyunBasladi = true;

		// Fiziði serbest býrak! Yerçekimi devreye girsin.
		rb.isKinematic = false;

		// Ufak bir dürtme kuvveti (Eðer zemin az eðimliyse iþe yarar)
		// rb.AddForce(Vector3.back * 50f); // Gerekirse açabilirsin

		Debug.Log("Top Yuvarlanmaya Baþladý!");
	}
}