﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*	This script works in conjunction with the TrapSelect script to allow the player to select a spot in the radial menu and
 * 	place a trap in this spot. Each square will be assigned a section from the PlayerState GameObject array. (so this script goes on
 *  each square).
 */


public class EquipTrapRadial : MonoBehaviour {

	public int representWhichSpot;		// Which index spot does this square represent for the player's equipped traps in PlayerState?
	public bool isSelected;				// This will be true when the player selects this spot
	public bool isDisabled;				// This makes sure that only one of these spots are selected.

	public GameObject currTrap;			// What trap is currently on this spot?
	public GameObject[] otherRadials;	// Keeps track of the other radial spots.

	private GameObject playerState;	// Keeps a refrence to the playerState so that it can refer back to it when needed.

	// This will set the trap here to whatever is selected in the GameObject array.
	void Start()
	{
		playerState = GameObject.FindGameObjectWithTag("Player");

		if(playerState.GetComponent<PlayerState>().currEquippedTraps[representWhichSpot] != null)
			currTrap = playerState.GetComponent<PlayerState>().currEquippedTraps[representWhichSpot];
	}

	// This method is called in the event system in order to let the object know it's been selected.
	// All other spots are disabled, preventing them from being selected.
	// Selecting the same spot will deselect it. (or removing the trap that was in there?)
	public void SelectSpot()
	{
		if(isDisabled == false)
		{
			if(isSelected == true)
			{
				DeselectSpot();
			}
			else
			{
				isSelected = true;
				for(int i = 0; i < otherRadials.Length; i++)
					otherRadials[i].GetComponent<EquipTrapRadial>().isDisabled = true;
			}
		}
	}

	// This method is called in the event system or wherever in order to let the object know it's been deselected.
	// All other spots are then reenabled, allowing them to being selected.
	public void DeselectSpot()
	{
		if(isDisabled == false)
		{
			isSelected = false;

			for(int i = 0; i < otherRadials.Length; i++)
				otherRadials[i].GetComponent<EquipTrapRadial>().isDisabled = false;
		}
	}

	// This sets the given trap from the parameter into this spot.
	public void SetTrap(GameObject trap)
	{
		currTrap = trap;
		trap.GetComponent<Trap>().slot = representWhichSpot;
		DeselectSpot();
		print("It worked!");
	}

}