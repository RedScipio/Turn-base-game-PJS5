using Godot;
using System;
using System.Collections.Generic;

namespace Scene.Battle;

public partial class Battle : Control
{
	private List<IPilot> _lPilotes;
	
	//Native from Godot
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
		this._lPilotes = lPilotes;
	}

	//Native from Godot
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public bool BattleIsOver()
	{
		return false;
	}

	/*private bool PlayTurn(PilotTurn* pPilotTurn)
	{
		return false;
	}*/

	private bool EnemyTurn()
	{
		return false;
	}
}
