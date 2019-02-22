using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPuzzle : MonoBehaviour {

	public PowerButton[] buttons;
	public bool hardMode = false;
	private bool completed;

	void Start () {
		completed = false;
		if(buttons.Length == 9){ //Easy
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

		} else if(buttons.Length == 16){ //Medium
			PowerButton[] adj1 = new PowerButton[2];
			PowerButton[] adj2 = new PowerButton[3];
			PowerButton[] adj3 = new PowerButton[3];
			PowerButton[] adj4 = new PowerButton[2];
			PowerButton[] adj5 = new PowerButton[3];
			PowerButton[] adj6 = new PowerButton[4];
			PowerButton[] adj7 = new PowerButton[4];
			PowerButton[] adj8 = new PowerButton[3];
			PowerButton[] adj9 = new PowerButton[3];
			PowerButton[] adj10 = new PowerButton[4];
			PowerButton[] adj11 = new PowerButton[4];
			PowerButton[] adj12 = new PowerButton[3];
			PowerButton[] adj13 = new PowerButton[2];
			PowerButton[] adj14 = new PowerButton[3];
			PowerButton[] adj15 = new PowerButton[3];
			PowerButton[] adj16 = new PowerButton[2];

			adj1[0] = buttons[1];
			adj1[1] = buttons[4];

			adj2[0] = buttons[0];
			adj2[1] = buttons[2];
			adj2[2] = buttons[5];

			adj3[0] = buttons[1];
			adj3[1] = buttons[3];
			adj3[2] = buttons[6];

			adj4[0] = buttons[2];
			adj4[1] = buttons[7];

			adj5[0] = buttons[0];
			adj5[1] = buttons[5];
			adj5[2] = buttons[8];

			adj6[0] = buttons[1];
			adj6[1] = buttons[4];
			adj6[2] = buttons[6];
			adj6[3] = buttons[9];

			adj7[0] = buttons[2];
			adj7[1] = buttons[5];
			adj7[2] = buttons[7];
			adj7[3] = buttons[10];

			adj8[0] = buttons[3];
			adj8[1] = buttons[6];
			adj8[2] = buttons[11];

			adj9[0] = buttons[4];
			adj9[1] = buttons[9];
			adj9[2] = buttons[12];

			adj10[0] = buttons[5];
			adj10[1] = buttons[8];
			adj10[2] = buttons[10];
			adj10[3] = buttons[13];

			adj11[0] = buttons[6];
			adj11[1] = buttons[9];
			adj11[2] = buttons[11];
			adj11[3] = buttons[14];

			adj12[0] = buttons[7];
			adj12[1] = buttons[10];
			adj12[2] = buttons[15];

			adj13[0] = buttons[8];
			adj13[1] = buttons[13];

			adj14[0] = buttons[9];
			adj14[1] = buttons[12];
			adj14[2] = buttons[14];

			adj15[0] = buttons[10];
			adj15[1] = buttons[13];
			adj15[2] = buttons[15];

			adj16[0] = buttons[11];
			adj16[1] = buttons[14];

			buttons[0].setAdjacentButtons(adj1);
			buttons[1].setAdjacentButtons(adj2);
			buttons[2].setAdjacentButtons(adj3);
			buttons[3].setAdjacentButtons(adj4);
			buttons[4].setAdjacentButtons(adj5);
			buttons[5].setAdjacentButtons(adj6);
			buttons[6].setAdjacentButtons(adj7);
			buttons[7].setAdjacentButtons(adj8);
			buttons[8].setAdjacentButtons(adj9);
			buttons[9].setAdjacentButtons(adj10);
			buttons[10].setAdjacentButtons(adj11);
			buttons[11].setAdjacentButtons(adj12);
			buttons[12].setAdjacentButtons(adj13);
			buttons[13].setAdjacentButtons(adj14);
			buttons[14].setAdjacentButtons(adj15);
			buttons[15].setAdjacentButtons(adj16);

		} else if(buttons.Length == 18){ // hard
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

			PowerButton[] adj10 = new PowerButton[2];
			PowerButton[] adj11 = new PowerButton[3];
			PowerButton[] adj12 = new PowerButton[2];
			PowerButton[] adj13 = new PowerButton[3];
			PowerButton[] adj14 = new PowerButton[4];
			PowerButton[] adj15 = new PowerButton[3];
			PowerButton[] adj16 = new PowerButton[2];
			PowerButton[] adj17 = new PowerButton[3];
			PowerButton[] adj18 = new PowerButton[2];

			adj10[0] = buttons[10];
			adj10[1] = buttons[12];

			adj11[0] = buttons[9];
			adj11[1] = buttons[11];
			adj11[2] = buttons[13];
			
			adj12[0] = buttons[10];
			adj12[1] = buttons[14];
			
			adj13[0] = buttons[9];
			adj13[1] = buttons[13];
			adj13[2] = buttons[15];
			
			adj14[0] = buttons[9];
			adj14[1] = buttons[12];
			adj14[2] = buttons[14];
			adj14[3] = buttons[16];
			
			adj15[0] = buttons[11];
			adj15[1] = buttons[13];
			adj15[2] = buttons[17];
			
			adj16[0] = buttons[12];
			adj16[1] = buttons[16];
			
			adj17[0] = buttons[13];
			adj17[1] = buttons[15];
			adj17[2] = buttons[17];
			
			adj18[0] = buttons[14];
			adj18[1] = buttons[16];

			buttons[9].setAdjacentButtons(adj10);
			buttons[10].setAdjacentButtons(adj11);
			buttons[11].setAdjacentButtons(adj12);
			buttons[12].setAdjacentButtons(adj13);
			buttons[13].setAdjacentButtons(adj14);
			buttons[14].setAdjacentButtons(adj15);
			buttons[15].setAdjacentButtons(adj16);
			buttons[16].setAdjacentButtons(adj17);
			buttons[17].setAdjacentButtons(adj18);

			for(int i = 0; i < 18; i++){
				if(i < 9){
					buttons[i].setCorrespondingButton(buttons[i+9]);
				} else {
					buttons[i].setCorrespondingButton(buttons[i-9]);
				}
				
			}

		}
	}
	
	void Update () {
		if(!completed){
			bool flag = true;
			for(int i = 0; i < buttons.Length; i++){
				if(!buttons[i].isOn()){
					flag = false;
				}
			}
			completed = flag;
		}
		if(Input.GetKeyDown(KeyCode.M)){
			completed = true;
		}
		
	}

	public bool isCompleted(){
		return completed;
	}
}
