﻿using GrpcServer_PI_21_01.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcServer_PI_21_01.Data
{
    class LocationRepository
    {
        static readonly NpgsqlConnection cn = new NpgsqlConnection(DatabaseAssistant.ConnectionString);

        // это удалить когда БД будет привязана
        //private readonly static List<Location> locationCosts = new()
        //{ new Location(1, "г. Тюмень"), 
        //    new Location(2, "г. Тобольск"),
        //    new Location(3, "г. Сургут")};

        public static List<Location> GetLocations()
        {
            // должно забирать все местности из БД (желательно сделать кэширование:
            // один раз читается и результат сохраняется на, например, 5 секунд, т.е. любой вызов
            // этого метода в течение 5 секунд возвращает кэшированное значение)
            // P.S. кэширование должно очищаться после выполнения других действий CRUD кроме Read
            List<Location> locs = new();
            List<string?[]> locsEmpty = new();

            using (NpgsqlCommand cmd = new("SELECT * FROM city") { Connection = cn })
            {
                cn.Open();
                NpgsqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    locsEmpty.Add(new string[2] {
                    r[0].ToString(), //id
                    r[1].ToString(), //city
                    });
                }
                r.Close();
                cn.Close();
                for (int i = 0; i < locsEmpty.Count; i++)
                {
                    var a = locsEmpty[i];
                    Location loc = new(int.Parse(a[0]), a[1]);
                    locs.Add(loc);
                }
                
            }
            return locs;
        }

        public static bool AddLocation(Location loc)
        {
            // 'loc' подаётся с Id = -1. После добавления в БД нужно присвоить
            // этому ссылочному значению новое Id, которое было присвоено самой БД
            using NpgsqlCommand cmd = new($"INSERT INTO city " +
                $"(city)" +
                $"VALUES ('{loc.City}') RETURNING id")
            { Connection = cn };
            {
                cn.Open();
                int returnValue = (int)cmd.ExecuteScalar();
                loc.IdLocation = returnValue;
                //cmd.ExecuteNonQuery();
                cn.Close();
            }
            return true;

            // возвращаем true, если добавление произошло успешно,
            // вовзращаем false, если что-то пошло не так (например, поле, которое не может быть null, вдруг стало null)
        }

        public static bool RemoveLocation(int id)
        {
            using NpgsqlCommand cmd = new($"DELETE FROM city WHERE id = {id}") { Connection = cn };
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            //throw new NotImplementedException();
            return true;

            // возвращаем true, если удаление произошло успешно,
            // вовзращаем false, если что-то пошло не так (например, местности с таким Id не существует в БД)
        }

        public static bool UpdateLocation(Location loc)
        {
            // на вход получаем новую местность, нам нужно найти в БД местность с
            // ID = loc.IdLocation и апдейтнуть его по всем остальным полям
            using NpgsqlCommand cmd = new($"UPDATE city SET " +
                $"city = '{loc.City}' WHERE id = {loc.IdLocation}") { Connection = cn };
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            return true;

            // возвращаем true, если обновление произошло успешно,
            // вовзращаем false, если что-то пошло не так (например, местности с таким Id не существует в БД)
        }
    }
}
