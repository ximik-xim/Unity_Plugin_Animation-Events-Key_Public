using UnityEngine; 
using TListPlugin; 
[System.Serializable]
public class IdentifierAndData_KeyAnimPlay : AbsIdentifierAndData<IndifNameSO_KeyAnimPlay, string, KeyAnimPlay>
{

 [SerializeField] 
 private KeyAnimPlay _dataKey;


 public override KeyAnimPlay GetKey()
 {
  return _dataKey;
 }
}
