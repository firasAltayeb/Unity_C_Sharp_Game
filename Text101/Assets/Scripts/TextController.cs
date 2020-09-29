using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	public Button leftBtn;
	public Button rightBtn;
	public Button belowBtn;
	public BackGround backGround;
 	public Text leftBtnTxt;	
	public Text rightBtnTxt;
	public Text belowBtnTxt;
	public MusicPlayer MusicPlayer;
	
	
	private enum States {
								cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, corridor_0, corridor_1,
								corridor_2, corridor_3, stairs_0, stairs_1, stairs_2,  floor, courtyard, cloest_door, in_closet
								};
	private States myState;
	
	// Use this for initialization
	void Start () {
		myState = States.cell;
		backGround = GameObject.FindObjectOfType<BackGround>();
		MusicPlayer = GameObject.FindObjectOfType<MusicPlayer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(myState == States.cell)						{cell();}
		else if(myState == States.sheets_0)			{sheets_0();}
		else if(myState == States.sheets_1)   		{sheets_1();}
		else if(myState == States.lock_0)      		{lock_0();}
		else if(myState == States.lock_1)			{lock_1();}
		else if(myState == States.mirror)        	{mirror();}
		else if(myState == States.cell_mirror) 		{cell_mirror();}
		else if(myState == States.corridor_0) 		{corridor_0();}
		else if(myState == States.corridor_1) 		{corridor_1();}
		else if(myState == States.corridor_2) 		{corridor_2();}
		else if(myState == States.corridor_3) 		{corridor_3();}
		else if(myState == States.stairs_0)			{stairs_0();}
		else if(myState == States.stairs_1)			{stairs_1();}
		else if(myState == States.stairs_2)			{stairs_2();}
		else if(myState == States.cloest_door)		{cloest_door();}
		else if(myState == States.in_closet)			{in_closet();}
		else if(myState == States.courtyard)		{courtyard();}
		else if(myState == States.floor)				{floor();}
	}
	
	#region State handler methods
	void cell (){
		backGround.loadBackGround(1);
			text.text = "You are in a prison cell, and you want to escape. There are " +
							"some dirty sheets on the bed, a mirror on the wall, and the door " +
							"is locked from the outside";
		leftBtnTxt.text = "press to check the Sheets";
		rightBtnTxt.text = "press to view Mirror";
		belowBtnTxt.text = "press to view Lock";
		leftBtn.onClick.AddListener		(() => {myState = States.sheets_0;
			UnhideElements(leftBtn,leftBtnTxt,rightBtn,rightBtnTxt,belowBtn,belowBtnTxt);});
		rightBtn.onClick.AddListener 	(() => {myState = States.mirror;
			UnhideElements(leftBtn,leftBtnTxt,rightBtn,rightBtnTxt,belowBtn,belowBtnTxt);});
		belowBtn.onClick.AddListener(() =>  {myState = States.lock_0;
			UnhideElements(leftBtn,leftBtnTxt,rightBtn,rightBtnTxt,belowBtn,belowBtnTxt);});
	}
	
	void mirror (){
		text.text = "The dirty old mirror on the wall seems loose";
		leftBtnTxt.text = "press to Take the mirror";
		rightBtnTxt.text = "press to Return to the cell";
		leftBtn.onClick.AddListener		(() => {myState = States.cell_mirror;
			UnhideElements(leftBtn,leftBtnTxt,rightBtn,rightBtnTxt,belowBtn,belowBtnTxt);});
		rightBtn.onClick.AddListener 	(() => {myState = States.cell;
			UnhideElements(leftBtn,leftBtnTxt,rightBtn,rightBtnTxt,belowBtn,belowBtnTxt);});
		HideOneElements(belowBtn,belowBtnTxt);
	}
	
	void sheets_0 (){
		text.text = "You cant believe you sleep here, it is "+
						"time for somebody to change them.";
		belowBtnTxt.text = "press to Return to roaming your cell";
		belowBtn.onClick.AddListener(() =>  {myState = States.cell;
			UnhideElements(leftBtn,leftBtnTxt,rightBtn,rightBtnTxt,belowBtn,belowBtnTxt);});
		HideTwoElements(leftBtn,leftBtnTxt,rightBtn,rightBtnTxt);
	}
	
	void sheets_1 (){
		text.text = "Holding a mirror in your hand doesnt make the sheets look any better";
		belowBtnTxt.text = "press to Return to roaming your cell";
		belowBtn.onClick.AddListener(() =>  {myState = States.cell_mirror;
			UnhideElements(leftBtn,leftBtnTxt,rightBtn,rightBtnTxt,belowBtn,belowBtnTxt);});
		HideTwoElements(leftBtn,leftBtnTxt,rightBtn,rightBtnTxt);
	}
	
	void lock_0 (){
		text.text = "This is one of those password locks. You have no idea what the "+
						"combination is. You wish you could somehow see where the dirty "+
						"fingerprints were, maybe that would help";
		belowBtnTxt.text = "press to Return to roaming your cell";
		belowBtn.onClick.AddListener(() =>  {myState = States.cell;
			UnhideElements(leftBtn,leftBtnTxt,rightBtn,rightBtnTxt,belowBtn,belowBtnTxt);});
		HideTwoElements(leftBtn,leftBtnTxt,rightBtn,rightBtnTxt);
	}
	
	void lock_1 (){
		text.text = "You carefully put the mirror through the bars, and turn it round "+
						"so you can see the look. You can barely see fingerprints around "+
						"the buttons. You press the dirty buttons, and hear a click.\n\n" +
						"press O to open, or R to Return to your cell";
		leftBtnTxt.text = "press to open";
		rightBtnTxt.text = "press to Return to the cell";
		leftBtn.onClick.AddListener		(() => {myState = States.corridor_0;
			UnhideElements(leftBtn,leftBtnTxt,rightBtn,rightBtnTxt,belowBtn,belowBtnTxt);});
		rightBtn.onClick.AddListener 	(() => {myState = States.cell_mirror;
			UnhideElements(leftBtn,leftBtnTxt,rightBtn,rightBtnTxt,belowBtn,belowBtnTxt);});
		HideOneElements(belowBtn,belowBtnTxt);
	}	
	
	void cell_mirror (){
		text.text = "You are still in your cell, and you still want to escape. There are " +
						"some dirty sheets on the bed, a mark where the mirror was, and the door " +
						"is still locked from the outside";
		leftBtnTxt.text = "press to check the Sheets";
		rightBtnTxt.text = "press to Return to view Lock";
		leftBtn.onClick.AddListener		(() => {myState = States.sheets_1;
			UnhideElements(leftBtn,leftBtnTxt,rightBtn,rightBtnTxt,belowBtn,belowBtnTxt);});
		rightBtn.onClick.AddListener 	(() => {myState = States.lock_1;
			UnhideElements(leftBtn,leftBtnTxt,rightBtn,rightBtnTxt,belowBtn,belowBtnTxt);});
		HideOneElements(belowBtn,belowBtnTxt);
	}
	
	void corridor_0(){
		backGround.loadBackGround(2);
		text.text = "You are out of your cell, but not out of trouble. "+
						"You are in the corridor, there is a closet and some stairs leading to "+
						"the courtyard. There's also various detritus on the floor";
		leftBtnTxt.text = "press to view the Closet";
		rightBtnTxt.text = "press to inspect the Floor";
		belowBtnTxt.text = "press to climb the stairs";
		leftBtn.onClick.AddListener		(() => {myState = States.cloest_door;
			UnhideElements(leftBtn,leftBtnTxt,rightBtn,rightBtnTxt,belowBtn,belowBtnTxt);});
		rightBtn.onClick.AddListener 	(() => {myState = States.floor;
			UnhideElements(leftBtn,leftBtnTxt,rightBtn,rightBtnTxt,belowBtn,belowBtnTxt);});
		belowBtn.onClick.AddListener(() =>  {myState = States.stairs_0;
			UnhideElements(leftBtn,leftBtnTxt,rightBtn,rightBtnTxt,belowBtn,belowBtnTxt);});
	}
	
	void corridor_1(){
		backGround.loadBackGround(2);
		text.text = "Still in the corridor. Floor still dirty. hairclip in hand. "+
						"Now what? You wonder if the that lock on the closet would succmb to " +
						"to some lock_picking?";
		leftBtnTxt.text = "press to Pick the lock";
		rightBtnTxt.text = "press to climb the Stairs";
		leftBtn.onClick.AddListener		(() => {myState = States.in_closet;
			UnhideElements(leftBtn,leftBtnTxt,rightBtn,rightBtnTxt,belowBtn,belowBtnTxt);});
		rightBtn.onClick.AddListener 	(() => {myState = States.stairs_1;
			UnhideElements(leftBtn,leftBtnTxt,rightBtn,rightBtnTxt,belowBtn,belowBtnTxt);});
		HideOneElements(belowBtn,belowBtnTxt);
	}
	
	void corridor_2(){
		backGround.loadBackGround(2);
		text.text = "Back in the corridor, having declined to dress-up as a cleaner";
		leftBtnTxt.text = "press to revist the Closet";
		rightBtnTxt.text = "press to climb the Stairs";
		leftBtn.onClick.AddListener		(() => {myState = States.in_closet;
			UnhideElements(leftBtn,leftBtnTxt,rightBtn,rightBtnTxt,belowBtn,belowBtnTxt);});
		rightBtn.onClick.AddListener 	(() => {myState = States.stairs_2;
			UnhideElements(leftBtn,leftBtnTxt,rightBtn,rightBtnTxt,belowBtn,belowBtnTxt);});
		HideOneElements(belowBtn,belowBtnTxt);
		
	}
	
	void corridor_3(){
		backGround.loadBackGround(2);
		text.text = 	"You're standing back in the corridor, now convincingly dressed as a cleaner. "+
						"You strongly consider the run for freedom";
		leftBtnTxt.text = "press to Undress";
		rightBtnTxt.text = "press to climb the Stairs";
		leftBtn.onClick.AddListener		(() => {myState = States.in_closet;
			UnhideElements(leftBtn,leftBtnTxt,rightBtn,rightBtnTxt,belowBtn,belowBtnTxt);});
		rightBtn.onClick.AddListener 	(() => {myState = States.courtyard; MusicPlayer.audio.Stop();audio.Play();
			UnhideElements(leftBtn,leftBtnTxt,rightBtn,rightBtnTxt,belowBtn,belowBtnTxt);});
		HideOneElements(belowBtn,belowBtnTxt);
		
	}
	
	void	floor(){
		text.text = "Rummaging around on the dirty floor, you find a hairclip";
		leftBtnTxt.text = "press to Return to the standing";
		rightBtnTxt.text = "press to take the Hairclip";
		leftBtn.onClick.AddListener		(() => {myState = States.corridor_0;
			UnhideElements(leftBtn,leftBtnTxt,rightBtn,rightBtnTxt,belowBtn,belowBtnTxt);});
		rightBtn.onClick.AddListener 	(() => {myState = States.corridor_1;
			UnhideElements(leftBtn,leftBtnTxt,rightBtn,rightBtnTxt,belowBtn,belowBtnTxt);});
		HideOneElements(belowBtn,belowBtnTxt);
		
	}
	
	
	void stairs_0 () {
		backGround.loadBackGround(4);
		text.text = "You start walking up the stairs towards the outside light. "+
						"You realise its's not break time, and you'll be caught immediately " +
						"You slither back down the stairs and reconsider";
		belowBtnTxt.text = "press to Return to the corridor";
		belowBtn.onClick.AddListener(() =>  {myState = States.corridor_0;
			UnhideElements(leftBtn,leftBtnTxt,rightBtn,rightBtnTxt,belowBtn,belowBtnTxt);});
		HideTwoElements(leftBtn,leftBtnTxt,rightBtn,rightBtnTxt);
	}
	
	void stairs_1 () {
		backGround.loadBackGround(4);
		text.text = "Unfortunately weilding a puny hairclip hasn't given you the. "+
						"confidence to walk out into a courtyard surrounded by armed guards!";
		belowBtnTxt.text = "press to Return to the corridor";
		belowBtn.onClick.AddListener(() =>  {myState = States.corridor_1;
			UnhideElements(leftBtn,leftBtnTxt,rightBtn,rightBtnTxt,belowBtn,belowBtnTxt);});
		HideTwoElements(leftBtn,leftBtnTxt,rightBtn,rightBtnTxt);
		
	}
	
	void stairs_2 () {
		backGround.loadBackGround(4);
		text.text = "You feel smug for picking the cloest door open, and are still armed with "+
						"a hairclip (now badly badly bent.) Even these achievements together dont give " +
						" you the courage to climb up the stairs to your death!";
		belowBtnTxt.text = "press to Return to the corridor";
		belowBtn.onClick.AddListener(() =>  {myState = States.corridor_2;
			UnhideElements(leftBtn,leftBtnTxt,rightBtn,rightBtnTxt,belowBtn,belowBtnTxt);});
		HideTwoElements(leftBtn,leftBtnTxt,rightBtn,rightBtnTxt);
	}
	
	void cloest_door () {
		backGround.loadBackGround(3);
		text.text = "You are looking at a cloest door, unfortunately it's looked. "+
						"Maybe you could find something around to help encourage it open?";
		belowBtnTxt.text = "press to Return to the corridor";
		belowBtn.onClick.AddListener(() =>  {myState = States.corridor_0;
			UnhideElements(leftBtn,leftBtnTxt,rightBtn,rightBtnTxt,belowBtn,belowBtnTxt);});
		HideTwoElements(leftBtn,leftBtnTxt,rightBtn,rightBtnTxt);
	}
	
	void in_closet () {
		backGround.loadBackGround(3);
		text.text = "Inside the closet you see a cleaner's uniform that looks about your size!. "+
						"Seems like your day is looking-up";
		leftBtnTxt.text = "press to Dress up";
		rightBtnTxt.text = "press to the corridor";
		leftBtn.onClick.AddListener		(() => {myState = States.corridor_3;
			UnhideElements(leftBtn,leftBtnTxt,rightBtn,rightBtnTxt,belowBtn,belowBtnTxt);});
		rightBtn.onClick.AddListener 	(() => {myState = States.corridor_2;
			UnhideElements(leftBtn,leftBtnTxt,rightBtn,rightBtnTxt,belowBtn,belowBtnTxt);});
		HideOneElements(belowBtn,belowBtnTxt);
	}
	
	void courtyard(){
		backGround.loadBackGround(4);
		text.text = "You walk through the courtyard dressed as a cleaner. "+
						"The guard tips his hat at you as you walk past, claiming " +
						" your freedom. Your heart races as you walk into the sunset";
		belowBtnTxt.text = "press P to Play again";
		belowBtn.onClick.AddListener(() =>  {myState = States.cell;audio.Stop(); MusicPlayer.audio.Play();
			belowBtn.onClick.RemoveAllListeners();
			rightBtn.onClick.RemoveAllListeners();
			UnhideElements(leftBtn,leftBtnTxt,rightBtn,rightBtnTxt,belowBtn,belowBtnTxt);});
		HideTwoElements(leftBtn,leftBtnTxt,rightBtn,rightBtnTxt);
	}
	
	void UnhideElements(Button btn,Text txt,Button btn2,Text txt2,Button btn3,Text txt3) {
		btn.interactable = true;
		txt.GetComponentInChildren<CanvasRenderer>().SetAlpha(1);
		btn2.interactable = true;
		txt2.GetComponentInChildren<CanvasRenderer>().SetAlpha(1);
		btn3.interactable = true;
		txt3.GetComponentInChildren<CanvasRenderer>().SetAlpha(1);
	}
	
	void HideOneElements(Button btn,Text txt) {
		btn.interactable = false;
		txt.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
	}
	
	void HideTwoElements(Button btn,Text txt,Button btn2,Text txt2) {
		btn.interactable = false;
		txt.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
		btn2.interactable = false;
		txt2.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
	}
	
	#endregion
	
}


