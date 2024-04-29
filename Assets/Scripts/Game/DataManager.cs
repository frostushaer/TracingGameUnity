using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataManager
{
		/// Save the shape stars.
		/// <param name="ID">The ID of the shape.</param>
		/// <param name="stars">Stars.</param>
		public static void SaveShapeStars (int ID, TableShape.StarsNumber stars)
		{
				PlayerPrefs.SetInt ("Shape-" + ID + "-Stars", CommonUtil.ShapeStarsNumberEnumToIntNumber (stars));
				PlayerPrefs.Save ();
		}

		/// Get the shape stars.
		/// <returns>The shape stars.</returns>
		/// <param name="ID">The ID of the shape.</param>
		public static TableShape.StarsNumber GetShapeStars (int ID)
		{
				TableShape.StarsNumber stars = TableShape.StarsNumber.ZERO;
				string key = "Shape-" + ID + "-Stars";
				if (PlayerPrefs.HasKey (key)) {
						stars = CommonUtil.IntNumberToShapeStarsNumberEnum (PlayerPrefs.GetInt (key));
				}
				return stars;
		}

		/// Save the color of the shape path.
		/// <param name="ID">The ID of the shape.</param>
		/// <param name="from">From.</param>
		/// <param name="to">To.</param>
		/// <param name="color">Color.</param>
		public static void SaveShapePathColor (int ID, int from, int to, Color color)
		{
				PlayerPrefs.SetString ("Shape-" + ID + "-Path-" + from + "-" + to, color.r + "," + color.g + "," + color.b + "," + color.a);
				PlayerPrefs.Save ();
		}

		/// Get the color of the shape path.
		/// <returns>The shape path color.</returns>
		/// <param name="ID">The ID of the shape.</param>
		/// <param name="from">From.</param>
		/// <param name="to">To.</param>
		public static Color GetShapePathColor (int ID, int from, int to)
		{
				Color color = Color.white;
				string key = "Shape-" + ID + "-Path-" + from + "-" + to;
				if (PlayerPrefs.HasKey (key)) {
						color = CommonUtil.StringRGBAToColor (PlayerPrefs.GetString (key));
				}
				return color;
		}

		/// Determine whether the shape is locked or not.
		/// <returns><c>true</c> if is shape locked; otherwise, <c>false</c>.</returns>
		/// <param name="ID">The ID of the shape.</param>
		public static bool IsShapeLocked (int ID)
		{
				bool isLocked = true;
				string key = "Shape-" + ID + "-isLocked";
				if (PlayerPrefs.HasKey (key)) {
						isLocked = CommonUtil.ZeroOneToTrueFalseBool (PlayerPrefs.GetInt (key));
				}
				return isLocked;
		}

		/// Save the shape locked status.
		/// <param name="ID">The ID of the shape.</param>
		/// <param name="isLocked">Whether the shape is locked or not.</param>
		public static void SaveShapeLockedStatus (int ID, bool isLocked)
		{
				PlayerPrefs.SetInt ("Shape-" + ID + "-isLocked", CommonUtil.TrueFalseBoolToZeroOne (isLocked));
				PlayerPrefs.Save ();
		}

		/// Reset the game.
		public static void ResetGame ()
		{
			PlayerPrefs.DeleteAll ();
		}
}