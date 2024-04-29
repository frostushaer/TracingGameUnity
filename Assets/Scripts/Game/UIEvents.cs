using UnityEngine;
using System.Collections;


public class UIEvents : MonoBehaviour
{
		public void AlbumShapeEvent (TableShape tableShape)
		{
				if (tableShape == null) {
						return;
				}

				if (tableShape.isLocked) {
					return;
				}

				TableShape.selectedShape = tableShape;
		        // AdsManager._AdMobInstance.destroyBannerAd();
				LoadGameScene ();
		}

		public void PointerButtonEvent (Pointer pointer)
		{
				if (pointer == null) {
						return;
				}
				if (pointer.group != null) {
						ScrollSlider scrollSlider = GameObject.FindObjectOfType (typeof(ScrollSlider)) as ScrollSlider;
						if (scrollSlider != null) {
								scrollSlider.DisableCurrentPointer ();
								FindObjectOfType<ScrollSlider> ().currentGroupIndex = pointer.group.Index;
								scrollSlider.GoToCurrentGroup ();
						}
				}
		}

		public void LoadGameScene(){
			StartCoroutine(SceneLoader.LoadSceneAsync ("Game"));
		}
    static int maxAds1 = 0;
		public void LoadAlbumScene ()
		{
			StartCoroutine(SceneLoader.LoadSceneAsync ("Album"));
		maxAds1++;
		if (maxAds1 > 4)
		{
			maxAds1 = 0;
			// AdsManager._AdMobInstance.showInterstitial();
		}
	}
	static int maxAds2 = 0;
	public void NextClickEvent ()
		{
			try{
				GameObject.FindObjectOfType<GameManager> ().NextShape ();
			maxAds2++;
			if (maxAds2 > 5)
			{
				maxAds2 = 0;
				// AdsManager._AdMobInstance.showInterstitial();
			}
		}
		catch(System.Exception ex){
            Debug.LogError("Exception caught in NextClickEvent: " + ex.Message);
			}
		}
    public void Policy()
    {
		Application.OpenURL("https://sites.google.com/view/xuan-bui-policy/trang-ch%E1%BB%A7");
    }
		public void PreviousClickEvent ()
		{
			try{
				GameObject.FindObjectOfType<GameManager> ().PreviousShape ();
			}catch(System.Exception ex){
			Debug.LogError("Exception caught in NextClickEvent: " + ex.Message);
			}
		}

		public void SpeechClickEvent ()
		{
				Shape shape = GameObject.FindObjectOfType<Shape> ();
				if (shape == null) {
						return;
				}
				shape.Spell ();
		}
    public void Rate()
    {
		Application.OpenURL("market://details?id=entertainment.writeabcalphabet.vnstore");
		//#if UNITY_ANDROID
		//		Application.OpenURL("market://details?id=YOUR_ID");
		//#elif UNITY_IPHONE
		//	Application.OpenURL("itms-apps://itunes.apple.com/app/idYOUR_ID");
		//#endif
	}
	static int maxAds = 0;
		public void ResetShape ()
		{
				GameManager gameManager = GameObject.FindObjectOfType<GameManager> ();
				if (gameManager != null) {
			//		if(!gameManager.shape.completed){
			//				gameManager.DisableGameManager ();
			//				GameObject.Find ("ResetConfirmDialog").GetComponent<Dialog> ().Show ();
			//		}else{
			//			gameManager.ResetShape();
			//}
			gameManager.ResetShape();
		}
		maxAds++;
        if (maxAds > 2)
        {
			maxAds = 0;
			// AdsManager._AdMobInstance.showInterstitial();
		}
		}

		public void PencilClickEvent (Pencil pencil)
		{
				if (pencil == null) {
						return;
				}
				GameManager gameManager = GameObject.FindObjectOfType<GameManager> ();
				if (gameManager == null) {
						return;
				}
				if (gameManager.currentPencil != null) {
						gameManager.currentPencil.DisableSelection ();
						gameManager.currentPencil = pencil;
				}
				gameManager.SetShapeOrderColor ();
				pencil.EnableSelection ();
		}

		public void ResetConfirmDialogEvent (GameObject value)
		{
				if (value == null) {
						return;
				}
		
				GameManager gameManager = GameObject.FindObjectOfType<GameManager> ();
		
				if (value.name.Equals ("YesButton")) {
						Debug.Log ("Reset Confirm Dialog : Yes button clicked");
						if (gameManager != null) {
								gameManager.ResetShape ();
						}
			
				} else if (value.name.Equals ("NoButton")) {
						Debug.Log ("Reset Confirm Dialog : No button clicked");
				}
				value.GetComponentInParent<Dialog> ().Hide ();
				if (gameManager != null) {
						gameManager.EnableGameManager ();
				}
		}

		public void ResetGame(){
			DataManager.ResetGame ();
		}

		public void LeaveApp(){
			Application.Quit ();
		}
}
