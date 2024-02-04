using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProiectBD
{
    class DataBaseHandler
    {
        public string connectionString = "User Id=bd045;Password=g01g23nn;Data Source=bd-dc.cs.tuiasi.ro:1539/orcl;";
        public void InsertMasina(string numarInmatriculare, string marca, string dataFabricatie)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO MASINI(NUMAR_INMATRICULARE, marca, data_fabricatie) VALUES('"
                        + numarInmatriculare + "', '" + marca + "',TO_DATE('" + dataFabricatie + "', 'MM/DD/YYYY'))";
                    using (OracleCommand cmd = new OracleCommand(query, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Eroare la adaugarea datelor despre masina: " + e.Message);
                }
            }
        }
        public void InsertPersoana(string nume, string prenume)
        {
            int valoareId;
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO PERSOANE(nume, prenume) VALUES('"
                        + nume + "', '" + prenume + "')";
                    using (OracleCommand cmd = new OracleCommand(query, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    
                }
                catch (Exception e)
                {
                    MessageBox.Show("Eroare la adaugarea datelor despre persoana: " + e.Message);
                }
            }
        }
        public int GetPersoanaId()
        {
            int valoareId = 0;
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MAX(ID) FROM Persoane";
                    using (OracleCommand cmd = new OracleCommand(query, connection))
                    {
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            try
                            {
                                if(reader.Read())
                                {
                                    valoareId = Convert.ToInt32(reader[0]);
                                }
                            }
                            finally
                            {
                                reader.Close();
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Eroare la obtinerea id-ului persoanei: " + e.Message);
                }
            }
            return valoareId;
        }
        public int GetMasinaId()
        {
            int valoareId = 0;
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MAX(ID) FROM MASINI";
                    using (OracleCommand cmd = new OracleCommand(query, connection))
                    {
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            try
                            {
                                if (reader.Read())
                                {
                                    valoareId = Convert.ToInt32(reader[0]);
                                }
                            }
                            finally
                            {
                                reader.Close();
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Eroare la obtinerea id-ului masinii: " + e.Message);
                }
            }
            return valoareId;
        }
        public void InsertRezervare(string dataRezervarii, int idPersoana, int idMasina)
        {
            
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO REZERVARI(data_programarii, id_persoana, id_masina) VALUES(TO_DATE('"
                        + dataRezervarii + "', 'MM/DD/YYYY'),"
                        + idPersoana + ", " + idMasina + ")";
                    using (OracleCommand cmd = new OracleCommand(query, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }

                }
                catch (Exception e)
                {
                    MessageBox.Show("Eroare la adaugarea datelor despre rezervare: " + e.Message);
                }
            }
        }

        public void InsertFeedback(int idRezervare, int idPersoana, int feedback)
        {

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT DATA_PROGRAMARII  FROM REZERVARI WHERE ID = :id and DATA_PROGRAMARII < SYSDATE";
                    int check = 0;
                    using (OracleCommand cmd = new OracleCommand(query, connection))
                    {
                        cmd.Parameters.Add(new OracleParameter("id", idRezervare));
                        check = cmd.ExecuteNonQuery();
                    }
                    if (check > 0)
                    {
                        query = "INSERT INTO FEEDBACK(VALOARE, id_rezervare, id_persoana) VALUES("
                          + feedback + ", " + idRezervare + ", " + idPersoana + ")";
                        using (OracleCommand cmd = new OracleCommand(query, connection))
                        {
                            check = cmd.ExecuteNonQuery();
                        }
                    }
                    else
                        MessageBox.Show("Va rugam oferiti feedback dupa ce ati fost la programare! Multumim!");
                }
                catch (Exception e)
                {
                    MessageBox.Show("Eroare la adaugarea feedback-ului: " + e.Message);
                }
            }
        }
        public int GetRezervareId()
        {
            int valoareId = 0;
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MAX(ID) FROM REZERVARI";
                    using (OracleCommand cmd = new OracleCommand(query, connection))
                    {
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            try
                            {
                                if (reader.Read())
                                {
                                    valoareId = Convert.ToInt32(reader[0]);
                                }
                            }
                            finally
                            {
                                reader.Close();
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Eroare la obtinerea id-ului masinii: " + e.Message);
                }
            }
            return valoareId;
        }
        public void AnulareRezervare(int idRezervare)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                   
                        string query = "DELETE FROM REZERVARI WHERE ID = :id";
                        using (OracleCommand cmd = new OracleCommand(query, connection))
                        {
                            cmd.Parameters.Add(new OracleParameter("id", idRezervare));
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Rezervare anulata.");
                            }
                            else
                            {
                            MessageBox.Show("Rezervarea cu respectivul id nu a fost gasita.");
                            }
                        }
                    

                }
                catch (Exception e)
                {
                    MessageBox.Show("Eroare la anularea rezervarii: " + e.Message);
                }
            }
        }
        public void ModificareRezervare(int idRezervare, string dataRezervarii)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
         
                        string query = "UPDATE REZERVARI SET DATA_PROGRAMARII = TO_DATE('" +
                        dataRezervarii + "', 'MM/DD/YYYY') WHERE ID = :id";
                        using (OracleCommand cmd = new OracleCommand(query, connection))
                        {
                            cmd.Parameters.Add(new OracleParameter("id", idRezervare));
                            int rowsAffected = cmd.ExecuteNonQuery();
                            
                            if (rowsAffected > 0)
                            {
                            MessageBox.Show("Rezervare modificata.");
                            }
                            else
                            {
                            MessageBox.Show("Rezervarea cu respectivul id nu a fost gasita.");
                            }
                        }
                    

                }
                catch (Exception e)
                {
                    MessageBox.Show("Eroare la modificarea rezervarii: " + e.Message);
                }
            }
        }
    }
}
