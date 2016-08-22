using UnityEngine;

/// <summary>
/// Title screen script
/// </summary>
public class MenuScript : MonoBehaviour
{
	private GUISkin skin;
	public Texture txture;
	public Texture rateus;
	void Start()
	{
		// Load a skin for the buttons
		skin = Resources.Load("GUISkin") as GUISkin;
	}

	void OnGUI()
	{
		const int buttonWidth = 260;
		const int buttonHeight = 200;
		// Set the skin to use
		GUI.skin = skin;
		// Draw a button to start the game
		if (
			GUI.Button(
			// Center in X, 2/3 of the height in Y
			new Rect(
			Screen.width / 2 - (buttonWidth / 2),
			(2 * Screen.height / 3 - 20) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
			),
			txture
			)
			)
		{
			// On Click, load the first level.
			// "Stage1" is the name of the first scene we created.
			Application.LoadLevel("ingame");
		}
		if (
			GUI.Button(
			// Center in X, 2/3 of the height in Y
			new Rect(
			Screen.width / 2 - (buttonWidth / 2),
			(2 * Screen.height / 3 + buttonHeight/2) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
			),
			rateus
			)
			)
		{
			// On Click, load the first level.
			// "Stage1" is the name of the first scene we created.
			string urlString = "market://details?id=" + "com.aura.aa";
			Application.OpenURL(urlString);
		}
	}
}