using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ShapesManager : MonoBehaviour
{
		/// <summary>
		/// The shapes list.
		/// </summary>
		public List<Shape> shapes = new List<Shape> ();
		
		/// <summary>
		/// General single instance.
		/// </summary>
		public static ShapesManager instance;

		void Awake ()
		{
				if (instance == null) {
						instance = this;
						DontDestroyOnLoad (gameObject);
				} else {
						Destroy (gameObject);
				}
		}

		[System.Serializable]
		public class Shape
		{
				public bool showContents = true;
				public GameObject gamePrefab;
		}
}
