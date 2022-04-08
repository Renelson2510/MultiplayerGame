using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Salud : NetworkBehaviour {

    public static int saludMaxima = 100;
	[SyncVar(hook ="SincronizacionSalud")]
	public int saludActual = saludMaxima;
	public RectTransform  barraDeSalud;


	// Salud del jugador
	public void SerHerido(int cantidad) 
	{
		if(!isServer)
		{
          return;
		}
		saludActual -= cantidad;

		if(saludActual <= 0)
		{
			saludActual = saludMaxima;
			// Destroy(gameObject);
			RpcRenacer();
		}
		// Debug.Log(saludActual);
		
	}
	void SincronizacionSalud(int saludActual)
	{
       barraDeSalud.sizeDelta = new Vector2(saludActual, barraDeSalud.sizeDelta.y);
	}

	[ClientRpc]
	void RpcRenacer()
	{
		if(isLocalPlayer)
		{
           transform.position = Vector3.zero;
		}
	}
	
}
