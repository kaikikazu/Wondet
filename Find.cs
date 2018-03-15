using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
自キャラが分かるように追従する目印スクリプト
*/
public class Find : MonoBehaviour {

	public GameObject unity;
	bool flag;
	// Use this for initialization
	void Start () {
		flag = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!flag) {
			unity = GameObject.Find ("unitychan_dynamic_locomotion (1)(Clone)");
			transform.parent = unity.transform;
			flag = true;
		}
	}
}
