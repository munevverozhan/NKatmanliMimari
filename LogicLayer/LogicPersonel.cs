using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using LayerDataAccess;

namespace LogicLayer
{
    public class LogicPersonel
    {
        public static List<EntityPersonel> LLPersonelListesi()
        {
            return DALPersonel.personelListesi();
        }

        public static int LLPersonelEkle(EntityPersonel p)
        {
            if (p.Ad != "" && p.Soyad != "" && p.Gorev != "" && p.Maas > 0 && p.Sehir != "")
            {
                return DALPersonel.PersonelEkle(p);
            }
            else
            {
                return -1;
            }
        }

        public static bool LLPersonelSil(int per)
        {
            if (per > 0)
            {
                return DALPersonel.PersonelSil(per);
            }
            else
            {
                return false;
            }


        }

        public static bool LLPersonelGuncelle(EntityPersonel p)
        {
            if(p.Maas>0 && p.Ad !="" && p.Soyad != "" && p.Gorev != "" && p.Sehir != "")
            {
              return  DALPersonel.PersonelGuncelle(p);
            }
            else
            {
                return false;
            }
        }
    }
}
