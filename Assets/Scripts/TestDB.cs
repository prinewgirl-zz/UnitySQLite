using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using UnityEngine;

public class TestDB : MonoBehaviour
{
   
   public string DataSource;
   protected string databasePath;
      private void Awake() {
   using (var con = new SqliteConnection($"Data source = {DataSource}"))
    {
       con.Open();
    }
  }
}
     
