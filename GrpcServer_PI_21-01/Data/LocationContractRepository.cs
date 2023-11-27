using GrpcServer_PI_21_01.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcServer_PI_21_01.Data
{
    class LocationContractRepository
    {
        static readonly NpgsqlConnection cn = new NpgsqlConnection(DatabaseAssistant.ConnectionString);

        // ��� ������� ����� �� ����� ���������
        //private readonly static List<Location> locationCosts = new()
        //{ new Location(1, "�. ������"), 
        //    new Location(2, "�. ��������"),
        //    new Location(3, "�. ������")};

        public static List<Location> GetLocation()
        {
            // ������ �������� ��� ��������� �� �� (���������� ������� �����������:
            // ���� ��� �������� � ��������� ����������� ��, ��������, 5 ������, �.�. ����� �����
            // ����� ������ � ������� 5 ������ ���������� ������������ ��������)
            // P.S. ����������� ������ ��������� ����� ���������� ������ �������� CRUD ����� Read
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

        public static bool AddLocationContract(Location_Contract lc)
        {
            // 'loc' ������� � Id = -1. ����� ���������� � �� ����� ���������
            // ����� ���������� �������� ����� Id, ������� ���� ��������� ����� ��
            using NpgsqlCommand cmd = new($"INSERT INTO city_contract " +
                $"(cost, contract_id, city_id)" +
                $"VALUES ({lc.Price}, {lc.Contract.IdContract}, {lc.Locality.IdLocation}) RETURNING id")
            { Connection = cn };
            {
                cn.Open();
                int returnValue = (int)cmd.ExecuteScalar();
                lc.Id = returnValue;
                //cmd.ExecuteNonQuery();
                cn.Close();
            }
            return true;

            // ���������� true, ���� ���������� ��������� �������,
            // ���������� false, ���� ���-�� ����� �� ��� (��������, ����, ������� �� ����� ���� null, ����� ����� null)
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

            // ���������� true, ���� �������� ��������� �������,
            // ���������� false, ���� ���-�� ����� �� ��� (��������, ��������� � ����� Id �� ���������� � ��)
        }

        public static bool UpdateLocation(Location loc)
        {
            // �� ���� �������� ����� ���������, ��� ����� ����� � �� ��������� �
            // ID = loc.IdLocation � ���������� ��� �� ���� ��������� �����
            using NpgsqlCommand cmd = new($"UPDATE city SET " +
                $"city = '{loc.City}' WHERE id = {loc.IdLocation}")
            { Connection = cn };
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            return true;

            // ���������� true, ���� ���������� ��������� �������,
            // ���������� false, ���� ���-�� ����� �� ��� (��������, ��������� � ����� Id �� ���������� � ��)
        }
    }
}
