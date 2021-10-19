using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using UnityEngine;
using UnityEngine.Networking;

public class TestDB : MonoBehaviour
{
   
   public string DataSource;
   protected string databasePath;
   protected SqliteConnection Connection => new SqliteConnection($"Data Source = {DataSource};");
   IEnumerator Upload() {
      byte[] myData = System.Text.Encoding.UTF8.GetBytes(DataSource);
      UnityWebRequest www = UnityWebRequest.Put("url",myData);
      yield return www.SendWebRequest();

      if (www.result != UnityWebRequest.Result.Success) {
         Debug.Log(www.error);
      }
      else {
         Debug.Log("Upload complete!");
      }
   }
      private void Awake() {

   /* using (var con = new SqliteConnection($"Data source = {DataSource}"))
    {
       con.Open();
    } */
    if (string.IsNullOrEmpty(this.DataSource)){
       Debug.LogError("Campo vazio");
    }
    else {
       CreateTable();
    }

 void CreateTable() {
      using (var conn = Connection) {
         var commandText = $"CREATE TABLE TabelaTeste" +
         $"(" +
         $"   Id INTEGER PRIMARY KEY," +
         $"   Patience_Name INTEGER STRING," +
         $"    Physician_Name TEXT NOT NULL" +
         $");";
         conn.Open();

         using (var command = conn.CreateCommand())
         {
            command.CommandText = commandText;
            command.ExecuteNonQuery();
            Debug.Log("Break Point");
         }
      }
   }
   StartCoroutine(Upload());
  }
 }
     
