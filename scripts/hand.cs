using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hand : MonoBehaviour
{
	public List<GameObject> handCards = new List<GameObject>();
	public GameObject resourceCard;
	
	// Use this for initialization
	void Start () {
		for (int i = 0; i < 5; i++)
		{
			GameObject card = Instantiate(resourceCard, new Vector3((float)i, 1, (float)-i), Quaternion.identity) as GameObject;
			card.transform.parent = gameObject.transform;
			card.GetComponent<resources>().type = i;
			handCards.Add(card);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
