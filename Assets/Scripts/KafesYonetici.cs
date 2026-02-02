using UnityEngine;

public class KafesYonetici : MonoBehaviour
{
	public Animator kapakAnim; // Cage.001 buraya sürüklenecek
	public Rigidbody topRB;    // Topun Rigidbody'si buraya sürüklenecek
	private bool basladiMi = false;

	void OnMouseDown()
	{
		if (!basladiMi)
		{
			// 1. Kapaðý aç
			kapakAnim.Play("KapakAcilma");

			// 2. Topu serbest býrak
			topRB.isKinematic = false;
			topRB.useGravity = true;

			basladiMi = true;
		}
	}
}