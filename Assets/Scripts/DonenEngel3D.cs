using UnityEngine;

public class DonenEngel3D : MonoBehaviour
{
	public float donusHizi = 10f;

	// Mouse ile sürükleyince çalýþýr
	void OnMouseDrag()
	{
		Debug.Log("Týklanýyor ve Kod Çalýþýyor!");
		// Mouse'un saða-sola hareketini al
		float rotX = Input.GetAxis("Mouse X") * donusHizi;

		// Objeyi Y ekseninde (Kendi etrafýnda) döndür
		// Senin silindirin yan yattýðý için Y ekseni pervane dönüþü saðlar
		transform.Rotate(0, 0, rotX);
	}
}