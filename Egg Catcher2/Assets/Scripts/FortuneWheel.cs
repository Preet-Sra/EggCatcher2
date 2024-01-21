using UnityEngine;
using EasyUI.PickerWheelUI;

public class FortuneWheel : MonoBehaviour
{
    [SerializeField] private PickerWheel pickerWheel;

	public void Spin()
	{
		pickerWheel.OnSpinStart(() => {
		Debug.Log("Spin start...");
	});

		pickerWheel.OnSpinEnd(wheelPiece => {
			Debug.Log("Spin end :") ;
			Debug.Log("Index   : "+wheelPiece.Index);
			Debug.Log("Chance  : "+wheelPiece.Chance);
			Debug.Log("Label   : "+wheelPiece.Label);
			Debug.Log("Amount  : "+wheelPiece.Amount);
		});

pickerWheel.Spin();
	}
}
