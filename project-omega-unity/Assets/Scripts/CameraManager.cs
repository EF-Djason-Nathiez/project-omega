using System.Collections;
using UnityEngine;

public class CameraManager : MonoSingleton<CameraManager>
{
}

public enum CameraType
{
    Navigation,
    Combat
}