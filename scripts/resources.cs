using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resources : MonoBehaviour {

    public int type;
	public Sprite Drugs;
	public Sprite Fame;
	public Sprite GottesSegen;
	public Sprite Love;
	public Sprite Money;
	
	public Sprite[] sprites = new Sprite[5];
	

	// Use this for initialization
	void Start ()
	{
		sprites[0] = Drugs;
		sprites[1] = Fame;
		sprites[2] = GottesSegen;
		sprites[3] = Love;
		sprites[4] = Money;
		updateCard();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void updateCard()
	{
		this.GetComponent<SpriteRenderer>().sprite = sprites[type];
	}
}
