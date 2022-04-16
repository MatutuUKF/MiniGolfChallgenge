using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
	private static T instance;
	public static T Instance
	{


		get
		{

			if (instance == null)
			{

				instance = GameObject.FindObjectOfType<T>();
				if (instance == null)

				{

					instance = new GameObject("Instance of " + typeof(T)).AddComponent<T>();

				}


			}

			return instance;


		}



	}



    private void Awake()
    {
		if (instance != null) {

			Destroy(this.gameObject);

		}
    }



}