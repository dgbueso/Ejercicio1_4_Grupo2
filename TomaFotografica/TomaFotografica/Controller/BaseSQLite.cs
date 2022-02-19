using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using Ejercicio1_4_Grupo2.Modals;

namespace Ejercicio1_4_Grupo2.Controller
{
    public class BaseSQLite
    {
        readonly SQLiteAsyncConnection db;

        //constructor de la clase DataBaseSQLite
        public BaseSQLite(String pathdb)
        {
            //crear una conexion a la base de datos
            db = new SQLiteAsyncConnection(pathdb);

            //creacion de la tabla personas dentro de SQLite
            db.CreateTableAsync<Fotos>().Wait();
        }

        //opaciones CRUD con SQLite
        //READ List Way
        public Task<List<Fotos>> ObtenerListaFotos()
        {
            return db.Table<Fotos>().ToListAsync();

        }

        //retornar una persona //READ one by one
        //(retorna el primero que encuentre ya que pueden a ver varios del dp choluteca)
        public Task<Fotos> Obtenerfotografia(int pcodigo)
        {
            return db.Table<Fotos>()
                .Where(i => i.codigo == pcodigo)
                .FirstOrDefaultAsync();
        }

        public Task<int> Grabarfotografia(Fotos foto)
        {
            if (foto.codigo != 0)
            {
                return db.UpdateAsync(foto);
            }
            else
            {

                return db.InsertAsync(foto);
            }
        }

        //delete
        public Task<int> EliminarUbicacion(Fotos foto)
        {
            return db.DeleteAsync(foto);
        }
    }
}
