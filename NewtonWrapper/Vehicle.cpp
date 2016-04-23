#include "stdafx.h"
#include "NewtonWrapper.h"

CustomVehicleControllerManager* NewtonCreateVehicleManager(NewtonWorld* world)
{
	int defaultMaterial = NewtonMaterialGetDefaultGroupID(world);
	NewtonMaterialSetDefaultFriction(world, defaultMaterial, defaultMaterial, 0.6f, 0.5f);
	int materialList[] = { defaultMaterial };

	return new CustomVehicleControllerManager(world, 1, materialList);
}

void NewtonDestroyVehicleManager(CustomVehicleControllerManager* vehicleManager)
{
	delete vehicleManager;
}

CustomVehicleController* NewtonCreateVehicle(CustomVehicleControllerManager* vehicleManager, NewtonCollision* chassiShape, const dMatrix& matrix, float mass, float steeringMaxAngle, float maxBrakeTorque, NewtonApplyForceAndTorque forceCallback)
{
	dMatrix vehicleFrame;
	vehicleFrame.m_front = dVector(1.0f, 0.0f, 0.0f, 0.0f);			// this is the vehicle direction of travel
	vehicleFrame.m_up = dVector(0.0f, 1.0f, 0.0f, 0.0f);			// this is the downward vehicle direction
	vehicleFrame.m_right = vehicleFrame.m_front * vehicleFrame.m_up;	// this is in the side vehicle direction (the plane of the wheels)
	vehicleFrame.m_posit = dVector(0.0f, 0.0f, 0.0f, 1.0f);

	CustomVehicleController* v = vehicleManager->CreateVehicle(chassiShape, vehicleFrame, mass, forceCallback, 0);

	NewtonBody* carBody = v->GetBody();
	NewtonBodySetMatrix(carBody, &matrix[0][0]);

	CustomVehicleController::SteeringController* steering = new CustomVehicleController::SteeringController(v, steeringMaxAngle * 3.141592f / 180.0f);
	v->SetSteering(steering);

	CustomVehicleController::BrakeController* brakes = new CustomVehicleController::BrakeController(v, maxBrakeTorque);
	v->SetBrakes(brakes);

	CustomVehicleController::BrakeController* handBrakes = new CustomVehicleController::BrakeController(v, maxBrakeTorque);
	v->SetHandBrakes(handBrakes);

	return v;
}

CustomVehicleController::BodyPartTire* NewtonVehicleAddTire(CustomVehicleController* vehicle, dVector& pos, TireParameters* params)
{

	CustomVehicleController::BodyPartTire::Info info;
	info.m_width = params->width;
	info.m_radio = params->radius;
	info.m_mass = params->mass;
	info.m_suspesionlenght = params->suspensionLenght;
	info.m_springStrength = params->springStrength;
	info.m_dampingRatio = params->dampingRatio;
	info.m_lateralStiffness = params->lateralStiffness;
	info.m_longitudialStiffness = params->longitudinalStiffness;
	info.m_aligningMomentTrail = params->aligningMomentTrail;
	info.m_location = pos;


	return vehicle->AddTire(info);
}

void NewtonVehicleSetEngineParams(CustomVehicleController* vehicle, EngineParameters* params, 
	CustomVehicleController::BodyPartTire* leftFrontTire, CustomVehicleController::BodyPartTire* rightFrontTire,
	CustomVehicleController::BodyPartTire* leftRearTire, CustomVehicleController::BodyPartTire* rightRearTire, int differentialType)
{
	CustomVehicleController::EngineController::Info engineInfo;
	engineInfo.m_mass = params->mass;
	engineInfo.m_radio = params->ratio;
	engineInfo.m_vehicleTopSpeed = params->topSpeed;

	engineInfo.m_peakTorque = params->peakTorque;
	engineInfo.m_rpmAtPeakTorque = params->rpmAtPeakTorque;
	engineInfo.m_peakHorsePower = params->peakHorsePower;
	engineInfo.m_rpmAtPeakHorsePower = params->rpmAtPeakHorsePower;
	engineInfo.m_redLineTorque = params->redLineTorque;
	engineInfo.m_rpmAtReadLineTorque = params->rpmAtRedLineTorque;
	engineInfo.m_idleTorque = params->idleTorque;
	engineInfo.m_rpmAtIdleTorque = params->rpmAtIdleTorque;

	engineInfo.m_gearsCount = params->gearsCount;
	engineInfo.m_reverseGearRatio = params->gearRatioReverse;
	engineInfo.m_gearRatios[0] = params->gearRatio1;
	engineInfo.m_gearRatios[1] = params->gearRatio2;
	engineInfo.m_gearRatios[2] = params->gearRatio3;
	engineInfo.m_gearRatios[3] = params->gearRatio4;
	engineInfo.m_gearRatios[4] = params->gearRatio5;
	engineInfo.m_gearRatios[5] = params->gearRatio6;
	engineInfo.m_gearRatios[6] = params->gearRatio7;
	engineInfo.m_gearRatios[7] = params->gearRatio8;
	engineInfo.m_gearRatios[8] = params->gearRatio9;
	engineInfo.m_gearRatios[9] = params->gearRatio10;

	engineInfo.m_clutchFrictionTorque = params->clutchFrictionTorque;

	CustomVehicleController::EngineController::DifferentialAxel axel0;
	CustomVehicleController::EngineController::DifferentialAxel axel1;

	switch (differentialType)
	{
	case 0:
		axel0.m_leftTire = leftRearTire;
		axel0.m_rightTire = rightRearTire;
		break;
	case 1:
		axel0.m_leftTire = leftFrontTire;
		axel0.m_rightTire = rightFrontTire;
		break;
	default:
		axel0.m_leftTire = leftRearTire;
		axel0.m_rightTire = rightRearTire;
		axel1.m_leftTire = leftFrontTire;
		axel1.m_rightTire = rightFrontTire;
	}

	engineInfo.m_slipDifferentialOn = 1;

	//CustomVehicleController::EngineController* engine = new CustomVehicleController::EngineController(vehicle, engineInfo, axel0, axel1);
	//vehicle->AddEngineBodyPart(engine);

	CustomVehicleController::EngineController* engineControl = new CustomVehicleController::EngineController(vehicle, engineInfo, axel0, axel1);

	engineControl->SetTransmissionMode(true); //Automatic Transmission
	engineControl->SetIgnition(true);
	engineControl->SetClutchParam(1.0f);
	vehicle->SetEngine(engineControl);

	vehicle->SetWeightDistribution(0.5f);

	//CustomVehicleController::ClutchController* clutch = new CustomVehicleController::ClutchController(vehicle, engine, 1000000.0f);
	//vehicle->SetClutch(clutch);
	//clutch->SetParam(1);

}

void NewtonVehicleSteeringAddTire(CustomVehicleController* vehicle, CustomVehicleController::BodyPartTire* tire)
{
	CustomVehicleController::SteeringController* steering = vehicle->GetSteering();
	steering->AddTire(tire);
}

void NewtonVehicleBrakesAddTire(CustomVehicleController* vehicle, CustomVehicleController::BodyPartTire* tire)
{
	CustomVehicleController::BrakeController* brakes = vehicle->GetBrakes();
	brakes->AddTire(tire);
}

void NewtonVehicleHandBrakesAddTire(CustomVehicleController* vehicle, CustomVehicleController::BodyPartTire* tire)
{
	CustomVehicleController::BrakeController* handBrakes = vehicle->GetHandBrakes();
	handBrakes->AddTire(tire);
}

void NewtonVehicleFinalize(CustomVehicleController* vehicle)
{
	vehicle->Finalize();
}


void NewtonDestroyVehicle(CustomVehicleControllerManager* vehicleManager, CustomVehicleController* vehicle)
{
	// Destroy chassi body
	NewtonDestroyBody(vehicle->GetBody());

	// Destroy tires
	for (dList<CustomVehicleController::BodyPartTire>::dListNode* node = vehicle->GetFirstTire(); node; node = node->GetNext())
	{
		CustomVehicleController::BodyPartTire* const tire = &node->GetInfo();
		NewtonBody* tireBody = tire->GetBody();
		NewtonDestroyBody(tireBody);
	}

	// Destroy vehicle controller
	vehicleManager->DestroyController(vehicle);
}

void NewtonVehicleSetThrottle(CustomVehicleController* vehicle, float throttle)
{
	vehicle->GetEngine()->SetParam(throttle);
}

void NewtonVehicleSetSteering(CustomVehicleController* vehicle, float steering)
{
	vehicle->GetSteering()->SetParam(steering);
}

void NewtonVehicleSetBrakes(CustomVehicleController* vehicle, float brakes)
{
	vehicle->GetBrakes()->SetParam(brakes);
}

void NewtonVehicleSetHandBrakes(CustomVehicleController* vehicle, float brakes)
{
	vehicle->GetHandBrakes()->SetParam(brakes);
}

void NewtonVehicleSetGear(CustomVehicleController* vehicle, int gear)
{
	vehicle->GetEngine()->SetGear(gear);
}

float NewtonVehicleGetSpeed(CustomVehicleController* vehicle)
{
	return vehicle->GetEngine()->GetSpeed();
}

int NewtonVehicleGetGear(CustomVehicleController* vehicle)
{
	return vehicle->GetEngine()->GetGear();
}

float NewtonVehicleGetRPM(CustomVehicleController* vehicle)
{
	return vehicle->GetEngine()->GetRPM();
}

NewtonBody* NewtonVehicleGetBody(CustomVehicleController* vehicle)
{
	return vehicle->GetBody();
}

NewtonBody* NewtonVehicleTireGetBody(CustomVehicleController::BodyPartTire* tire)
{
	return tire->GetBody();
}

void NewtonVehicleSetCOM(CustomVehicleController* vehicle, dVector& com)
{
	vehicle->SetCenterOfGravity(com);
}

