﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class monopodialInfloresence : Parametric_L_System {

	void Awake()
	{
		Leaf = Resources.Load ("Prefabs/L_Systems/Leaves/simpleLeaf3") as GameObject;
		leafGrowth = 0.05f;
		
		Flower = Resources.Load ("Prefabs/L_Systems/Flowers/infloresence2") as GameObject;
		flowerGrowth = 0.025f;
	}
	// Use this for initialization
	void Start () 
	{
		returnList = new List<Module> ();
		productions = new Dictionary<char, Module[]> ();

		axlGrowth = 5.2f;

		widthGrowth = 0.25f;

		segmentGrowth = 0.55f;
		
		divergenceAngle = 120.0f;

		maturity = 6.0f;
		
		numOfProductions = 3;
		productionLengths = new int[numOfProductions];
		
		productionLengths [0] = 10;
		productionLengths [1] = 8;
		productionLengths [2] = 8;
		
		returnList.Add (new Module ('!', 0, 1, widthGrowth));
		returnList.Add (new Module ('F', 0, 1, 0.25f));
		returnList.Add (new Module ('a', 0, 0.5f, 0));
		
		productions.Add ('a', new Module [productionLengths[0]]);	//Central Stalk
		productions['a'][0] = (new Module ('!', 0, 1, widthGrowth));
		productions['a'][1] = (new Module ('F', 0, 1, 0.1f));
		productions['a'][2] = (new Module ('+', 0, 1, divergenceAngle));
		productions['a'][3] = (new Module ('[', 0, -1, 0));
		productions['a'][4] = (new Module ('N', 0, 1, 0));
		productions['a'][5] = (new Module ('&', 0, 1, axlGrowth*0.75f));
		productions['a'][6] = (new Module ('L', 0, 1, leafGrowth));
		productions['a'][7] = (new Module ('b', 0, 0.5f, 0));
		productions['a'][8] = (new Module (']', 0, 1, 0));
		productions['a'][9] = (new Module ('a', 0, 0.5f, 0));

		productions.Add ('b', new Module[productionLengths[1]]);	
		productions['b'][0] = (new Module ('!', 0, 1, widthGrowth));
		productions['b'][1] = (new Module ('F', 0, 1, segmentGrowth));
		productions['b'][2] = (new Module ('+', 0, 1, divergenceAngle));
		productions['b'][3] = (new Module ('[', 0, -1, 0));
		productions['b'][4] = (new Module ('&', 0, 1, axlGrowth));
		productions['b'][5] = (new Module ('c', 0, 0.5f, 0));
		productions['b'][6] = (new Module (']', 0, 1, 0));
		productions['b'][7] = (new Module ('b', 0, 1.0f, 0));

		productions.Add ('c', new Module[productionLengths[2]]);	//Infloresence
		productions['c'][0] = (new Module ('!', 0, 1, widthGrowth));
		productions['c'][1] = (new Module ('F', 0, 1, 0.75f*segmentGrowth));
		productions['c'][2] = (new Module ('+', 0, 1, divergenceAngle));
		productions['c'][3] = (new Module ('[', 0, -1, 0));
		productions['c'][4] = (new Module ('&', 0, 1, axlGrowth*2));
		productions['c'][5] = (new Module ('I', 0, 1, flowerGrowth));
		productions['c'][6] = (new Module (']', 0, 1, 0));
		productions['c'][7] = (new Module ('c', 0, 0.5f, 0));
	}
	
	// Update is called once per frame
	void Update () 
	{
		base.Update ();
	}
	
	public override float growthFunction(char sym, float gp, float time)
	{
		switch(sym)
		{
			case '+':
				return gp;
			default:
				return gp*Mathf.Exp(exponentialParameter*time);

		}
	}
}
