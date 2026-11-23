using Godot;
using System;
using System.Collections.Generic;

public partial class LocationManager : Node2D
{
	
	[Export] public Godot.Collections.Array<Location> Locations;
	
	
	[Export] public GridContainer gridContainer;
	[Export] public PackedScene locationObject;
	[Export] public Label selectedLocationLabel;	
	public Location selectedLocation;
	[Export] private int selectedLocationID = -1;

	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("deselect"))
		{
			selectedLocationID = -1;
			updateUI(selectedLocationID);
		}
	}

	private void updateUI(int locationID)
	{
		if(locationID == -1)//check if no location is selected
		{
			selectedLocationLabel.Text = "None";
		}
		else
		{
			selectedLocationLabel.Text = "Location " + locationID;
			selectedLocation = Locations[locationID];
		}
		loopThroughLocationsAndChangecolor();
	}

	private void _on_add_location_pressed()
	{
		//GD.Print("added locations");
		AddLocation();
	}

	private void AddLocation()
	{
		Location location = new Location();
		
		if (locationObject != null)
		{
			Location locationInstance = locationObject.Instantiate<Location>();
			locationInstance.LocationID = Locations.Count;
			Locations.Add(locationInstance);
			gridContainer.AddChild(locationInstance);
			selectedLocationID = locationInstance.LocationID;
			updateUI(selectedLocationID);
		}
		//PrintAllLocs();
	}//end of AddLocation

	private void PrintAllLocs(){
		foreach (Location loc in Locations){
			GD.Print(loc.LocationID);
		}
	}//end PrintAllLocs

	private void _on_left_button_pressed()
	{
		//select the previous location in the list
		if (selectedLocationID > 0)
		{
			selectedLocationID--;
			updateUI(selectedLocationID);
		}
	}

	private void _on_right_button_pressed()
	{
		//select the next location in the list
		if (selectedLocationID < Locations.Count - 1)
		{
			selectedLocationID++;
			updateUI(selectedLocationID);
		}
	}

	private void loopThroughLocationsAndChangecolor()
	{
		foreach (Location loc in Locations)//loop through all locations and change the color of the selected location
		{
			loc.isSelected(loc.LocationID == selectedLocationID);
		}
	}
}
