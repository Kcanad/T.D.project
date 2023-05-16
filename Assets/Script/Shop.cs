using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public Turretblueprint StandartTurret;
    public Turretblueprint MissleLauncher;
    public Turretblueprint LaserBeamer;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        buildManager.SelectTurretToBuild(StandartTurret);
    }

    public void SelectMissileLauncher()
    {
        buildManager.SelectTurretToBuild(MissleLauncher);
    }

    public void SelectLaserBeamer()
    {
        buildManager.SelectTurretToBuild(LaserBeamer);
    }
}
