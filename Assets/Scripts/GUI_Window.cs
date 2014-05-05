using UnityEngine;
using System.Collections;

public class GUI_Window : MonoBehaviour {

	public Rect windowSize = new Rect (15, 15, 350, 100);
	public Treasure script;
	public string slot1;
	public string slot2;
	public string slot3;

	public string[] slots; 

	public int panel_num = 0;

	// Use this for initialization
	void Start () {
		slots = new string[3];
		slots[0] = "slot1";
		slots[1] = "slot2";
		slots[2] = "slot3";
	}
	private void OnGUI() {
		GUI.Window (0, windowSize, InfoPane, "Info Window");
	}

	private void InfoPane(int id) {

		GUI.Label(new Rect(20, 20, 150, 50), slots[0]);
		GUI.Label(new Rect(20, 35, 150, 50), slots[1]);
		GUI.Label(new Rect(20, 50, 150, 50), slots[2]);
	}

	void Update () {
		if ( Input.GetKeyDown(KeyCode.I) ) {			
			Debug.Log("The I key has been pressed");
			panel_num = (panel_num + 1) % 2;
		}

		switch (panel_num)
		{
		case 0:
			
			int treasures = GameObject.FindGameObjectsWithTag("treasure").Length;
			int treasures_tagged = 0;
			
			foreach (GameObject treasure in GameObject.FindGameObjectsWithTag("treasure")) {
				if (treasure.GetComponent<Treasure>().isTagged) {
					treasures_tagged++;
				}
			}
			
			
			slots[0] = "Treasures: " + treasures;
			slots[1] = "Treasures Tagged: " + treasures_tagged;
			slots[2] = "slot3";
			break;
		case 1:
			slots[0] = "slot4";
			slots[1] = "slot5";
			slots[2] = "slot6";
			break;
		default:
			// do nothing
			break;
		}

	}
}
