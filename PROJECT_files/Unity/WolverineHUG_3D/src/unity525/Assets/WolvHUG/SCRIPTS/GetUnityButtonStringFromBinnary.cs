using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
public class GetUnityButtonStringFromBinnary : MonoBehaviour {

	public class MyClass{
public  string StrChk="";
public string HugBtnStr = "HUG";
   public void HandelLog(string logString, string logString1, LogType type){
StrChk = logString;
   }         
        }
	
	public static MyClass LoadFromResources(string filename){
			string fileName = Path.GetFileNameWithoutExtension(Application.dataPath+filename);
//why textasset not loaded Check PATH
TextAsset textAsset = Resources.Load(fileName) as TextAsset;
Stream stream = new MemoryStream(textAsset.bytes);
BinaryFormatter formatter = new BinaryFormatter();
BinaryReader br = new BinaryReader(stream);
MyClass myInstance = formatter.Deserialize(stream) as MyClass;
//Stream  myInstance = formatter.Deserialize(stream) as Stream;
	stream.Close();
	return myInstance;
	}
    	public static string LoadBytesFromFile(string filename){
    MyClass mgt= new MyClass();
string textBtn = mgt.HugBtnStr;
byte[] bytesOfFile = File.ReadAllBytes(Application.dataPath+"/"+filename);
string strOfFile = Encoding.UTF8.GetString(bytesOfFile);
string strReadble="";
if (strOfFile.IndexOf("Fire1")>-1){
    int ind =strOfFile.IndexOf("Fire1");
string strSub =strOfFile.Substring(ind);
if (strSub.IndexOf("HUG")>-1){
    int ind1 =strSub.IndexOf("HUG");
string strFromFile = strSub.Substring(ind1+16,4);
bool addChars=true;
foreach(char Cha in strFromFile){
    Application.logMessageReceived += mgt.HandelLog;
    Debug.Log(Cha+"-btn~");
if(mgt.StrChk.Contains("-btn~") && addChars){
strReadble = strReadble + Cha.ToString(); 
}
else{
    addChars=false;
} 
textBtn = strReadble;
}
}
}
	return textBtn;
	}
static class EncodingUtility{
internal static readonly KeyValuePair<byte[], Encoding>[] encodingLookup;
internal static readonly Encoding targetEncoding = Encoding.GetEncoding(
    Encoding.UTF8.CodePage,
new EncoderReplacementFallback("~"),
new DecoderReplacementFallback("~"));
static EncodingUtility(){
Encoding utf8BOM = new UTF8Encoding(true, true);
encodingLookup = new KeyValuePair<byte[], Encoding>[]{
   new  KeyValuePair<byte[], Encoding>(utf8BOM.GetPreamble(),utf8BOM)
};
}
}
internal static string DecodeString(byte[] bytes){
Encoding encoding = null;
int preambleLength=0;
int encodingLookupLength=EncodingUtility.encodingLookup.Length;
for(int i = 0; i < encodingLookupLength; i++){
    byte[] preamble = EncodingUtility.encodingLookup[i].Key;
    preambleLength = preamble.Length;
    if(bytes.Length >= preambleLength)
    {
        for (int j=0; j<preambleLength; j++ ){
            if (preamble[j] != bytes[j]){
                preambleLength = -1;
            }
        }
        if (preambleLength < 0) continue;
        try
        {
            Encoding tempEncoding = EncodingUtility.encodingLookup[i].Value;
            string txt = tempEncoding.GetString(bytes, preambleLength, bytes.Length-preambleLength)+" !guard";
            encoding = tempEncoding;   
            break;
        }
        catch{};
    }
}
if (encoding == null){
    encoding = EncodingUtility.targetEncoding;
preambleLength=0;
}
return encoding.GetString(bytes, preambleLength, bytes.Length - preambleLength);
}
}
