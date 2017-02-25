﻿using UnityEngine;
using System.Collections;

public class Factory : MonoBehaviour {

	private float baseVal = 100.0f; //Will need balancing

	private float expEpsilon = 0.01f;
	public int factoryLevel = 1;

	private const float TIMER_MAX = 2.0f; //Will need balancing
	private float moneyTimer = TIMER_MAX;

	public GameObject moneyballPreFab;
	public money playerMoneyRef;

	void Start()
	{
		//Get moneyballPreFab

		//Get playerMoneyRef
		playerMoneyRef = GameObject.Find("ScriptHolder").GetComponent<money>(); //Check if the name of the object is gonna change
	}

	public void UpdateFactory(float _cMult, bool _isManaged)
	{
		moneyTimer -= Time.deltaTime;

		if(moneyTimer <= 0.0f)
		{
			float moneyVal = 0.0f;

			moneyVal = baseVal * _cMult * (Mathf.Pow (expEpsilon, factoryLevel / 10.0f)); //Will need balancing

			if(_isManaged)
			{
				//Add money directly to player
				playerMoneyRef.AddMoney(moneyVal);
			}
			else
			{
				//Release moneyball with moneyVal

			}
		}

	}

	public void UpgradeLevel()
	{
		factoryLevel++;
	}

}