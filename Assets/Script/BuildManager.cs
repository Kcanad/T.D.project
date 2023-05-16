using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private Turretblueprint _turretToBuild;

    public static BuildManager instance;


    public bool CanBuild { get { return _turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= _turretToBuild.cost; } }

    private void Awake()
    {
        instance = this;
    }
    

    public void SelectTurretToBuild(Turretblueprint turret)
    {
        _turretToBuild= turret;
    }
    
    public void BuildTurretOn(Node node)
    {
        if(PlayerStats.Money < _turretToBuild.cost)
        {
            Debug.Log("Not Money");
            
            return;
        }

        PlayerStats.Money -= _turretToBuild.cost;

       GameObject turret = Instantiate(_turretToBuild.prefab, node.GetBuildPosition(),Quaternion.identity);
        node._turret = turret;

        Debug.Log("Turret build! "+ PlayerStats.Money);
    }

}
