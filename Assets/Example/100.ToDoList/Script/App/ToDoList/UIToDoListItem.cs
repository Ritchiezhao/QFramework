﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using UnityEngine.UI;
using ToDoList;

public class UIToDoListItem : QMonoBehaviour {

	protected override void SetupMgr ()
	{
		mCurMgr = QUIManager.Instance;
	}

	public override void ProcessMsg (QMsg msg) 
	{
		
	}

	[SerializeField] Text m_Title;
	[SerializeField] Button m_BtnComplete;

	ToDoListItemData m_ToDoListItemData;

	public ToDoListItemData ToDoListItemData {
		set {
			m_ToDoListItemData = value;
			UpdateView ();
		}
	}

	void Awake() {
		m_Title = transform.Find ("Title").GetComponent<Text> ();
		m_BtnComplete = transform.Find ("BtnComplete").GetComponent<Button> ();

		m_BtnComplete.onClick.AddListener (delegate {
			m_ToDoListItemData.Complete = true;
		});
		UpdateView ();
	}

	void UpdateView() {
		if (null != m_ToDoListItemData) {
			m_Title.text = m_ToDoListItemData.Title;
			m_BtnComplete.gameObject.SetActive (!m_ToDoListItemData.Complete);
		}
	}
}