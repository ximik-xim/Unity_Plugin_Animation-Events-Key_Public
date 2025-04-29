using UnityEngine; 
using TListPlugin; 
[System.Serializable]
public class IdentifierAndData_KeyAnimEvent : AbsIdentifierAndData<IndifNameSO_KeyAnimEvent, string, KeyAnimEvent>
{

 [SerializeField] 
 private KeyAnimEvent _dataKey;


 public override KeyAnimEvent GetKey()
 {
  return _dataKey;
 }
}
