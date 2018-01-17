using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System;

namespace WebServicesCidades.Models
{
    public class DAOCidades
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        string conexao = @"Data Source=.\SqlExpress;Initial Catalog=projetoCidades;user id=sa;password=senai@123";

        public List<Cidades> Listar(){
             List<Cidades> cidades = new List<Cidades>();
            
            try{
                conn = new SqlConnection();
                conn.ConnectionString = conexao;
                conn.Open();
                cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from Cidades";

                dr = cmd.ExecuteReader();

                while(dr.Read()){
                    cidades.Add(new Cidades(){
                        Id = dr.GetInt32(0),
                        Nome = dr.GetString(1),
                        Estado = dr.GetString(2),
                        Habitantes = dr.GetInt32(3)
                    });
                }
                
            }catch(SqlException ex){
                throw new Exception(ex.Message);
            }
            catch(Exception ex){
                throw new Exception(ex.Message);
            }
            finally{
                conn.Close();
            }

            return cidades;
        }

        public bool Cadastro(Cidades cidades){
            bool resultado = false;
            try{
                conn = new SqlConnection(conexao);
                conn.Open();
                cmd=new SqlCommand();
                cmd.Connection = conn;
                
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Cidades(Nome,Estado,Habitantes) values(@nome,@estado,@habitantes)";
                
                cmd.Parameters.AddWithValue("@nome",cidades.Nome);
                cmd.Parameters.AddWithValue("@estado",cidades.Estado);
                cmd.Parameters.AddWithValue("@habitantes",cidades.Habitantes);

                int r = cmd.ExecuteNonQuery();

                if(r>0){
                    resultado=true;
                }

                cmd.Parameters.Clear();
            } 
            catch(SqlException ex){
                throw new Exception(ex.Message);
            }
            catch(Exception ex){
                throw new Exception(ex.Message);
            }
            finally{
                conn.Close();
            }

            return resultado;
        }

        public bool Excluir(int id){
            bool resultado = false;
            try{
                conn = new SqlConnection(conexao);
                conn.Open();
                cmd=new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from Cidades where id = @id";
                
                cmd.Parameters.AddWithValue("@id",id);

                int r = cmd.ExecuteNonQuery();

                if(r>0){
                    resultado=true;
                }

                cmd.Parameters.Clear();
            } 
            catch(SqlException ex){
                throw new Exception(ex.Message);
            }
            catch(Exception ex){
                throw new Exception(ex.Message);
            }
            finally{
                conn.Close();
            }

            return resultado;
        }

        public bool Atualizar(Cidades cidades){
            bool resultado = false;
            try{
                conn = new SqlConnection(conexao);
                conn.Open();
                cmd=new SqlCommand();
                
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Cidades set nome=@n, estado=@e, habitantes=@h where id = @id";
                
                cmd.Parameters.AddWithValue("@n",cidades.Nome);
                cmd.Parameters.AddWithValue("@e",cidades.Estado);
                cmd.Parameters.AddWithValue("@h",cidades.Habitantes);
                cmd.Parameters.AddWithValue("@id",cidades.Id);

                int r = cmd.ExecuteNonQuery();

                if(r>0){
                    resultado=true;
                }

                cmd.Parameters.Clear();
            } 
            catch(SqlException ex){
                throw new Exception(ex.Message);
            }
            catch(Exception ex){
                throw new Exception(ex.Message);
            }
            finally{
                conn.Close();
            }

            return resultado;
        }

    }
}