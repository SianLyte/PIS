﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GrpcServer_PI_21_01.Models
{

    public enum AppStatus
    {
        Awaiting_Registration,
        Registered,
        Performed,
        Fulfilled,
        Removed
    }
    public class App
    {
        public DateTime date { get; set; }
        public int number { get; set; }
        public Location locality { get; set; }
        public string territory { get; set; }
        public string animalHabiat { get; set; }
        public string urgencyOfExecution { get; set; }
        public string animaldescription { get; set; }
        public string applicantCategory { get; set; }
        public AppStatus status { get; set; }

        public static string EnumToString(AppStatus status)
        {
            if (status == AppStatus.Awaiting_Registration)
            {
                return "awaiting registration";
            }
            if (status == AppStatus.Registered )
            {
                return "registered";
            }
            if (status == AppStatus.Performed)
            {
                return "performed";
            }
            if (status == AppStatus.Fulfilled)
            {
                return "fulfilled";
            }
            if (status == AppStatus.Removed)
            {
                return "removed";
            }
            return "awaiting registration";
        }
        public static AppStatus StringToEnum(string status)
        {
            if (status == "awaiting registration")
            {
                return AppStatus.Awaiting_Registration;
            }
            if (status == "registered")
            {
                return AppStatus.Registered;
            }
            if (status == "performed")
            {
                return AppStatus.Performed;
            }
            if (status == "fulfilled")
            {
                return AppStatus.Fulfilled;
            }
            if (status == "removed")
            {
                return AppStatus.Removed;
            }
            return AppStatus.Awaiting_Registration;
        }
        public App(DateTime date, int number, Location locality, string territory, string animalHabiat, string urgencyOfExecution, string animaldescription, string applicantCategory, AppStatus status)
        {
            this.date = date;
            this.number = number;
            this.locality = locality;
            this.territory = territory;
            this.animalHabiat = animalHabiat;
            this.urgencyOfExecution = urgencyOfExecution;
            this.animaldescription = animaldescription;
            this.applicantCategory = applicantCategory;
            this.status = status;
        }
        public override bool Equals(object? obj)
        {
            App obj1 = obj as App;
            return this.number == obj1.number;
        }

        public static App GetById(int id, NpgsqlConnection cn)
        {
            NpgsqlCommand cmd = new($"SELECT * FROM catch_request WHERE id = {id}");
            cmd.Connection = cn;
            cn.Open();
            var reader = cmd.ExecuteReader();
            string[] arr = { "0", "0", "0", "0", "0", "0", "0", "0" };
            while (reader.Read())
            {
                arr[0] = (reader[1].ToString());
                arr[1] = reader[7].ToString();
                arr[2] = reader[2].ToString();
                arr[3] = reader[3].ToString();
                arr[4] = reader[4].ToString();
                arr[5] = reader[5].ToString();
                arr[6] = reader[6].ToString();
                arr[7] = reader[8].ToString();
            }
            var status = StringToEnum(arr[7]);
            reader.Close();
            cn.Close();
            return new App( DateTime.Parse(arr[0]), id, Location.GetById(int.Parse(arr[1]), cn), arr[2], arr[3], arr[4], arr[5], arr[6], status);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
