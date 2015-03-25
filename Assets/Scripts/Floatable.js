#pragma strict

var waterLevel : float = -1; // where the water starts in the scene
var floatHeight : float = 2;
var bounceDamp : float = 0.05;
var force : float = 1f;
var buoyancyCentreOffset : Vector3;

private var forceFactor : float;
private var actionPoint : Vector3;
private var upLift : Vector3;

function Update () {
	actionPoint = transform.position + transform.TransformDirection(buoyancyCentreOffset);
	forceFactor = force - ((actionPoint.y - waterLevel) / floatHeight);
	
	if (forceFactor > 0f) {
		upLift = -Physics.gravity * (forceFactor - GetComponent.<Rigidbody>().velocity.y * bounceDamp);
		GetComponent.<Rigidbody>().AddForceAtPosition(upLift, actionPoint);
	}
}