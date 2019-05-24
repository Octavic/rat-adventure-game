using UnityEngine;
using System.Collections;

public class Pit : MonoBehaviour
{
	public float ShakeIntensity;
	public float ShakeDuration;

	public void ShakeCamera()
	{
		MainCamera.CurrentInstance.Shake(this.ShakeIntensity, this.ShakeDuration);
		this.GetComponent<AudioSource>().Play();
	}
}
