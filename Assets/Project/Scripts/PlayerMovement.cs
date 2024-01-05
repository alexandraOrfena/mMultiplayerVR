using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void FixedUpdateNetwork()
    {
        base.FixedUpdateNetwork();

        if (GetInput<PlayerInputData>(out var inputData))
        {
            transform.Translate(inputData.direction*Runner.DeltaTime * moveSpeed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
