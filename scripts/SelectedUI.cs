using Godot;
using System;

public partial class SelectedUI : Node
{

	[Export] public VBoxContainer LocationUI;
	[Export] public VBoxContainer PersonUI;

	[Export]public LocationManager locationManager;
	[Export]public PeopleManager peopleManager;


	public override void _Ready()
	{
		//locationManager = GetNode<LocationManager>("/root/LocationManager");
		GD.Print(locationManager.selectedLocationID);
	}

	//switch between location and person UI

	private void _on_people_manager_selected_person_changed(int selected)
	{
		//set loccation ui if no individual is selected, person ui otherwise
		if (selected == -1)
		{
			LocationUI.Visible = true;
			PersonUI.Visible = false;
		}
		else
		{
			LocationUI.Visible = false;
			PersonUI.Visible = true;
		}
	}
	
	//probablly need to make a different ui for initializing vs simulating
	//one ui with sliders and shit
	//another ui with just bars or numbers or text

}
