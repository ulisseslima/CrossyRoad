#pragma strict

var waterLevel : float = 4;
var floatHeight : float = 2;
var bounceDamp : float = 0.05;
var buoyancyCentreOffset : Vector3;

private var forceFactor : float;
private var actionPoint : Vector3;
private var upLift : Vector3;

function Update () {
	actionPoint = transform.position + transform.TransformDirection(buoyancyCentreOffset);
	forceFactor = 1f - ((actionPoint.y - waterLevel) / floatHeight);
	
	if (forceFactor > 0f) {
		upLift = -Physics.gravity * (forceFactor - GetComponent.<Rigidbody>().velocity.y * bounceDamp);
		GetComponent.<Rigidbody>().AddForceAtPosition(upLift, actionPoint);
	}
}