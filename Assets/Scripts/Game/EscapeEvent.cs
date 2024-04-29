using UnityEngine;
using System.Collections;

/// Escape or Back event
public class EscapeEvent : MonoBehaviour
{
		/// <summary>
		/// The name of the scene to be loaded.
		/// </summary>
		public string sceneName;

		/// <summary>
		/// Whether to leave the application on escape click.
		/// </summary>
		public bool leaveTheApplication;

		void Update ()
		{
				if (Input.GetKeyDown (KeyCode.Escape)) {
						OnEscapeClick ();
				}
		}

		/// <summary>
		/// On Escape click event.
		/// </summary>
		public void OnEscapeClick ()
		{
				if (leaveTheApplication) {
						GameObject exitConfirmDialog = GameObject.Find ("ExitConfirmDialog");
						if (exitConfirmDialog != null) {
								Dialog exitDialogComponent = exitConfirmDialog.GetComponent<Dialog> ();
								if (!exitDialogComponent.animator.GetBool ("On")) {
										exitDialogComponent.Show ();
										//AdsManager.instance.ShowAdvertisment (AdsManager.AdAPI.AdEvent.Event.ON_SHOW_EXIT_DIALOG);
								}
						}
				} else {
						StartCoroutine (SceneLoader.LoadSceneAsync (sceneName));
				}
		}
}