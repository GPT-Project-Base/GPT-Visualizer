using Godot;
using System;
using System.Collections.Generic;

public partial class LocationManager : Node2D
{
	
	[Export] public Godot.Collections.Array<Location> Locations;
	
	
	[Export] public GridContainer gridContainer;
	[Export] public PackedScene locationObject;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
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
		}
		
		//PrintAllLocs();
		
	}

	private void PrintAllLocs(){
		foreach (Location loc in Locations){
			GD.Print(loc.LocationID);
		}
	}

}
