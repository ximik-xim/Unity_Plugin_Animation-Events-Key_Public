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
 
#if UNITY_EDITOR
 public override string GetJsonSaveData()
 {
  return JsonUtility.ToJson(_dataKey);
 }

 public override void SetJsonData(string json)
 {
  _dataKey = JsonUtility.FromJson<KeyAnimEvent>(json);
 }
#endif
}
