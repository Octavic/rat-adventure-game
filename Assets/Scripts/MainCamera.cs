using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour
{
	public float LerpSpeed;
	public float CameraHeight;
	public float CameraDepth;

	public GameObject FocusObject { get; set; }

	public static Camera CameraComp;

	public static MainCamera CurrentInstance
	{
		get
		{
			if (_currentInstance == null)
			{
				_currentInstance = GameObject.FindObjectOfType<MainCamera>();
			}

			return _currentInstance;
		}
	}
	private static MainCamera _currentInstance;

	private float ShakeIntensity;

	/// <summary>
	/// Shakes the camera
	/// </summary>
	public void Shake(float intensity, float duration = 2.0f)
	{
		this.ShakeIntensity = intensity;
		StartCoroutine(this.ClearShake(duration));
	}
	private IEnumerator ClearShake(float duration)
	{
		yield return new WaitForSeconds(duration);
		this.ShakeIntensity = 0;
	}

	// Use this for initialization
	void Start()
	{
		CameraComp = this.GetComponent<Camera>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		var focusObjPosition = FocusObject.transform.position;
		this.transform.position = Vector3.Lerp(
			this.transform.position,
			new Vector3(focusObjPosition.x, focusObjPosition.y + this.CameraHeight, this.CameraDepth),
			this.LerpSpeed
		);

		if (this.ShakeIntensity != 0)
		{
			var randomOffset = new Vector3(Random.value - 0.5f, Random.value - 0.5f).normalized * this.ShakeIntensity;
			this.transform.position += randomOffset;
		}
	}
}
