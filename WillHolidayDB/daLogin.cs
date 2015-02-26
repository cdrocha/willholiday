using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;


namespace WillHolidayDB
{

    public class daLogin : daBase, IDisposable
    {

        #region IDisposable Members

        private bool disposed = false;

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    //Liberar recursos manejados
                }
                //liberar recursos no manejados
            }
            disposed = true;
        }

        ~daLogin()
        {
            Dispose(false);
        }

        #endregion


        public int ValidarUsuario(string UsuarioEmail, string UsuarioPassword)
        {
            int usuarioID;

            try
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WillHoliday"].ToString());
                command = new SqlCommand("UsuarioValidar", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UsuarioEmail", UsuarioEmail);
                command.Parameters.AddWithValue("@UsuarioPassword", UsuarioPassword);

                conn.Open();

                command.ExecuteNonQuery();
                usuarioID = Convert.ToInt32(command.ExecuteScalar());
                return usuarioID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                    conn.Close();
            }
        }



        public void GuardarActivacionPendiente(string codigoActivacion, int usuarioID)
        {
            try
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WillHoliday"].ToString());
                command = new SqlCommand("GuardarActivacionPendiente", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UsuarioID", usuarioID);
                command.Parameters.AddWithValue("@CodigoActivacion", codigoActivacion);

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                    conn.Close();
            }
        }


        public int EliminarActivacionPendiente(string codigoActivacion)
        {
            int filasAfectadas;

            try
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WillHoliday"].ToString());
                command = new SqlCommand("EliminarActivacionPendiente", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CodigoActivacion", codigoActivacion);

                conn.Open();
                filasAfectadas = command.ExecuteNonQuery();
                conn.Close();
                return filasAfectadas;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                    conn.Close();
            }
        }

        public int RegistrarUsuario(string usuarioEmail, string usuarioPassword)
        {
            int usuarioID;

            try
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WillHoliday"].ToString());
                command = new SqlCommand("InsertarUsuario", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Password", usuarioPassword);
                command.Parameters.AddWithValue("@Email", usuarioEmail);

                conn.Open();
                usuarioID = Convert.ToInt32(command.ExecuteScalar());
                conn.Close();
                return usuarioID;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                    conn.Close();
            }
        }

        public int RegistrarUsuarioFacebook(string facebookUserId, string first_name, string last_name, char gender, string email, string fotoURL)
        {
            int usuarioID;

            try
            {
                if (conn == null)
                {
                    conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WillHoliday"].ToString());
                }
                command = new SqlCommand("FacebookLogin", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FacebookID", facebookUserId);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@PerfilNombre", first_name);
                command.Parameters.AddWithValue("@PerfilApellido", last_name);
                command.Parameters.AddWithValue("@PerfilSexo", gender);
                command.Parameters.AddWithValue("@PerfilFoto", fotoURL);
	 
                conn.Open();
                usuarioID = Convert.ToInt32(command.ExecuteScalar());
                conn.Close();
                return usuarioID;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null)
                {
                    if(conn.State != ConnectionState.Closed)
                        conn.Close();
                }
            }
        }

        public int CambioPassword(string nombre, string actual, string nuevo)
        {
            int filasAfectadas;
            try
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WillHoliday"].ToString());
                command = new SqlCommand("CambioPassword", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UsuarioEmail", nombre);
                command.Parameters.AddWithValue("@PasswordActual", actual);
                command.Parameters.AddWithValue("@PasswordNuevo", nuevo);

                conn.Open();
                filasAfectadas = command.ExecuteNonQuery();
                conn.Close();
                return filasAfectadas;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                    conn.Close();
            }
        }

        public int ResetPassword(string nombre, string nuevo)
        {
            int filasAfectadas;

            try
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WillHoliday"].ToString());
                command = new SqlCommand("ResetPassword", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UsuarioEmail", nombre);
                command.Parameters.AddWithValue("@PasswordNuevo", nuevo);

                conn.Open();
                filasAfectadas = command.ExecuteNonQuery();
                conn.Close();
                return filasAfectadas;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                    conn.Close();
            }
        }

        public int ExisteEmail(string usuarioEmail)
        {
            int filasAfectadas;

            try
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WillHoliday"].ToString());
                command = new SqlCommand("UsuarioExisteEmail", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UsuarioEmail", usuarioEmail);

                conn.Open();
                filasAfectadas = Convert.ToInt32(command.ExecuteScalar());
                conn.Close();
                return filasAfectadas;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                    conn.Close();
            }
        }
    }
}