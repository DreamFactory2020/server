using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Interact_Disposal : MonoBehaviour
{
	public Transform target;
	public Vector3 direction;
	private bool isNear;

	public static event Action<bool> PlayerGetClosed = delegate { };

	void Update()
	{
		MakeBtnInteractable();
	}

	public void MakeBtnInteractable()
	{
		// Player의 현재 위치를 받아오는 Object
		target = GameObject.Find("Player1").transform;
		// Player의 위치와 이 객체의 위치를 빼고 단위 벡터화 한다.
		direction = (target.position - transform.position).normalized;
		// Player와 객체 간의 거리 계산
		float distance = Vector3.Distance(target.position, transform.position);
		// 일정거리 안에 있을 시, 버튼 활성화
		if (distance <= 1.8f)
		{
			isNear = true;
		}
		// 일정거리 밖에 있을 시, 버튼 비활성화
		else
		{
			isNear = false;
		}
		PlayerGetClosed(isNear);
	}
}

