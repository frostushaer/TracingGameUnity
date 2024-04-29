using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
public class Area : MonoBehaviour
{
		/// Area animator.
		private static Animator AreaAnimator;

		// Use this for initialization
		void Awake ()
		{
				///Setting up the references
				if (AreaAnimator == null) {
						AreaAnimator = GetComponent<Animator> ();
				}
		}

		/// When the GameObject becomes visible
		void OnEnable ()
		{
				///Hide the Area
				Hide ();
		}

		///Show the Area
		public static void Show ()
		{
				if (AreaAnimator == null) {
						return;
				}
				AreaAnimator.SetTrigger ("Running");
		}
		///Hide the Area
		public static void Hide ()
		{
			if(AreaAnimator!=null)
				AreaAnimator.SetBool ("Running", false);
		}
}