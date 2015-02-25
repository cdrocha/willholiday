﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;


namespace WillHoliday
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


    }
}