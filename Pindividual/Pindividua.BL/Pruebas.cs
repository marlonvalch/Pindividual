using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pindividual.DAL;

namespace Pindividual.BL
{
    namespace PIndividual.BL
    {
        public class Prueba
        {

            public void Insertar()
            {
                Vuelos v1 = new Vuelos();
                v1.Id_vuelo = 5;
                v1.Escala = "xxx";
                v1.Duracion = 5;



                using (AeropuertoEntities context = new AeropuertoEntities())
                {

                    context.Vuelos.Add(v1);
                    context.SaveChanges();

                }

            }



            public void PruebaSelect()
            {


                using (AeropuertoEntities context = new AeropuertoEntities())
                {
                    var vuelos = context.Vuelos.ToList();
                    var aviones = context.Aviones.ToList();
                    var pasajeros = context.Pasajeros.ToList();
                    var PaisesDestinoAeropuerto = context.Paises_Destino_Aeropuerto.ToList();
                    



                }


            }

            public void PruebaWhereVuelos()
            {


                using (AeropuertoEntities context = new AeropuertoEntities())
                {
                    try
                    {
                        var vuelos = context.Vuelos.Where(x => x.Id_vuelo == 4);

                    }
                    catch (Exception e)
                    {


                        Console.WriteLine("e");
                    }

                }
            }

            public void PruebaWhereVuelos2()
            {


                using (AeropuertoEntities context = new AeropuertoEntities())
                {
                    try
                    {
                        var vuelos = context.Vuelos.Where(x => x.Duracion == 5);
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine("e");
                    }
                }


            }



            public void PruebaJoin()
            {


                using (AeropuertoEntities context = new AeropuertoEntities())
                {
                    //T representa una tupla en este caso tenemos T1 que es la tupla 1 y t2 que es la tupla 2 
                    //T Este caso presenta un Inner Join
                    try
                    {
                        var vuelos = context.Vuelos.Join(context.Paises_Destino_Aeropuerto,
                            t2 => t2.Id_vuelo,
                            t1 => t1.id,
                            (t1, t2) => new
                            {

                                escala = t1.Escala,
                                destino = t2.Destino

                            }
                            ).ToList();
                    }
                    catch (Exception e)
                    {


                        Console.WriteLine("e");

                    }

                }



            }



            public void PruebaWhereSelect()
            {
                //T lambda es una funcion en este ejemplo s es esa funcion sx tiene la misma función

                using (AeropuertoEntities context = new AeropuertoEntities())
                {
                    try
                    {
                        var vuelos = context.Vuelos.Where(x => x.Duracion == 5).Select(s =>
                        new
                        {

                            Escala = s.Escala,
                            Duracion = s.Duracion


                        }
                        ).ToList();

                    }
                    catch (Exception e)
                    {


                        Console.WriteLine("e");
                    }

                }



            }

            public void PruebaUpdate()
            {
                //

                using (AeropuertoEntities context = new AeropuertoEntities())
                {
                    try
                    {
                        var vuelo = context.Vuelos.Where(x => x.Duracion == 5).SingleOrDefault();
                        vuelo.Escala = "CAMBIO";
                        context.SaveChanges();

                    }
                    catch (Exception e)
                    {


                        Console.WriteLine(" prueba Update vuelo e");
                    }

                }


            }
        }
    }
}