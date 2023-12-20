using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcServer_PI_21_01.Models
{
    class Role
    {
        public string Name { get; set; }
        public Dictionary<NameMdels, bool> CheckPosibilitis { get; set; }

        public Role(string name, Dictionary<NameMdels, bool> checkPosibilitis)
        {
            CheckPosibilitis = checkPosibilitis;
            Name = name;
        }

        //public static Roles ToString(string role)
        //{
        //    foreach (Roles enumRole in Enum.GetValues(typeof(Roles)))
        //    {
        //        if (role == enumRole.ToString())
        //        {
        //            return enumRole;
        //        }
        //    }
        //    return Roles.Curator_OMSY;
        //}
    }

    enum NameMdels
    {
        Act,
        App,
        Contract,
        Org,
        Report,
        History
    }

    //public enum Roles
    //{
    //    OperatorPoOtlovy,
    //    CuratorVeterinaryService,
    //    CuratorShelter,
    //    OperatorVeterinaryService,
    //    OperatorShelter,
    //    PodpisantVeterinaryService,
    //    PodpisantShelter,
    //    CuratorOMSY,
    //    OperatorOMSY,
    //    PodpisantOMSY,
    //    CuratorPoOtlovy,
    //    PodpisantPoOtlovy,
    //    Admin
    //}
    //enum OrganizationType
    //{
    //    Znacheniya_Spravochnika,
    //    Ispolnitelni_Organ_Gos_Vlasti,
    //    Organ_Mestnogo_Samoypravleniya,
    //    Priut,
    //    Organization_Otlov,
    //    Organization_Otlov_Priut,
    //    Organization_Transportirovka,
    //    Veterinarnaya_Gos_Klinika,
    //    Veterinarnaya_Municipal_Klinika,
    //    Blagotvoritelni_Fond,
    //    Organization_Prodaja_Tovarov_And_Yslygi_Dlya_Jivotnih,
    //    Zayavitel
    //}
}
