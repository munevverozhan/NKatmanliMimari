using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Data.SqlClient;
using System.Data;

namespace LayerDataAccess
{
    public class DALPersonel
    {
        public static List<EntityPersonel> personelListesi()
        {
            List<EntityPersonel> degerler = new List<EntityPersonel>();
            SqlCommand cmd = new SqlCommand("select * from tblBilgi", Baglanti.conn);
            if(cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                EntityPersonel ent = new EntityPersonel();
                ent.Id =int.Parse(dr[0].ToString());
                ent.Ad = dr[1].ToString();
                ent.Soyad = dr[2].ToString();
                ent.Sehir = dr[3].ToString();
                ent.Gorev = dr[4].ToString();
                ent.Maas = short.Parse(dr[5].ToString());
                degerler.Add(ent);
            }
            dr.Close();
            return degerler;
        }

        public static int PersonelEkle(EntityPersonel p)
        {
            SqlCommand cmd2 = new SqlCommand("insert into tblBilgi (ad,soyad,sehir,gorev,maas) values(@p1,@p2,@p3,@p4,@p5)", Baglanti.conn);
            cmd2.Parameters.AddWithValue("@p1",p.Ad);
            cmd2.Parameters.AddWithValue("@p2",p.Soyad);
            cmd2.Parameters.AddWithValue("@p3",p.Sehir);
            cmd2.Parameters.AddWithValue("@p4",p.Gorev);
            cmd2.Parameters.AddWithValue("@p5",p.Maas);
            if(cmd2.Connection.State!= ConnectionState.Open)
            {
                cmd2.Connection.Open();
            }
            return cmd2.ExecuteNonQuery(); //etkilenen kayıt sayısını dödürür.

        }

        public static bool PersonelSil(int p)
        {
            SqlCommand cmd3 = new SqlCommand("delete from tblBilgi where id=@p1", Baglanti.conn);//
            cmd3.Parameters.AddWithValue("@p1", p);                                              //
            if(cmd3.Connection.State != ConnectionState.Open)                                    // ŞART KISMI
            {                                                                                    //
                cmd3.Connection.Open();                                                          //
            }                                                                                    //
            return cmd3.ExecuteNonQuery() > 0;// ŞART KISMINI sağlayan değer sayısı 0 dan büyükse true değeri döner anlamındadır.

        }

        public static bool PersonelGuncelle(EntityPersonel ent)
        {
            SqlCommand cmd4 = new SqlCommand("update tblBilgi set ad=@p1,soyad=@p2,sehir=@p3,gorev=@p4,maas=@p5 where id=@p6 ", Baglanti.conn);
            cmd4.Parameters.AddWithValue("@p1",ent.Ad);
            cmd4.Parameters.AddWithValue("@p2",ent.Soyad);
            cmd4.Parameters.AddWithValue("@p3",ent.Sehir);
            cmd4.Parameters.AddWithValue("@p4",ent.Gorev);
            cmd4.Parameters.AddWithValue("@p5",ent.Maas);
            cmd4.Parameters.AddWithValue("@p6",ent.Id);
            if(cmd4.Connection.State != ConnectionState.Open)
            {
                cmd4.Connection.Open();
            }
            return cmd4.ExecuteNonQuery() > 0;
        }
    }
}
