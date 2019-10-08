using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pindividual.DAL;

namespace Pindividual.BL
{
    class Prueba
    {

       public void Prueba1()
        {
            Vuelos v1 = new Vuelos();
            v1.Duracion = 5;
            v1.Escala = "xxx";

            using (AeropuertoEntities context = new AeropuertoEntities())
            {
                context.Vuelos.Add(v1);
                context.SaveChanges();
            }


        }

        public void PruebaSelect()
        {

        }

    }
}
