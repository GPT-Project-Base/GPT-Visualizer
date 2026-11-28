using Godot;
using System;

public partial class PeopleManager : Node2D
{
	//data
	[Export] public Godot.Collections.Array<Individual> peopleHere;

	//signals
	//signal to update the selected person in the UI
	[Signal] public delegate void SelectedPersonChangedEventHandler(int selectedPersonID);

	//assets
	[Export] public LocationManager locationManager;
	[Export] public Label selectedPersonLabel;
	[Export] public int selectedPersonID = -1;

	private void _on_selected_location_changed()
	{
		//GD.Print("LocationChanged");
		//when leftButton is pressed, empty the peopleHere array and fill it with the people from the selected location
		peopleHere.Clear();
		if (locationManager.selectedLocationID != -1)
		{
			foreach (Individual individual in locationManager.selectedLocation.PeopleHere)
			{
				peopleHere.Add(individual);
			}
		}
	}
	
	private void _on_left_person_button_pressed(){
		//select the person to the left of the selected person, can go to -1 to select average
		selectedPersonID--;
		if (selectedPersonID < -1)
		{
			selectedPersonID = peopleHere.Count-1;
		}
		UpdateUI();
	}

	private void _on_right_person_button_pressed(){
		//select the person to the right of the selected person, can go past the last person to select average

		selectedPersonID++;
		if (selectedPersonID >= peopleHere.Count)
		{
			selectedPersonID = -1;
		}
		UpdateUI();
	}

	private void UpdateUI()
	{
		//GD.Print(selectedPersonID);
		if(selectedPersonID == -1)
		{
			selectedPersonLabel.Text = "Average";
		}
		else
		{
			//display selected person id and name
			selectedPersonLabel.Text = "Person " + peopleHere[selectedPersonID].id + ": " + peopleHere[selectedPersonID].name;
		}
		EmitSignal("SelectedPersonChanged", selectedPersonID);
	}

}
