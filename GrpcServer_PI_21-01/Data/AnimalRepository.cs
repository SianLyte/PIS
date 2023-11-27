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
        // удалить после привязки БД
        //private readonly static List<AnimalCard> animalCards = new()
        //{
        //    new AnimalCard(1, "Собака", "Женский", "Лабрадор", 40, "Длинная", "Рыжий",
        //                    "Висячие", "Длинный", "ID101", "Метка 2",
        //                    LocationRepository.GetLocations()[0],
        //                    ActRepository.GetActs()[0],
        //                    null),

        //    new AnimalCard(2, "Кот", "Мужской", "Британская", 30, "Короткая", "Черный",
        //                    "Прямые", "Короткий", "ID302", "Метка 1",
        //                    LocationRepository.GetLocations()[0],
        //                    ActRepository.GetActs()[1],
        //                    null),

        //    new AnimalCard(4, "Собака", "Женский", "Немецкая овчарка", 50, "Длинная", "Черно-серый",
        //                    "Висячие", "Длинный", "ID041", "Метка 4",
        //                    LocationRepository.GetLocations()[0],
        //                    ActRepository.GetActs()[2],
        //                    null),

        //    new AnimalCard(3, "Кот", "Мужской", "Сиамская", 25, "Короткая", "Серый",
        //                    "Прямые", "Длинный", "ID201", "Метка 3",
        //                    LocationRepository.GetLocations()[0],
        //                    ActRepository.GetActs()[2],
        //                    null),
        //};

        public static bool AddAnimalCard(AnimalCard c)
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
            // 'animalCard' подаётся с Id = -1. После добавления в БД нужно присвоить
            // этому ссылочному значению новое Id, которое было присвоено самой БД

            //animalCards.Add(animalCard);

            // возвращаем true, если добавление произошло успешно,
            // вовзращаем false, если что-то пошло не так (например, поле, которое не может быть null, вдруг стало null)
            return true;
        }

        public static bool UpdateAnimalCard(AnimalCard c)
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
                $"WHERE id = {c.IdAnimalCard}") { Connection = cn };
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            // на вход получаем новую карточку животного, нам нужно найти в БД карточку животного с
            // ID = animalCard.IdAnimalCard и апдейтнуть его по всем остальным полям
            throw new NotImplementedException();

            // возвращаем true, если обновление произошло успешно,
            // вовзращаем false, если что-то пошло не так (например, карточки животного с таким Id не существует в БД)
        }

        public static bool RemoveAnimalCard(int id)
        {
            using NpgsqlCommand cmd = new($"DELETE FROM animal_card WHERE id = {id}") { Connection = cn };
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            //throw new NotImplementedException();
            return true;
            // возвращаем true, если удаление произошло успешно,
            // вовзращаем false, если что-то пошло не так (например, карточки животного с таким Id не существует в БД)
        }

        public static List<AnimalCard> GetAnimalCards()
        {
            List<AnimalCard> cards = new();
            List<string?[]> cardsEmpty = new();

            using (NpgsqlCommand cmd = new("SELECT * FROM animal_card") { Connection = cn })
            {
                cn.Open();
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cardsEmpty.Add(new string[13] {
                    reader[0].ToString(),
                    reader[1].ToString(),
                    reader[2].ToString(),
                    reader[3].ToString(),
                    reader[4].ToString(),
                    reader[5].ToString(),
                    reader[6].ToString(),
                    reader[7].ToString(),
                    reader[8].ToString(),
                    reader[9].ToString(),
                    reader[10].ToString(),
                    reader[11].ToString(),
                    reader[12].ToString()
                    });
                }
                reader.Close();
                cn.Close();
                for (int i = 0; i < cardsEmpty.Count; i++)
                {
                    var c = cardsEmpty[i];
                    foreach (var part in c) Console.WriteLine(part);

                    AnimalCard card = new AnimalCard(
                        int.Parse(c[0]),
                        c[1], c[2], c[3],
                        int.Parse(c[4]), c[5], c[6], c[7],
                        c[8],
                        c[9],
                        c[10],
                        Location.GetById(int.Parse(c[11]), cn),
                        Act.GetById(int.Parse(c[12]), cn),
                        null);
                    cards.Add(card);
                }
            }
                // должно забирать все карточки животного из БД (желательно сделать кэширование:
                // один раз читается и результат сохраняется на, например, 5 секунд, т.е. любой вызов
                // этого метода в течение 5 секунд возвращает кэшированное значение)
                // P.S. кэширование должно очищаться после выполнения других действий CRUD кроме Read
                return cards;
        }
    }
}
