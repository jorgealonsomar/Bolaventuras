using UnityEngine;
using System.Collections;

public class MonedaRecogible : Recogible {

	public int valorMoneda = 5;


	protected override void Recogido () {
		Encuentro.AddCoils (valorMoneda);
	}
}
