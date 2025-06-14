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
 
#if UNITY_EDITOR
 public override string GetJsonSaveData()
 {
  return JsonUtility.ToJson(_dataKey);
 }

 public override void SetJsonData(string json)
 {
  _dataKey = JsonUtility.FromJson<KeyAnimPlay>(json);
 }
#endif
}
