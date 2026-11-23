using Godot;
using System;
//using System.Collections.Generic;

[GlobalClass]
public partial class Location : Control
{
	
	//data
	[Export] public string LocationName { get; set; } = "Location Name";
	[Export] public int LocationID { get; set; } = 0;
	//[Export]
	//public List<Individual> PeopleHere = new List<Individual>();
	[Export] public Godot.Collections.Array<Individual> PeopleHere;
	[Export] public int Frame;
	
	//assets
	[Export] private Label nameLabel;
	[Export] private GridContainer gridContainer;
	[Export] private LineEdit nameInpt;
	[Export] private ColorRect selectedIndicatorF;
	[Export] private ColorRect selectedIndicatorT;
	
	[Export] public PackedScene individualObject;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		nameLabel.Text = "Location" + LocationID;

	}

	public void AddIndividual()
	{//add blank individual
		Individual individual = new Individual();
		
		//GD.Print("Added Individual to Location " + LocationID + ". Total Individuals: " + PeopleHere.Count);
		if(individualObject != null)
		{
			Individual individualInstance = individualObject.Instantiate<Individual>();
			individualInstance.id = individual.id;
			individualInstance.name = individual.name;
			individualInstance.locationId = LocationID;
			gridContainer.AddChild(individualInstance);
			PeopleHere.Add(individualInstance);
		}
		
	}
	public void AddIndividual(int id, string name)
	{//add individual with id and name
		Individual individual = new Individual(id, name);
		PeopleHere.Add(individual);
		//GD.Print("Added Individual to Location " + LocationID + ". Total Individuals: " + PeopleHere.Count);
		if (individualObject != null)
		{
			Individual individualInstance = individualObject.Instantiate<Individual>();
			individualInstance.id = individual.id;
			individualInstance.name = individual.name;
			individualInstance.locationId = LocationID;
			gridContainer.AddChild(individualInstance);
		}
	}
	public void AddIndividual(string name)
	{//add individual with name and set id to position in list
		Individual individual = new Individual(PeopleHere.Count+1, name);
		PeopleHere.Add(individual);
		//GD.Print("Added Individual to Location " + LocationID + ". Total Individuals: " + PeopleHere.Count);
		if (individualObject != null)
		{
			Individual individualInstance = individualObject.Instantiate<Individual>();
			individualInstance.id = individual.id;
			individualInstance.name = individual.name;
			individualInstance.locationId = LocationID;
			gridContainer.AddChild(individualInstance);
		}
	}

	public override void _Input(InputEvent @event)
	{
		//when the testButton is pressed and the nameInpt is not empty, print the nameInpt text
		if (@event.IsActionPressed("testButton") )
		{
			GD.Print(nameInpt.Text);
		}
		if(@event.IsActionPressed("Enter")){
			_on_button_pressed();
		}
	}

	private void _on_button_pressed()
	{
		if(!string.IsNullOrEmpty(nameInpt.Text))
		{//only add individual if nameInpt has text then clear the text
			AddIndividual(nameInpt.Text);
			nameInpt.Text = "";
		}
		
	}

	public void isSelected(bool selected){
		selectedIndicatorF.Visible = !selected;
		selectedIndicatorT.Visible = selected;
	}
	
	
}
