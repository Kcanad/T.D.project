using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] private Color _notEnoughMoneyColor;
    [SerializeField] private Color _hoverColor;
    private Renderer _rend;
    private Color _startColor;
    
    public GameObject _turret;

    public Vector3 positionOffset;

    BuildManager _buildManager;

    void Start()
    {
        _rend = GetComponent<Renderer>();
        _startColor = _rend.material.color;

        _buildManager = BuildManager.instance;
    }

    public void OnMouseDown()
    {
        if(!_buildManager.CanBuild)
            return;

        if (_turret != null)
        {
            Debug.Log("Can't buid there");
            return;
        }
        
       _buildManager.BuildTurretOn(this);
    }
    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }


    public void OnMouseEnter()
    {
        if (!_buildManager.CanBuild)
            return;

        if (_buildManager.HasMoney)
        {
            _rend.material.color = _hoverColor;
        }
        else
        {
            _rend.material.color = _notEnoughMoneyColor;
        }

        
    }
    public void OnMouseExit()
    {
        _rend.material.color = _startColor;
    }
}
