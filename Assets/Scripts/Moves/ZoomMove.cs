using UnityEngine;
using System.Collections;

public class ZoomMove : MonoBehaviour {

	public float startMax;

	public float startMin;

	public float distance;

	public enum State
	{
		MIN,
		MAX

	}

	public State curentState;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (curentState == State.MAX) {
			if (this.transform.localScale.x < startMax)
			{
				this.transform.localScale = new Vector3(this.transform.localScale.x + distance, this.transform.localScale.y + distance,  this.transform.localScale.z);
			}
			else
			{
				curentState = State.MIN;
			}
		} else {
			if (this.transform.localScale.x > startMin)
			{
				this.transform.localScale = new Vector3(this.transform.localScale.x - distance, this.transform.localScale.y - distance,  this.transform.localScale.z);
			}
			else
			{
				curentState = State.MAX;
			}
		}
	}
}
