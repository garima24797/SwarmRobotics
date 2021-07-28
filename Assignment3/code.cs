Void FixedUpdate()
    {
        Var deltaPosition = Vector3.zero;
        For (int I = 0; I < NumberOfRays; i++)
        {
            
            Var rotation = this.transform.rotation;
           Var RotationMod= Quaternion.AngleAxis((I /((float)NumberOfRays-1)) * angle*2-angle, this.transform.up);
            Var direction = rotation * RotationMod * Vector3.forward;
            RaycastHit hitInfo;
            Var ray = new Ray(this.transform.position, direction);
            If (Physics.Raycast(ray, out hitInfo, ray_range)) 
            {
                deltaPosition -= (1.0f / NumberOfRays) * TargetVelocity * direction;
            }
            Else
            {
                deltaPosition += (1.0f / NumberOfRays) * TargetVelocity * direction;
            }
        }

        This.transform.position += deltaPosition * Time.deltaTime;

    }
