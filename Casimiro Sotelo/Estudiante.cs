using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNCSM
{
   public class Estudiante
    {
        public String GOVERMENT_ID { get; set; }
        public String NAME01 { get; set; }
        public String NAME02 { get; set; }
        public String LASTANAME01 { get; set; }
        public String LASTANAME02 { get; set; }
        public int ID_ETNIA { get; set; }
        public String  GENDER { get; set; }
        public int ID_MARITAL_STATUS { get; set; }
        public int ID_RELEGION { get; set; }
        public String ADDRES_COMPLETE { get; set; }
        public DateTime BIRTH_DATE { get; set; }
        public int ID_BIRTH_COUNTRY { get; set; }
        public int ID_COUNTRY_LIVE { get; set; }
        public int ID_DEPARTAMENTO { get; set; }
        public int ID_MUNICIPIO { get; set; }
        public String ADDRES_MAIL { get; set; }
        public String HOUSE_NUMBER { get; set; }
        public String PHONE01 { get; set; }
        public String P_DESCRIPTION01 { get; set; }
        public String PHONE02 { get; set; }
        public String P_DESCRIPTION02 { get; set; }
        public String PHONE03 { get; set; }
        public String P_DESCRIPTION03 { get; set; }
        public int PEOPLE_TYPE { get; set; }

        public int ID_CURRICULUM { get; set; }
        public String ACA_SESSION_P { get; set; }
    }
}
