using UnityEngine;
using System.Collections;

public class MonedaRecogible : Recogible {

	public int valorMoneda = 5;


	protected override void Recogido ()
	{
		Referencias.encuentro.AddCoils (valorMoneda, this.transform.position);
	}
}
