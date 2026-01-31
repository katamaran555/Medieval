using UnityEngine;

public class DonenEngel3D : MonoBehaviour
{
	public float donusHizi = 150f;
	public Vector3 donusEkseni = new Vector3(1, 0, 0);

	void OnMouseDrag()
	{
		// Mouse Y hareketini alýyoruz
		float fareHareketi = Input.GetAxis("Mouse Y") * donusHizi * Time.deltaTime;

		// Baþýna eksi (-) koyarak yönü tersine çeviriyoruz
		// Eðer zaten eksi varsa, eksiyi kaldýrýp dene
		transform.Rotate(donusEkseni * -fareHareketi);
	}
}