using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public CreateRope rope;
	public int level = 0;
	public GameObject[] elementsGenerators;

	private void Start()
	{
		 rope = FindObjectOfType<CreateRope>();
	}
	// Update is called once per frame
	void Update()
	{
		
	}

	public void AddLevel(){
		level += 1;
		rope.DecreaseDistanceRope(level);

		foreach (GameObject o in elementsGenerators)
		{
			o.SetActive(false);
		}
		elementsGenerators[level - 1].SetActive(true);
	}
}
