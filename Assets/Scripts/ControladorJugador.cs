using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ControladorJugador :NetworkBehaviour {

	public GameObject  BalaPrefab;
	public Transform EmisorBala;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(!isLocalPlayer)
		{
            return;
		}

		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
		var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;


		transform.Rotate(0,x,0);
		transform.Translate(0,0,z);

		if(Input.GetKeyDown(KeyCode.Space))
		{
			CmdFuego();
		}
	}
     
	//funcion que emite el disparo de la vala
	[Command]
	void CmdFuego()
	{
       var bala= (GameObject)Instantiate(BalaPrefab,EmisorBala.position,EmisorBala.rotation);

	   //generar velocidad de la vala hacia adelante y hace rotar a la bala
	   bala.GetComponent<Rigidbody>().velocity = bala.transform.forward *10;
	   bala.transform.Rotate(-90,0,0);

	   //destruccions de vala
	   Destroy(bala, 1.0f);

	   //Permite Existir a las balas
	   NetworkServer.Spawn(bala);
	}

	public override void OnStartLocalPlayer()
	{
		GetComponent<MeshRenderer>().material.color = Color.green;
	}
}
