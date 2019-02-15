using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPuzzle : MonoBehaviour {

	public PowerButton[] buttons;

	void Start () {
		if(buttons.Length == 9){
			PowerButton[] adj1 = new PowerButton[2];
			PowerButton[] adj2 = new PowerButton[3];
			PowerButton[] adj3 = new PowerButton[2];
			PowerButton[] adj4 = new PowerButton[3];
			PowerButton[] adj5 = new PowerButton[4];
			PowerButton[] adj6 = new PowerButton[3];
			PowerButton[] adj7 = new PowerButton[2];
			PowerButton[] adj8 = new PowerButton[3];
			PowerButton[] adj9 = new PowerButton[2];

			adj1[0] = buttons[1];
			adj1[1] = buttons[3];
			adj2[0] = buttons[0];
			adj2[1] = buttons[2];
			adj2[2] = buttons[4];
			adj3[0] = buttons[1];
			adj3[1] = buttons[5];
			adj4[0] = buttons[0];
			adj4[1] = buttons[4];
			adj4[2] = buttons[6];
			adj5[0] = buttons[1];
			adj5[1] = buttons[3];
			adj5[2] = buttons[5];
			adj5[3] = buttons[7];
			adj6[0] = buttons[2];
			adj6[1] = buttons[4];
			adj6[2] = buttons[8];
			adj7[0] = buttons[3];
			adj7[1] = buttons[7];
			adj8[0] = buttons[4];
			adj8[1] = buttons[6];
			adj8[2] = buttons[8];
			adj9[0] = buttons[5];
			adj9[1] = buttons[7];

			buttons[0].setAdjacentButtons(adj1);
			buttons[1].setAdjacentButtons(adj2);
			buttons[2].setAdjacentButtons(adj3);
			buttons[3].setAdjacentButtons(adj4);
			buttons[4].setAdjacentButtons(adj5);
			buttons[5].setAdjacentButtons(adj6);
			buttons[6].setAdjacentButtons(adj7);
			buttons[7].setAdjacentButtons(adj8);
			buttons[8].setAdjacentButtons(adj9);
		}
	}
	
	void Update () {
		
	}
}
