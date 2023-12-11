using GrpcServer_PI_21_01.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcServer_PI_21_01.Data
{
    class AnimalRepository
    {
        static readonly NpgsqlConnection cn = new NpgsqlConnection(DatabaseAssistant.ConnectionString);
        public static int GetMaxPage(DataRequest req)
        {
            try
            {
                var query = new Filter<AnimalCard>(req.Filter).GenerateSQLForCount();
                using (NpgsqlCommand cmd = new(query) { Connection = cn })
                {

                    cn.Open();
                    string count = "";
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        count = reader[0].ToString();
                    }
                    reader.Close();
                    cn.Close();
                    var a = Math.Ceiling((decimal)int.Parse(count) / req.Page);
                    return (int)a;
                };
            }
            catch (Exception e)
            {
                cn.Close();
                Console.WriteLine(e.Message);
                throw ;
            }
        }

        public static bool AddAnimalCard(AnimalCard c)
        {
            try
            {
                using NpgsqlCommand cmd = new($"INSERT INTO animal_card" +
                $"(category, sex, breed, sizee," +
                $"wool, signs, id_metka, city_id, color, ears, tail, act_id) " +
                $"VALUES ('{c.Category}', '{c.Gender}', '{c.Breed}', {c.Size}, '{c.FurType}', '{c.SpicialSigns}'," +
                $"'{c.IdentificationLabel}', {c.Locality.IdLocation}, '{c.Color}', '{c.Ears}', '{c.Tail}', {c.ActCapture.ActNumber}) RETURNING id")
                { Connection = cn };
                {
                    cn.Open();
                    int returnValue = (int)cmd.ExecuteScalar();
                    c.IdAnimalCard = returnValue;
                    //cmd.ExecuteNonQuery();
                    cn.Close();
                }
                return true;
            }
            catch (Exception e)
            {
                cn.Close();
                Console.WriteLine(e.Message);
                throw ;
            }
        }

        public static bool UpdateAnimalCard(AnimalCard c)
        {
            try
            {
                using NpgsqlCommand cmd = new($"UPDATE act SET " +
                $"category = '{c.Category}'," +
                $"sex = '{c.Gender}'," +
                $"breed = '{c.Breed}'," +
                $"sizee = {c.Size}," +
                $"wool = '{c.FurType}'," +
                $"signs = '{c.SpicialSigns}'," +
                $"id_metka = '{c.IdentificationLabel}'," +
                $"city_id = {c.Locality.IdLocation}," +
                $"color = '{c.Color}'," +
                $"ears = '{c.Ears}'," +
                $"tail = '{c.Tail}'," +
                $"act_id = {c.ActCapture.ActNumber} " +
                $"WHERE id = {c.IdAnimalCard}")
                { Connection = cn };
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
                // на вход получаем новую карточку животного, нам нужно найти в БД карточку животного с
                // ID = animalCard.IdAnimalCard и апдейтнуть его по всем остальным полям
                return true;

                // возвращаем true, если обновление произошло успешно,
                // вовзращаем false, если что-то пошло не так (например, карточки животного с таким Id не существует в БД)
            }
            catch (Exception e)
            {
                cn.Close();
                Console.WriteLine(e.Message);
                throw ;
            }
        }

        public static bool RemoveAnimalCard(int id)
        {
            try
            {
                using NpgsqlCommand cmd = new($"DELETE FROM animal_card WHERE id = {id}") { Connection = cn };
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
                return true;
            }
            catch (Exception e)
            {
                cn.Close();
                Console.WriteLine(e.Message);
                throw ;
            }
        }

        public static List<AnimalCard> GetAnimalCards(DataRequest request)
        {
            try
            {
                var query = new Filter<AnimalCard>(request.Filter).GenerateSQL(request.Page);
                List<AnimalCard> cards = new();

                using (NpgsqlCommand cmd = new(query) { Connection = cn })
                {
                    cn.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var id = reader.GetInt32(reader.GetOrdinal("id"));
                        var category = reader.GetString(reader.GetOrdinal("category"));
                        var gender = reader.GetString(reader.GetOrdinal("sex"));
                        var breed = reader.GetString(reader.GetOrdinal("breed"));
                        var size = reader.GetInt32(reader.GetOrdinal("sizee"));
                        var wool = reader.GetString(reader.GetOrdinal("wool"));
                        var signs = reader.GetString(reader.GetOrdinal("signs"));
                        var identificationMark = reader.GetString(reader.GetOrdinal("id_metka"));
                        var cityid = reader.GetInt32(reader.GetOrdinal("city_id"));
                        var color = reader.GetString(reader.GetOrdinal("color"));
                        var ears = reader.GetString(reader.GetOrdinal("ears"));
                        var tail = reader.GetString(reader.GetOrdinal("tail"));
                        var actId = reader.GetInt32(reader.GetOrdinal("act_id"));

                        var processedId = -1;
                        reader.ReaderClosed += (o, e) =>
                        {
                            if (processedId == id) return;
                            processedId = id;

                            var animalCard = new AnimalCard(id, category, gender, breed, size,
                                wool, color, ears, tail, signs, identificationMark,
                                LocationRepository.GetLocation(cityid),
                                ActRepository.GetAct(actId), null);

                            cards.Add(animalCard);
                        };
                    }
                    reader.Close();
                    cn.Close();
                }
                return cards;
            }
            catch (Exception e)
            {
                cn.Close();
                Console.WriteLine(e.Message);
                throw ;
            }
        }

        public static AnimalCard? GetAnimalCard(int id)
        {
            try
            {
                using NpgsqlCommand cmd = new("SELECT * FROM animal_card WHERE id = " + id) { Connection = cn };
                cn.Open();

                var reader = cmd.ExecuteReader();
                if (!reader.Read()) return null;

                var category = reader.GetString(reader.GetOrdinal("category"));
                var gender = reader.GetString(reader.GetOrdinal("sex"));
                var breed = reader.GetString(reader.GetOrdinal("breed"));
                var size = reader.GetInt32(reader.GetOrdinal("sizee"));
                var wool = reader.GetString(reader.GetOrdinal("wool"));
                var signs = reader.GetString(reader.GetOrdinal("signs"));
                var identificationMark = reader.GetString(reader.GetOrdinal("id_metka"));
                var cityid = reader.GetInt32(reader.GetOrdinal("city_id"));
                var color = reader.GetString(reader.GetOrdinal("color"));
                var ears = reader.GetString(reader.GetOrdinal("ears"));
                var tail = reader.GetString(reader.GetOrdinal("tail"));
                var actId = reader.GetInt32(reader.GetOrdinal("act_id"));

                reader.Close();

                var animalCard = new AnimalCard(id, category, gender, breed, size,
                            wool, color, ears, tail, signs, identificationMark,
                            LocationRepository.GetLocation(cityid),
                            ActRepository.GetAct(actId), null);

                cn.Close();
                return animalCard;
            }
            catch (Exception e)
            {
                cn.Close();
                Console.WriteLine(e.Message);
                throw ;
            }
        }
    }
}
