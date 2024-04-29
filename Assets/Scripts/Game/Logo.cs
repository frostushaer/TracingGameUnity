using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class Logo : MonoBehaviour
{
	/// <summary>
	/// The sleep time.
	/// </summary>
	public float sleepTime = 5;

	/// <summary>
	/// The name of the scene to load.
	/// </summary>
	public string nextSceneName;

	// Use this for initialization
	void Start ()
	{
		Invoke ("LoadScene", sleepTime);
		//AdsManager._AdMobInstance.showBannerAd();
	}

	private void LoadScene ()
	{
		if (string.IsNullOrEmpty (nextSceneName)) {
			return;
		}
		SceneManager.LoadScene(nextSceneName);
	}
}
