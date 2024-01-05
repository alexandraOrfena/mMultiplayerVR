using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class NetworkRig : NetworkBehaviour
{
    public NetworkTransform _characterTransform;
    public NetworkTransform _headTransform;
    public NetworkTransform _handRightTransform;
    public NetworkTransform _handLeftTransform;
    public NetworkTransform _bodyTransform;

    HardwareRig hardwareRig;

    public override void Spawned()
    {
        base.Spawned();

        if (Object.HasStateAuthority)
        {
            hardwareRig = FindAnyObjectByType<HardwareRig>();
            if(hardwareRig = null)
                Debug.Log("missing hardware rig");
        }
        else
        {
            Debug.Log("this is client object");
        }
    }

    public override void FixedUpdateNetwork()
    {
        base.FixedUpdateNetwork();

        if (GetInput<XRRigInputData>(out var inputdata))
        {
            _characterTransform.transform.SetPositionAndRotation(inputdata.CharacterPosition, inputdata.CharacterRotation);
            _headTransform.transform.SetPositionAndRotation(inputdata.HeadSetPosition, inputdata.HeadSetRotation);
            _handRightTransform.transform.SetPositionAndRotation(inputdata.RightHandPosition, inputdata.RightHandRotation);
            _handLeftTransform.transform.SetPositionAndRotation(inputdata.LeftHandPosition, inputdata.LeftHandRotation);
            _bodyTransform.transform.SetPositionAndRotation(inputdata.BodyPosition, inputdata.BodyRotation);

        }
    }

    public override void Render()
    {
        base.Render();
        //if (Object.HasStateAuthority)
        //{ }
    }


}
