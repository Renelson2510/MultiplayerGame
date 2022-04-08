using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour {

	// Destruye bala
	void OnCollisionEnter(Collision collision) 
	{
		var contacto = collision.gameObject;
		var salud = contacto.GetComponent<Salud>();

        if(salud != null)
		{
           salud.SerHerido(10);
		   Destroy(gameObject);
		}
		
		
	}
		
	
}
