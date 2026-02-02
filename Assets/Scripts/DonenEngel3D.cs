using UnityEngine;

public class DonenEngel3D : MonoBehaviour
{
	[Header("Hýz Ayarlarý")]
	public float pcHizi = 150f;         // Bilgisayar için dönüþ hýzý
	public float mobilHizi = 0.5f;      // Telefon için hassasiyet (Daha düþük olmalý)

	[Header("Eksen Ayarý")]
	public Vector3 donusEkseni = new Vector3(1, 0, 0); // Kýrmýzý eksen (X) etrafýnda döner

	void OnMouseDrag()
	{
		float donusMiktari = 0f;

		// 1. DURUM: Mobil (Dokunmatik Ekran) Kontrolü
		if (Input.touchCount > 0)
		{
			Touch parmak = Input.GetTouch(0);

			// Parmak hareket ediyorsa hesapla
			if (parmak.phase == TouchPhase.Moved)
			{
				// deltaPosition: Parmaðýn son karesinden bu yana ne kadar kaydýðý
				donusMiktari = parmak.deltaPosition.y * mobilHizi;
			}
		}
		// 2. DURUM: Bilgisayar (Mouse) Kontrolü
		else
		{
			// Mouse Y: Farenin yukarý-aþaðý hareketi
			donusMiktari = Input.GetAxis("Mouse Y") * pcHizi * Time.deltaTime;
		}

		// Yönü tersine çevirmek için baþýna eksi (-) koyduk
		// Eðer ters dönerse eksiyi kaldýr
		transform.Rotate(donusEkseni * -donusMiktari);
	}
}