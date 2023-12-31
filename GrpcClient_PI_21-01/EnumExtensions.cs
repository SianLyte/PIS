﻿using System.ComponentModel;
using System.Reflection;

namespace GrpcClient_PI_21_01
{
    public static class EnumExtensions
    {
        private static void CheckIsEnum<T>(bool withFlags)
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException(string.Format("Type '{0}' is not an enum", typeof(T).FullName));
            if (withFlags && !Attribute.IsDefined(typeof(T), typeof(FlagsAttribute)))
                throw new ArgumentException(string.Format("Type '{0}' doesn't have the 'Flags' attribute", typeof(T).FullName));
        }

        public static bool IsFlagSet<T>(this T value, T flag) where T : struct
        {
            CheckIsEnum<T>(true);
            long lValue = Convert.ToInt64(value);
            long lFlag = Convert.ToInt64(flag);
            return (lValue & lFlag) != 0;
        }

        public static IEnumerable<T> GetFlags<T>(this T value) where T : struct
        {
            CheckIsEnum<T>(true);
            foreach (T flag in Enum.GetValues(typeof(T)).Cast<T>())
            {
                if (value.IsFlagSet(flag))
                    yield return flag;
            }
        }

        public static T SetFlags<T>(this T value, T flags, bool on) where T : struct
        {
            CheckIsEnum<T>(true);
            long lValue = Convert.ToInt64(value);
            long lFlag = Convert.ToInt64(flags);
            if (on)
            {
                lValue |= lFlag;
            }
            else
            {
                lValue &= (~lFlag);
            }
            return (T)Enum.ToObject(typeof(T), lValue);
        }

        public static T SetFlags<T>(this T value, T flags) where T : struct
        {
            return value.SetFlags(flags, true);
        }

        public static T ClearFlags<T>(this T value, T flags) where T : struct
        {
            return value.SetFlags(flags, false);
        }

        public static T CombineFlags<T>(this IEnumerable<T> flags) where T : struct
        {
            CheckIsEnum<T>(true);
            long lValue = 0;
            foreach (T flag in flags)
            {
                long lFlag = Convert.ToInt64(flag);
                lValue |= lFlag;
            }
            return (T)Enum.ToObject(typeof(T), lValue);
        }

        public static string? GetDescription<T>(this T value) where T : struct
        {
            CheckIsEnum<T>(false);
            string? name = Enum.GetName(typeof(T), value);
            if (name != null)
            {
                FieldInfo? field = typeof(T).GetField(name);
                if (field != null)
                {
                    if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attr)
                    {
                        return attr.Description;
                    }
                }
            }
            return null;
        }
    }

    public static class EnumTranslationExtensions
    {
        public static string Translate(this AppStatus appStatus)
        {
            return appStatus switch
            {
                AppStatus.Registered => "Зарегистрирована",
                AppStatus.Fulfilled => "Исполнена",
                AppStatus.AwaitingRegistration => "Ожидает регистрации",
                AppStatus.Performed => "В исполнении",
                AppStatus.Removed => "Снята с контроля исполнения без отлова",
                _ => throw new InvalidEnumArgumentException("Unknown AppStatus enum for translation"),
            };
        }

        public static string Translate(this OrganizationType orgType) => orgType switch
        {
            OrganizationType.AnimalGoodsSeller => "Организация по продаже товаров и предоставлению услуг для животных",
            OrganizationType.Applicant => "Заявитель",
            OrganizationType.Shelter => "Приют",
            OrganizationType.TrappingAndShelter => "Организация по отлову и приют",
            OrganizationType.VetClinicPrivate => "Ветеринарная клиника: частная",
            OrganizationType.VetClinicState => "Ветеринарная клиника: государственная",
            OrganizationType.VetClinicMunicipal => "Ветеринарная клиника: муниципальная",
            OrganizationType.CharityFoundation => "Благотворительный фонд",
            OrganizationType.DirectoryValues => "Значения справочника",
            OrganizationType.GovernmentExecutive => "Исполнительный орган государственной власти",
            OrganizationType.Transportation => "Организация по транспортировке",
            OrganizationType.Trapping => "Организация по отлову",
            OrganizationType.LocalGovernment => "Орган местного самоуправления",
            _ => throw new InvalidEnumArgumentException("Unknown OrganizationType enum for translation"),
        };

        public static string Translate(this ReportStatus status) => status switch
        {
            ReportStatus.Revision => "Доработка",
            ReportStatus.ApprovedByMunicipalContractExecutor => "Согласован у исполнителя Муниципального контракта",
            ReportStatus.ApprovalFromMunicipalContractExecutor => "Согласование у исполнителя Муниципального контракта",
            ReportStatus.ApprovedByOmsy => "Согласован в ОМСУ",
            ReportStatus.Draft => "Черновик",
            ReportStatus.AgreedWithMunicipalContractExecutor => "Утверждён у исполнителя Муниципального контракта",
            _ => throw new InvalidEnumArgumentException("Unknown ReportStatus enum for translation"),
        };
    }
}