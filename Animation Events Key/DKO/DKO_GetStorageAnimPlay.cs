
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DKO_GetStorageAnimPlay : DKOTargetAction
{
    [SerializeField] 
    private StorageAnimPlay _storageAnimPlay;
    
    private void Awake()
    {
        LocalAwake();
    }
    
    protected override DKODataRund InvokeRun()
    {
        return new DKODataGetStorageAnimPlay(_storageAnimPlay);
    }
}

public class DKODataGetStorageAnimPlay : DKODataRund
{
    private StorageAnimPlay _storageAnimPlay;

    public DKODataGetStorageAnimPlay(StorageAnimPlay storageAnimPlay )
    {
        _storageAnimPlay = storageAnimPlay;
    }

    public StorageAnimPlay GetStorageAnimPlay()
    {
        return _storageAnimPlay;
    }
}