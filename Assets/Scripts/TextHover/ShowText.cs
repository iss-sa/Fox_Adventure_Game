using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowText : MonoBehaviour
{
    [SerializeField]
	private bool _guiOn; //rendering and handling the gui event -> if true text visible; if false text toggled off


	[Header("The text to Display on Trigger")]
    [SerializeField]
	private string _text = "Text"; // text to be shown

	[SerializeField]
	private Rect _boxSize = new Rect( 0, 0, 200, 100); // box size in which text is shown

	[SerializeField]
	private GUISkin _customSkin; // the look of the text



	// if something collides with object, display GUI
	void OnTriggerEnter() 
	{
		_guiOn = true;
	}

    // if something stops colliding with object, turn GUI off
	void OnTriggerExit() 
	{
		_guiOn = false;
	}

    // function for showing text
	void OnGUI()
	{

		if (_customSkin != null)
		{
			GUI.skin = _customSkin;
		}

		if (_guiOn == true)
		{
			// Make a group on the center of the screen
			GUI.BeginGroup (new Rect ((Screen.width - _boxSize.width) / 2, (Screen.height - _boxSize.height) / 2, _boxSize.width, _boxSize.height));
			// All rectangles are now adjusted to the group. (0,0) is the topleft corner of the group.

			GUI.Label(_boxSize, _text);

			// End the group we started above. This is very important to remember!
			GUI.EndGroup ();

		}
	}
}
