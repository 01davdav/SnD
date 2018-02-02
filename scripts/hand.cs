using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hand : MonoBehaviour
{
	public List<GameObject> handCards = new List<GameObject>();
	public GameObject resourceCard;
	
	[SerializeField]
	private AnimationCurve _animationCurve;
	
	// Use this for initialization
	void Start ()
	{
		int amount = 7;
		
		float height = Camera.main.orthographicSize * 2.0f;
		float width = (height * Screen.width / Screen.height)-4f;

		float partOfWidth = width / (amount-1);
		
		for (int i = 0; i < amount; i++)
		{
			GameObject card = Instantiate(resourceCard, new Vector3((-width/2+partOfWidth*i), -height/2+0.5f, ((float)i/10f)), Quaternion.identity) as GameObject;
			card.transform.parent = gameObject.transform;
			card.GetComponent<resources>().type = (int)(UnityEngine.Random.value*4+.5);
			handCards.Add(card);
		}
		sortHand();
		
		for (int i = 0; i < handCards.Count; i++)
		{
			handCards[i].GetComponent<Transform>().position = new Vector3((-width/2+partOfWidth*i), -height/2+0.5f, ((float)i/10f));
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void updateHand(float time)
	{
		sortHand();
		
		float height = Camera.main.orthographicSize * 2.0f;
		float width = (height * Screen.width / Screen.height)-4f;

		float partOfWidth = width / (handCards.Count-1);
		
		for (int i = 0; i < handCards.Count; i++)
		{
			StartCoroutine(MoveToPosition(handCards[i].GetComponent<Transform>(), new Vector3((-width/2+partOfWidth*i), -height/2+0.5f, ((float)i/10f)), time));
		}
	}
	
	public void sortHand ()
	{
		int i, j;
		int N = handCards.Count;

		for (j=N-1; j>0; j--) {
			for (i=0; i<j; i++) {
				if (handCards[i].GetComponent<resources>().type > handCards[i + 1].GetComponent<resources>().type)
					exchangeCards(i, i + 1);
			}
		}
	}
	
	public void exchangeCards(int m, int n)
	{
		GameObject temporary;

		temporary = handCards[m];
		handCards[m] = handCards[n];
		handCards[n] = temporary;
	}
	
	public IEnumerator MoveToPosition(Transform transform, Vector3 position, float timeToMove)
	{
		var currentPos = transform.position;
		var t = 0f;
		while(t < 1)
		{
			t += Time.deltaTime / timeToMove;
			transform.position = Vector3.Lerp(currentPos, position, _animationCurve.Evaluate(t));
			yield return null;
		}
	}
}
