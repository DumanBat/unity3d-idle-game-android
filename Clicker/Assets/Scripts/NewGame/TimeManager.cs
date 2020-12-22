using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TimeManager : MonoBehaviour
{

	public static TimeManager sharedInstance = null;
	private string _url = "https://idlefarm2000.000webhostapp.com";
	private string _timeData;
	public static string _currentTime;
	public static string _currentDate;


	
	void Awake()
	{
		if (sharedInstance == null)
		{
			sharedInstance = this;
		}
		else if (sharedInstance != this)
		{
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
	}


	public IEnumerator GetTime()
	{
		Debug.Log("connecting to php");
		UnityWebRequest request = UnityWebRequest.Get(_url);
		yield return request.SendWebRequest();
		if (request.isHttpError)
		{
			Debug.Log("Error HTTP");
		}
		if (request.isNetworkError)
        {
			Debug.Log("Error Network");
        }
		
		else
		{
			Debug.Log("got the php information");
			_timeData = request.downloadHandler.text;
			request.Dispose();
			//Debug.Log(_timeData);
			string[] words = _timeData.Split('/');

			//Debug.Log("The date is : " + words[0]);
			//Debug.Log("The time is : " + words[1]);

			//setting current time
			_currentDate = words[0];
			_currentTime = words[1];

		}
		/*else
		{
			Debug.Log("got the php information");
			//Debug.Log(request.downloadHandler.text);
		}
		_timeData = request.downloadHandler.text;
		request.Dispose();
		//Debug.Log(_timeData);
		string[] words = _timeData.Split('/');
		
		//Debug.Log("The date is : " + words[0]);
		//Debug.Log("The time is : " + words[1]);

		//setting current time
		_currentDate = words[0];
		_currentTime = words[1];*/




	}


	//get the current time at startup
	void Start()
	{
		Debug.Log("TimeManager script is Ready.");
		StartCoroutine("WaitForLoading");
	
	}

	//date format: 12-4-2017 is 1242017
	public int GetCurrentDateNow()
	{
		string[] words = _currentDate.Split('-');
		int x = int.Parse(words[0] + words[1] + words[2]);
		return x;
	}


	//get the current Time
	public string GetCurrentTimeNow()
	{
		return _currentTime;
	}

	IEnumerator WaitForLoading()
    {
		yield return new WaitForSeconds(5);

		if (InternetCheck.isInternetAccesable == true)
        {
			StartCoroutine("GetTime");
		}

    }
}
