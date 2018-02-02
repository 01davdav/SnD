using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deck : MonoBehaviour {

    public List<GameObject> handCards = new List<GameObject>();
    public GameObject eventCard;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            GameObject card = Instantiate(eventCard, new Vector3((float)i, 1, (float)-i), Quaternion.identity) as GameObject;
            card.transform.parent = gameObject.transform;
            card.GetComponent<events>().id = i;
            handCards.Add(card);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
