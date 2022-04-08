using UnityEngine;
using UnityEngine.Networking;

public class Enemigos : NetworkBehaviour {

	public GameObject enemigoPrefab;
	public int numeroDeEnemigos;

	public override void OnStartServer()
	{
        for(int i = 0; i < numeroDeEnemigos; i++)
		{
           var posRenacer = new Vector3 
		   (
            Random.Range(-8.0f, 8.0f),
			0.0f,
			Random.Range(-8.0f, 8.0f)
		   );

		   var rotRenacer = Quaternion.Euler
		   (
            0.0f,
			Random.Range(0, 180),
			0.0f
		   );

		   var enemigo = (GameObject)Instantiate(enemigoPrefab, posRenacer, rotRenacer);
		   NetworkServer.Spawn(enemigo);
		}
	}
}
