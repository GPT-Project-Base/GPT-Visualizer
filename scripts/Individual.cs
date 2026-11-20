using Godot;
using System;

[GlobalClass]
public partial class Individual : Control
{
	[Export] public int Frame;
	[Export] public int id;
	[Export] public String name;
	[Export] public Label nameLabel;
	[Export] public int locationId;
	
	[Export] public float interactChance;
	[Export] public float influenceChance;
	[Export] public Godot.Collections.Array<float> opinions;//range -1,1
	[Export] public Godot.Collections.Array<float> opinionStrength;//range 0,1

	//constructor
	public Individual()
	{
		id = -1;
		name = "______";
	}
	public Individual(int id, String name)
	{
		this.id = id;
		this.name = name;
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		nameLabel.Text = id + " "+ name;
	}

}
