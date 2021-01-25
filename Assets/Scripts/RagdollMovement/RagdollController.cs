using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    public bool DoNotSync;
    public GameObject mirrorJoint;

    Rigidbody myRigidBody;
    ConfigurableJoint myJoint;

    //starting point (anchor for the joints)
    Vector3 MirrorAnchorPosition;
    Quaternion MirrorAnchorRotation;

    private void Start()
    {
        myRigidBody = this.gameObject.GetComponent<Rigidbody>();
        myJoint = this.gameObject.GetComponent<ConfigurableJoint>();

        /*if (myJoint.axis == new Vector3(0, 0, -1) && myJoint.secondaryAxis == new Vector3(-1, 0, 0))
        {
            MirrorAnchorPosition = new Vector3(-mirrorJoint.transform.position.z, -mirrorJoint.transform.position.x, mirrorJoint.transform.position.y);
            MirrorAnchorRotation = new Quaternion(-mirrorJoint.transform.rotation.z, -mirrorJoint.transform.rotation.x, mirrorJoint.transform.rotation.y, mirrorJoint.transform.rotation.w);
        }
        else if (myJoint.axis == new Vector3(0, -1, 0) && myJoint.secondaryAxis == new Vector3(-1, 0, 0))
        {
            MirrorAnchorPosition = new Vector3(-mirrorJoint.transform.position.y, -mirrorJoint.transform.position.x, mirrorJoint.transform.position.z);
            MirrorAnchorRotation = new Quaternion(-mirrorJoint.transform.rotation.y, -mirrorJoint.transform.rotation.x, mirrorJoint.transform.rotation.z, mirrorJoint.transform.rotation.w);
        }
        else if (myJoint.axis == new Vector3(0, 1, 0) && myJoint.secondaryAxis == new Vector3(-1, 0, 0))
        {
            MirrorAnchorPosition = new Vector3(mirrorJoint.transform.position.y, -mirrorJoint.transform.position.x, mirrorJoint.transform.position.z);
            MirrorAnchorRotation = new Quaternion(mirrorJoint.transform.rotation.y, -mirrorJoint.transform.rotation.x, mirrorJoint.transform.rotation.z, mirrorJoint.transform.rotation.w);
        }*/
        MirrorAnchorPosition = mirrorJoint.transform.position;
        MirrorAnchorRotation = mirrorJoint.transform.rotation;
    }

    private void FixedUpdate()
    {
        if (!DoNotSync)
        {
            Vector3 MirrorTargetPosition = GetTargetPosition(mirrorJoint.transform.position, MirrorAnchorPosition);
            myJoint.targetPosition = MirrorTargetPosition;
            Debug.DrawLine(this.transform.root.gameObject.transform.transform.position, GetMyWorldTargetPosition(), Color.yellow);

            Quaternion MirrorTargetRotation = GetTargetRotation(mirrorJoint.transform.rotation, MirrorAnchorRotation);
            myJoint.targetRotation = MirrorTargetRotation;
            /*if (myJoint.axis == new Vector3(0, 0, -1) && myJoint.secondaryAxis==new Vector3(-1, 0, 0))
            {
                Vector3 MirrorTargetPosition = GetTargetPosition(mirrorJoint.transform.position, MirrorAnchorPosition);
                myJoint.targetPosition = new Vector3(-MirrorTargetPosition.z, -MirrorTargetPosition.x, MirrorAnchorPosition.y);
                Debug.DrawLine(this.transform.root.gameObject.transform.transform.position, GetMyWorldTargetPosition(), Color.yellow);

                Quaternion MirrorTargetRotation = GetTargetRotation(mirrorJoint.transform.rotation, MirrorAnchorRotation);
                myJoint.targetRotation = new Quaternion(-MirrorTargetRotation.z, -MirrorTargetRotation.x, MirrorTargetRotation.y, -MirrorTargetRotation.w);
            }
            else if (myJoint.axis == new Vector3(0, -1, 0) && myJoint.secondaryAxis == new Vector3(-1, 0, 0))
            {
                Vector3 MirrorTargetPosition = GetTargetPosition(mirrorJoint.transform.position, MirrorAnchorPosition);
                myJoint.targetPosition = new Vector3(-MirrorTargetPosition.y, -MirrorTargetPosition.x, MirrorAnchorPosition.z);
                Debug.DrawLine(this.transform.root.gameObject.transform.transform.position, GetMyWorldTargetPosition(), Color.yellow);

                Quaternion MirrorTargetRotation = GetTargetRotation(mirrorJoint.transform.rotation, MirrorAnchorRotation);
                myJoint.targetRotation = new Quaternion(-MirrorTargetRotation.y, -MirrorTargetRotation.x, MirrorTargetRotation.z, -MirrorTargetRotation.w);
            }
            else if (myJoint.axis == new Vector3(0, 1, 0) && myJoint.secondaryAxis == new Vector3(-1, 0, 0))
            {
                Vector3 MirrorTargetPosition = GetTargetPosition(mirrorJoint.transform.position, MirrorAnchorPosition);
                myJoint.targetPosition = new Vector3(MirrorTargetPosition.y, -MirrorTargetPosition.x, MirrorAnchorPosition.z);
                Debug.DrawLine(this.transform.root.gameObject.transform.transform.position, GetMyWorldTargetPosition(), Color.yellow);

                Quaternion MirrorTargetRotation = GetTargetRotation(mirrorJoint.transform.rotation, MirrorAnchorRotation);
                myJoint.targetRotation = new Quaternion(MirrorTargetRotation.y, -MirrorTargetRotation.x, MirrorTargetRotation.z, -MirrorTargetRotation.w);
            }
            {
                Vector3 MirrorTargetPosition = GetTargetPosition(mirrorJoint.transform.position, MirrorAnchorPosition);
                myJoint.targetPosition = MirrorTargetPosition;
                Debug.DrawLine(this.transform.root.gameObject.transform.transform.position, GetMyWorldTargetPosition(), Color.yellow);

                Quaternion MirrorTargetRotation = GetTargetRotation(mirrorJoint.transform.rotation, MirrorAnchorRotation);
                myJoint.targetRotation = MirrorTargetRotation;
            }*/
        }
    }

    Vector3 GetTargetPosition(Vector3 currentPosition, Vector3 anchorPosition)
    {
        return anchorPosition - currentPosition;
    }

    Quaternion GetTargetRotation(Quaternion currentRotation, Quaternion anchorRotation)
    {
        return Quaternion.Inverse(currentRotation) * anchorRotation;
    }

    Vector3 GetMyWorldTargetPosition()
    {
        if (myJoint.connectedBody == null)
        {
            return Vector3.zero;
        }
        else
        {
            Vector3 myTargetPosition = myRigidBody.position + myJoint.targetPosition;

            return myTargetPosition;
        }
    }
}