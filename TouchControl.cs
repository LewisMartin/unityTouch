using UnityEngine;
using System.Collections;

// this class allows for on screen touches of multiple objects to be handled
public class TouchControl : MonoBehaviour {
	
	// variable to store instance of a script
	Main_Game_System game_System;

	// temporary game object to store gameobjects that are hit
	GameObject hitObject;

	// start function
	void Start(){
		// allocate instance of script that contains score GUI functions
		game_System = GameObject.Find("GameSystem").GetComponent<Main_Game_System>();
	}
	
	// if game is run on mobile platform
	#if UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8
	// update function (called once every frame)
	void Update () {
		// if user has initiated play
		if(game_System.Playable_Check() == true){

			// are there any onscreen touches?
			if(Input.touches.Length <=0){
				// if no touches do nothing

			} else { // otherwise if there is at least one touch
				// loop through all current touches
				for(int i = 0; i<Input.touchCount; i++){
					
					// if the touch is at the beginning phase (finger has come into contact with screen)
					if (Input.GetTouch(i).phase == TouchPhase.Began) {

						// get hit info of the world point that the touched screen point translates to
						RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position), Vector2.zero);
						// if an object was hit (hitinfo is null if none were)
						if(hitInfo)
						{
							// assign the hit object to temporary game object
							hitObject = hitInfo.transform.gameObject;

							// perform different functionality based on the hit objects class
							switch(hitObject.GetType()){
								case "enemy":
									//do something with the object
									
									break;
								case "monster":
									//do something with the object
									
									break;
								// etc..
							}

						}
					}
					
					// if the touch is at the end phase (finger has left the screen)
					if (Input.GetTouch(i).phase == TouchPhase.Ended) {
						//do something
					}
					
					// if the touch moved on the screen (finger swipe)
					if (Input.GetTouch(i).phase == TouchPhase.Moved) {
						// do something
					}
					
					// if screen is touched and touch isn't moving
					if (Input.GetTouch(i).phase == TouchPhase.Stationary) {
						// do something
					}
				}
			}
		}
	}
	#endif
}
