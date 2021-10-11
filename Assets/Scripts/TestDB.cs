using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using UnityEngine;

public class TestDB : MonoBehaviour
{
   private void Awake() {
   using (var con = new SqliteConnection("Data source = Test.db"))
    {
       con.Open();
    }
  }
}
     
